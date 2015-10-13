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
    public partial class TfBlankStructureCalcField : Form
    {
        public int? CalcFieldId; // Код
        public int? StructureId; // Код структуры
        
        public TfBlankStructureCalcField()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            TfEditCalcField f = new TfEditCalcField() { Tag = this.Tag };

            f.Text = "Добавление нового значения";

            int? CalcFieldId = null;
            string Expression = ""; // Условие
            string Value = ""; // Значение
            int? Priority = 0; // Приоритет
            bool? Inside = true; // Внутренний
            bool? Active = true; // Активен
            string Description = ""; // Описание

            f.edDescription.Text = Description;
            f.edExpression.Text = Expression;
            f.edValue.Text = Value;
            f.cbActive.Checked = (bool)Active;
            f.cbInside.Checked = (bool)Inside;
            f.edPriority.Value = Convert.ToDecimal(Priority);

            if (f.ShowDialog() != DialogResult.OK)
                return;

            Description = f.edDescription.Text;
            Expression = f.edExpression.Text;
            Value = f.edValue.Text;
            Active = f.cbActive.Checked;
            Inside = f.cbInside.Checked;
            Priority = Convert.ToInt32(f.edPriority.Value);

            LocalService.EditCalcField(
                ref CalcFieldId, ref StructureId, ref Expression,
                ref Value, ref Priority, ref Inside, ref Active, ref Description, 1);

            dsCalcField.tbCalcFieldRow rw = (dsCalcField.tbCalcFieldRow)
                (Tag as TfMain).dsCalcField.tbCalcField.NewRow();

            rw.Код = (int)CalcFieldId;
            rw.Код_структуры = (int)StructureId;
            rw.Описание = Description;
            rw.Условие = Expression;
            rw.Значение = Value;
            rw.Внутренний = (bool)Inside;
            rw.Активен = (bool)Active;
            rw.Приоритет = (int)Priority;



            (Tag as TfMain).dsCalcField.tbCalcField.Rows.Add(rw);
            (Tag as TfMain).dsCalcField.AcceptChanges();
            
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbCalcFieldBindingSource.Current == null) return;
            TfEditCalcField f = new TfEditCalcField() { Tag = this.Tag };

            dsCalcField.tbCalcFieldRow rw = (dsCalcField.tbCalcFieldRow)
                (tbCalcFieldBindingSource.Current as DataRowView).Row;

            f.Text = "Редактирование значения";

            int? CalcFieldId = rw.Код;
            string Expression = rw.Условие; // Условие
            string Value = rw.Значение; // Значение
            int? Priority = rw.Приоритет; // Приоритет
            bool? Inside = rw.Внутренний; // Внутренний
            bool? Active = rw.Активен; // Активен
            string Description = rw.Описание; // Описание

            f.edDescription.Text = Description;
            f.edExpression.Text = Expression;
            f.edValue.Text = Value;
            f.cbActive.Checked = (bool)Active;
            f.cbInside.Checked = (bool)Inside;
            f.edPriority.Value = Convert.ToDecimal(Priority);
            if (f.ShowDialog() != DialogResult.OK)
                return;

            Description = f.edDescription.Text;
            Expression = f.edExpression.Text;
            Value = f.edValue.Text;
            Active = f.cbActive.Checked;
            Inside = f.cbInside.Checked;
            Priority = Convert.ToInt32(f.edPriority.Value);

            LocalService.EditCalcField(
                ref CalcFieldId, ref StructureId, ref Expression,
                ref Value, ref Priority, ref Inside, ref Active, ref Description, 0);

            rw.Код = (int)CalcFieldId;
            rw.Код_структуры = (int)StructureId;
            rw.Описание = Description;
            rw.Условие = Expression;
            rw.Значение = Value;
            rw.Внутренний = (bool)Inside;
            rw.Активен = (bool)Active;
            rw.Приоритет = (int)Priority;

            (Tag as TfMain).dsCalcField.AcceptChanges();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbCalcFieldBindingSource.Current == null) return;

            if (MessageBox.Show(
                    "Вы действительно хотите удалить данную позицию?",
                    "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;

            dsCalcField.tbCalcFieldRow rw = (dsCalcField.tbCalcFieldRow)
                (tbCalcFieldBindingSource.Current as DataRowView).Row;

            int? CalcFieldId = rw.Код;
            string Expression = rw.Условие; // Условие
            string Value = rw.Значение; // Значение
            int? Priority = rw.Приоритет; // Приоритет
            bool? Inside = rw.Внутренний; // Внутренний
            bool? Active = rw.Активен; // Активен
            string Description = rw.Описание; // Описание

            LocalService.EditCalcField(
                ref CalcFieldId, ref StructureId, ref Expression,
                ref Value, ref Priority, ref Inside, ref Active, ref Description, -1);

            rw.Delete();
            (Tag as TfMain).dsCalcField.AcceptChanges();

            MessageBox.Show("Позиция была успешно удалена из списка!", "Успешное удаление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
