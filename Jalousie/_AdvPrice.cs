using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jalousie.Datasets;

namespace Jalousie
{
    public partial class TfAdvPrice : Form
    {
        public TfAdvPrice()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var f = new TfEditAdvPrice {Tag = this.Tag, Text = @"Новая позиция"};

            if (f.ShowDialog() != DialogResult.OK) return;

            int? AdvPriceId = null; // Код
            var BlankId = (int?)lbBlankId.Tag;  // Код бланка
            var Expression = f.edExpression.Text; // Ограничение
            var TruePart = f.edTruePart.Text; // Сообщение
            var Description = f.edDescription.Text; // Описание
            double? Price = 0; // Приоритет
            bool? Whole = false;
            int? Priority = Convert.ToInt32(f.edPriority.Value);

            LocalService.EditAdvPriceList(
                ref AdvPriceId, ref BlankId, ref Expression,
                ref Price, ref TruePart, ref Description, ref Whole, ref Priority, 1);

            var rw = (dsAdvPrice.tbAdvPriceRow)
                (Tag as TfMain).dsAdvPrice.tbAdvPrice.NewRow();
            rw.Код = (int)AdvPriceId;
            rw.Код_бланка = (int)BlankId;
            rw.Условие = Expression;
            rw.Описание = Description;
            rw.Выражение = TruePart;
            rw.Сумма = (double)Price;
            rw.Опт = (bool)Whole;
            rw.Приоритет = (int)Priority;
            (Tag as TfMain).dsAdvPrice.tbAdvPrice.Rows.Add(rw);

            (Tag as TfMain).dsAdvPrice.AcceptChanges();
            tbAdvPriceBindingSource.Position =
                tbAdvPriceBindingSource.Find("Код", AdvPriceId);

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbAdvPriceBindingSource.Current == null) return;

            if (MessageBox.Show(
                    @"Вы действительно хотите удалить данную позицию?",
                    @"Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;
            var rw = (dsAdvPrice.tbAdvPriceRow)
                (tbAdvPriceBindingSource.Current as DataRowView).Row;

            int? AdvPriceId = rw.Код; // Код
            int? BlankId = null;  // Код бланка
            string Expression = null;
            string TruePart = null;
            string Description = null;
            double? Price = null;
            bool? Whole = null;
            int? Priority = null;

            LocalService.EditAdvPriceList(
                ref AdvPriceId, ref BlankId, ref Expression,
                ref Price, ref TruePart, ref Description, ref Whole, ref Priority, - 1);

            MessageBox.Show(@"Позиция было успешно удалена!", @"Успешное удаление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            rw.Delete();
            (Tag as TfMain).dsAdvPrice.AcceptChanges();

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbAdvPriceBindingSource.Current == null) return;
            var rw = (dsAdvPrice.tbAdvPriceRow)
                (tbAdvPriceBindingSource.Current as DataRowView).Row;

            var f = new TfEditAdvPrice
                        {
                            Tag = this.Tag,
                            Text = @"Дополнительная расценка",
                            edExpression = {Text = rw.Условие},
                            edTruePart = {Text = rw.Выражение},
                            edDescription = {Text = rw.Описание},
                            edPriority = {Value = Convert.ToDecimal(rw.Приоритет)}
                        };

            if (f.ShowDialog() != DialogResult.OK) return;

            int? AdvPriceId = rw.Код; // Код
            int? BlankId = rw.Код_бланка;  // Код бланка
            var Expression = f.edExpression.Text; // Ограничение
            var TruePart = f.edTruePart.Text; // Сообщение
            var Description = f.edDescription.Text; // Описание
            double? Price = 0; // Приоритет
            bool? Whole = false;
            int? Priority = Convert.ToInt32(f.edPriority.Value);

            LocalService.EditAdvPriceList(
                ref AdvPriceId, ref BlankId, ref Expression,
                ref Price, ref TruePart, ref Description, ref Whole, ref Priority, 0);

            rw.Код = (int)AdvPriceId;
            rw.Код_бланка = (int)BlankId;
            rw.Условие = Expression;
            rw.Описание = Description;
            rw.Выражение = TruePart;
            rw.Сумма = (double)Price;
            rw.Опт = (bool)Whole;
            rw.Приоритет = (int)Priority;

            (Tag as TfMain).dsAdvPrice.AcceptChanges();
        }
    }
}
