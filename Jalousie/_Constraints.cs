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
    public partial class TfConstraints : Form
    {
        public TfConstraints()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var f = new TfEditConstraints
                        {
                            Tag = this.Tag,
                            Text = "Новое ограничение",
                            tbExpressionTypeBindingSource = {DataSource = (Tag as TfMain).dsConstraints},
                            tbOperationsBindingSource = {DataSource = (Tag as TfMain).dsConstraints}
                        };

            if (f.ShowDialog() != DialogResult.OK) return;

            int? ConstraintId = null; // Код
            int? BlankId = (int?)lbBlankId.Tag;  // Код бланка
            string Constraint = f.edConstraint.Text; // Ограничение
            string Message = f.edMessage.Text; // Сообщение
            string Description =  f.edDescription.Text; // Описание
            int? Priority = Convert.ToInt32(f.edPriority.Value); // Приоритет
            int? OperationId = Convert.ToInt32(f.cbOperation.SelectedValue);
            int? ExpressionTypeId = Convert.ToInt32(f.cbExpressionType.SelectedValue);
            bool? Active = f.cbActive.Checked; // Активен

            LocalService.EditConstraints(
                ref ConstraintId, ref BlankId, ref Constraint,
                ref Message, ref Description, ref Priority, ref ExpressionTypeId, ref OperationId, ref Active, 1);

            var rw = (dsConstraints.tbConstraintsRow)
                (Tag as TfMain).dsConstraints.tbConstraints.NewRow();
            rw.Код = (int)ConstraintId;
            rw.Код_бланка = (int)BlankId;
            rw.Ограничение = Constraint;
            rw.Описание = Description;
            rw.Сообщение = Message;
            rw.Приоритет = (int)Priority;
            rw.Активен = (bool)Active;
            rw.Тип_выражения = (int) ExpressionTypeId;
            rw.Операция = (int) OperationId;
            (Tag as TfMain).dsConstraints.tbConstraints.Rows.Add(rw);

            (Tag as TfMain).dsConstraints.AcceptChanges();
            tbConstraintsBindingSource.Position =
                tbConstraintsBindingSource.Find("Код", ConstraintId);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbConstraintsBindingSource.Current == null) return;

            if (MessageBox.Show(
                    "Вы действительно хотите удалить данное ограничения из бланка?",
                    "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;
            var rw = (dsConstraints.tbConstraintsRow)
                (tbConstraintsBindingSource.Current as DataRowView).Row;
            int? ConstraintId = rw.Код; // Код
            int? BlankId = null; ; // Код бланка
            string Constraint = null; // Ограничение
            string Message = null; // Сообщение
            string Description = null; // Описание
            int? Priority = null; // Приоритет
            int? ExpressionTypeId = null;
            int? OperationId = null;
            bool? Active = null; // Активен

            LocalService.EditConstraints(
                ref ConstraintId, ref BlankId, ref Constraint,
                ref Message, ref Description, ref Priority, ref ExpressionTypeId, ref OperationId, ref Active, -1);

            MessageBox.Show("Ограничение было успешно удалениз бланка!", "Успешное удаление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            rw.Delete();
            (Tag as TfMain).dsConstraints.AcceptChanges();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbConstraintsBindingSource.Current == null) return;
            var rw = (dsConstraints.tbConstraintsRow)
                (tbConstraintsBindingSource.Current as DataRowView).Row;

            var f = new TfEditConstraints
                        {
                            Tag = this.Tag,
                            Text = "Ограничение",
                            edConstraint = {Text = rw.Ограничение},
                            edMessage = {Text = rw.Сообщение},
                            edDescription = {Text = rw.Описание},
                            edPriority = {Value = Convert.ToDecimal(rw.Приоритет)},
                            cbActive = {Checked = rw.Активен},
                            tbExpressionTypeBindingSource = {DataSource = (Tag as TfMain).dsConstraints},
                            tbOperationsBindingSource = {DataSource = (Tag as TfMain).dsConstraints},
                            cbExpressionType = {SelectedValue = rw.Тип_выражения},
                            cbOperation = { SelectedValue = rw.Операция }
                        };

            if (f.ShowDialog() != DialogResult.OK) return;

            int? ConstraintId = rw.Код; // Код
            int? BlankId = rw.Код_бланка;  // Код бланка
            string Constraint = f.edConstraint.Text; // Ограничение
            string Message = f.edMessage.Text; // Сообщение
            string Description = f.edDescription.Text; // Описание
            int? Priority = Convert.ToInt32(f.edPriority.Value); // Приоритет
            int? OperationId = Convert.ToInt32(f.cbOperation.SelectedValue);
            int? ExpressionTypeId = Convert.ToInt32(f.cbExpressionType.SelectedValue);
            
            bool? Active = f.cbActive.Checked; // Активен

            LocalService.EditConstraints(
                ref ConstraintId, ref BlankId, ref Constraint,
                ref Message, ref Description, ref Priority, ref ExpressionTypeId, ref OperationId, ref Active, 0);

            rw.Код = (int)ConstraintId;
            rw.Код_бланка = (int)BlankId;
            rw.Ограничение = Constraint;
            rw.Описание = Description;
            rw.Сообщение = Message;
            rw.Приоритет = (int)Priority;
            rw.Тип_выражения = (int)ExpressionTypeId;
            rw.Операция = (int) OperationId;
            rw.Активен = (bool)Active;

            (Tag as TfMain).dsConstraints.AcceptChanges();
        }
    }
}
