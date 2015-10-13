using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Jalousie
{
    public partial class TfOrderFile : Form
    {
        public TfMain fMain;
        public int OrderId;
        public int BlankId;
        public byte[] FileContent;
        public byte[] PatternContent;
        public int ProgramId;


        public TfOrderFile()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TfOrderFile_Shown(object sender, EventArgs e)
        {
            tbProgramBindingSource.DataSource = fMain.dsBlanks.tbProgram;
            tbProgramBindingSource.Filter=String.Format("[Код] IN ({0})",
                fMain.dsBlanks.tbLinked.AsEnumerable()
                    .Where(x => x.Код_бланка == BlankId)
                    .Aggregate("0", (f, s) => f + "," + s.Код_программы.ToString()));
            cbProgram_SelectedIndexChanged(cbProgram, null);
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            if (!btNew.Enabled)
                return;

            var InstallProgram = LocalService.FileCollection
                .Where(x => x.ProgramId == ProgramId)
                .ToList()[0];


            var FileName = Path.Combine(InstallProgram.Path,
                String.Format("{0}-{1}.{2}", OrderId, ProgramId,
                    fMain.dsBlanks.tbProgram.FindByКод(ProgramId).Расширение));

            try
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                var ms = new MemoryStream(PatternContent);
                var fs = File.OpenWrite(FileName);
                ms.WriteTo(fs);
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    String.Format("Файл не удалось открыть.\nПричина:{0}.", ex.Message),
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Process.Start(InstallProgram.FileName,
                String.Format("\"{0}\"", FileName));
            Thread.Sleep(2000);

            if (MessageBox.Show(
                   "Программа была успешно открыта для редактирования.\nСохранить результат редактирования на сервере?",
                    "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (!File.Exists(FileName))
            {
                MessageBox.Show("Сохраненный файл не удалось найти.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                try
                {
                    var rfs = File.OpenRead(FileName);
                    var rms = new MemoryStream();
                    rms.SetLength(rfs.Length);
                    rfs.Read(rms.GetBuffer(), 0, (int)rfs.Length);
                    rms.Flush();
                    rfs.Close();
                    bool Error;
                    string Message;
                    LocalService.SetLinkedFile(OrderId, ProgramId, rms.GetBuffer(), out Error, out Message);
                    if (Error)
                        MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Файл был успешно обновлен на сервере.", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        String.Format("Файл не удалось сохранить.\nПричина:{0}.", ex.Message),
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            finally
            {
                cbProgram_SelectedIndexChanged(cbProgram, null);
            }

        }

        private void cbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProgramId = (int) cbProgram.SelectedValue;
            PatternContent = LocalService.GetPatternLinkedFile(OrderId, ProgramId);
            FileContent = LocalService.GetLinkedFile(OrderId, ProgramId);

            var IsEdit = fMain.dsOrders.tbOrders.FindByКод(OrderId).Статус == 0;
            var HasInstallprogram = LocalService.FileCollection
                                         .Where(x => x.ProgramId == ProgramId)
                                         .ToList().Count > 0;
            btNew.Enabled = IsEdit && HasInstallprogram && PatternContent != null && FileContent == null;
            btEdit.Enabled = IsEdit && HasInstallprogram && FileContent != null;
            btLoad.Enabled = IsEdit && FileContent == null;
            btDelete.Enabled = IsEdit && FileContent != null;
            btView.Enabled = HasInstallprogram && FileContent != null;
        }

        private void btView_Click(object sender, EventArgs e)
        {
            if (!btView.Enabled)
                return;

            var InstallProgram = LocalService.FileCollection
                .Where(x => x.ProgramId == ProgramId)
                .ToList()[0];


            var FileName = Path.Combine(InstallProgram.Path,
                String.Format("{0}-{1}.{2}", OrderId, ProgramId,
                    fMain.dsBlanks.tbProgram.FindByКод(ProgramId).Расширение));

            try
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                var ms = new MemoryStream(FileContent);
                var fs = File.OpenWrite(FileName);
                ms.WriteTo(fs);
                fs.Flush();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    String.Format("Файл не удалось открыть.\nПричина:{0}.", ex.Message),
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Process.Start(InstallProgram.FileName,
                String.Format("\"{0}\"", FileName));
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (!btDelete.Enabled)
                return;

            if (MessageBox.Show(
                   "Удалить сохраннный на сервере файл?","Внимание",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                try
                {
                    bool Error;
                    string Message;
                    LocalService.SetLinkedFile(OrderId, ProgramId, null, out Error, out Message);
                    if (Error)
                        MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Файл был успешно удален на сервере.", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        String.Format("Файл не удалось удалить.\nПричина:{0}.", ex.Message),
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            finally
            {
                cbProgram_SelectedIndexChanged(cbProgram, null);
            }

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (!btEdit.Enabled)
                return;

            var InstallProgram = LocalService.FileCollection
                .Where(x => x.ProgramId == ProgramId)
                .ToList()[0];


            var FileName = Path.Combine(InstallProgram.Path,
                String.Format("{0}-{1}.{2}", OrderId, ProgramId,
                    fMain.dsBlanks.tbProgram.FindByКод(ProgramId).Расширение));

            try
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                var ms = new MemoryStream(FileContent);
                var fs = File.OpenWrite(FileName);
                ms.WriteTo(fs);
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    String.Format("Файл не удалось открыть.\nПричина:{0}.", ex.Message),
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Process.Start(InstallProgram.FileName,
                String.Format("\"{0}\"", FileName));
            Thread.Sleep(2000);
            if (MessageBox.Show(
                   "Файл был успешно открыт для редактирования.\nСохранить результат редактирования на сервере?",
                    "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (!File.Exists(FileName))
            {
                MessageBox.Show("Сохраненный файл не удалось найти.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;                
            }

            try
            {
                try
                {
                    var rfs = File.OpenRead(FileName);
                    var rms = new MemoryStream();
                    rms.SetLength(rfs.Length);
                    rfs.Read(rms.GetBuffer(), 0, (int) rfs.Length);
                    rms.Flush();
                    rfs.Close();
                    bool Error;
                    string Message;
                    LocalService.SetLinkedFile(OrderId, ProgramId, rms.GetBuffer(), out Error, out Message);
                    if (Error)
                        MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Файл был успешно обновлен на сервере.", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        String.Format("Файл не удалось сохранить.\nПричина:{0}.", ex.Message),
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            finally
            {
                cbProgram_SelectedIndexChanged(cbProgram, null);
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            if (!btNew.Enabled)
                return;
            var fd = new OpenFileDialog();
            var ListInstallprogram = LocalService.FileCollection
                                         .Where(x => x.ProgramId == ProgramId)
                                         .ToList();

            fd.InitialDirectory = ListInstallprogram.Count > 0
                                      ? ListInstallprogram[0].Path
                                      : fd.InitialDirectory = Application.StartupPath;
            fd.Filter = String.Format("{0} (*.{1})|*.{1}|Все файлы (*.*)|*.*",
                                      fMain.dsBlanks.tbProgram.FindByКод(ProgramId).Название,
                                      fMain.dsBlanks.tbProgram.FindByКод(ProgramId).Расширение);
            fd.DefaultExt = fMain.dsBlanks.tbProgram.FindByКод(ProgramId).Расширение;
            fd.FileName = String.Format("{0}-{1}.{2}", OrderId, ProgramId,
                    fMain.dsBlanks.tbProgram.FindByКод(ProgramId).Расширение);
            fd.AddExtension = false;
            if (fd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                try
                {
                    var rfs = fd.OpenFile();
                    var rms = new MemoryStream();
                    rms.SetLength(rfs.Length);
                    rfs.Read(rms.GetBuffer(), 0, (int)rfs.Length);
                    rms.Flush();
                    rfs.Close();
                    bool Error;
                    string Message;
                    LocalService.SetLinkedFile(OrderId, ProgramId, rms.GetBuffer(), out Error, out Message);
                    if (Error)
                        MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Файл был успешно обновлен на сервере.", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        String.Format("Файл не удалось сохранить.\nПричина:{0}.", ex.Message),
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            finally
            {
                cbProgram_SelectedIndexChanged(cbProgram, null);
            }

        }
    }
}
