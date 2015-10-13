using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jalousie
{
    public partial class TfOrderCalculation : Form
    {
        public TfOrderCalculation()
        {
            InitializeComponent();
        }

        public void Calculation(int OrderId)
        {
            dsOrderCalculation.Clear();
            dsOrderCalculation.tbCalc.Load(LocalService.GetOrderCalculation(OrderId).Tables[0].CreateDataReader());

            var sum = dsOrderCalculation.tbCalc
                .Where(rw => !rw.IsРасчетная_ценаNull() && !rw.IsТребуетсяNull())
                .Select(rw => rw.Требуется*rw.Расчетная_цена)
                .Sum();
            lbSum.Text = String.Format("{0:N2}", sum);
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
