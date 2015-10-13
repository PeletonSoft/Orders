using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Clients
{
    public partial class TfEditClient : Form
    {
        private readonly string _connectionString;
        private readonly Color _clRequired = Color.FromArgb(255, 255, 220, 220);

        private readonly string _emailMask;
        private readonly string _descriptionMask;
        private readonly string _faceMask;
        private readonly string _fullMask;
        private readonly IList<Replace> _telephoneMasks;
        private readonly Customer _customer;
        private readonly IList<TelephoneRecord> _telephoneRecords;

        public TfEditClient(string connctionString, Customer customer)
        {
            InitializeComponent();

            _connectionString = connctionString;
            _customer = customer;


            using (var dc = new ClientDataContext(_connectionString))
            {
                _emailMask = dc.Заказы_покупатель_маска("email");
                _descriptionMask = dc.Заказы_покупатель_маска("desc");
                _faceMask = dc.Заказы_покупатель_маска("face");
                _fullMask = dc.Заказы_покупатель_маска("full");
                var telMask = dc.Заказы_покупатель_маска("tel");

                _telephoneMasks = dc.Replaces
                    .Where(replace => replace.Тип == 1)
                    .OrderBy(replace => replace.Приоритет)
                    .ToList();

                _telephoneRecords = dc.RegExMatch(_fullMask, customer.Телефон ?? "")
                    .Where(rec => rec.GroupName == "head" || rec.GroupName == "element")
                    .ToList()
                    .Select(rec =>
                            new TelephoneRecord()
                                {
                                    Telephone = Regex.Replace(rec.Value, telMask, "${tel}"),
                                    Face = Regex.Replace(rec.Value, telMask, "${face}"),
                                    Appendix = Regex.Replace(rec.Value, telMask, "${desc}")
                                })
                    .ToList();
            }


            
        }

        private void TfEditClient_Shown(object sender, EventArgs e)
        {
            if (_telephoneRecords.Count > 1)
                Height += 150;

            dbg.AutoGenerateColumns = false;


            if (_customer.Код == 0)
            {
                Text = "Новый покупатель";
            }
            else
            {
                Text = "Редактирование покупателя";
            }

            GridViewState(0);
            ViewTelephoneRecord();

            edName.Text = _customer.ФИО.Trim();

            cbPerson.Checked = true;
            ViewState();

            if (edName.CanFocus)
            {
                edName.Focus();
                edName.SelectAll();
            }
        }

        private void propertyForm_Click(object sender, EventArgs e)
        {
            ViewState();

            if (edName.CanFocus)
                edName.Focus();
        }

        private void propertyFormViewState(bool isPerson)
        {
            lbName.Text = isPerson
                              ? " [Фамилия] + [Инициалы]"
                              : " [Форма собственности] + [Название]";

        }

        private void edName_TextChanged(object sender, EventArgs e)
        {
            ViewState();
            ;
        }

        private bool ValidateName()
        {
            var name = edName.Text.Trim();
            return name != ""
                   && name.Length > 4
                   && "!0123456789@;, '\\/*".IndexOf(name) < 0
                   && name.IndexOf(" ") >= 0;
        }

        private bool ValidateEmail()
        {
            var text = edEmail.Text.Trim();
            return text == "" 
                || Regex.IsMatch(
                    text, 
                    "^" + _emailMask + "$");
        }

        private bool ValidateTelephoneFace()
        {
            var text = edTelephoneFace.Text.Trim();
            return cbPerson.Checked && text == ""
                || Regex.IsMatch(
                    text,
                    "^" + _faceMask + "$");
        }

        private bool ValidateTelephoneDescription()
        {
            var text = edTelephoneDescription.Text.Trim();
            return text == ""
                || Regex.IsMatch(
                    text,
                    "^" + _descriptionMask + "$");
        }

        private bool ValidateDescription()
        {
            var text = edDescription.Text.Trim();
            return text == ""
                || Regex.IsMatch(
                    text,
                    "^" + _descriptionMask + "$");
        }

        private void edEmail_TextChanged(object sender, EventArgs e)
        {
            ViewState();
        }

        private void edTelephoneFace_TextChanged(object sender, EventArgs e)
        {
            ViewState();
        }

        private void edTelephoneDescription_TextChanged(object sender, EventArgs e)
        {
            ViewState();
        }

        private void edDescription_TextChanged(object sender, EventArgs e)
        {
            ViewState();
        }

        private void ViewState()
        {
            propertyFormViewState(cbPerson.Checked);

            edName.BackColor =
                ValidateName()
                    ? SystemColors.Window
                    : _clRequired;

            edEmail.BackColor =
                ValidateEmail()
                    ? SystemColors.Window
                    : _clRequired;

            edTelephoneFace.BackColor =
                ValidateTelephoneFace()
                    ? SystemColors.Window
                    : _clRequired;

            edTelephoneDescription.BackColor =
                ValidateTelephoneDescription()
                    ? SystemColors.Window
                    : _clRequired;

            edDescription.BackColor =
                ValidateDescription()
                    ? SystemColors.Window
                    : _clRequired;

            if (_telephoneRecords.Count > 0)
                cbEmpty.Checked = false;
            cbEmpty.Enabled = _telephoneRecords.Count == 0;

            TelephoneViewState();

            var index = dbg.SelectedRows[0].Index;
            var isNew = dbg.NewRowIndex == index;

            var isValidateTelephoneRecord =
                ValidateTelephone() &&
                ValidateTelephoneFace() &&
                ValidateTelephoneDescription();

            btItemPlus.Enabled = isValidateTelephoneRecord;
            btAdd.Enabled = isValidateTelephoneRecord;
            btItemSave.Enabled = isValidateTelephoneRecord;

            btItemMinus.Enabled = !isNew;
            btItemCancel.Enabled = !isNew;

            btOk.Enabled =
                (isValidateTelephoneRecord || cbEmpty.Checked)
                && ValidateEmail()
                && ValidateEmail()
                && ValidateName();

        }

        private void edTelephone_TextChanged(object sender, EventArgs e)
        {
            ViewState();
        }

        private void TelephoneViewState()
        {
            bool isMatch = ValidateTelephone();

            pcCheck.Visible = isMatch;
            pcWrong.Visible = !isMatch;

            edTelephone.BackColor = isMatch
                ? SystemColors.Window : _clRequired;

            if (!isMatch)
                stTelephone.Text = @"<нет телефона>";
        }

        private bool ValidateTelephone()
        {
            var text = edTelephone.Text.Trim();
            var isMatch = false;
            foreach (var replace in _telephoneMasks)
            {
                if (!Regex.IsMatch(text, replace.Маска)) 
                    continue;

                stTelephone.Text = 
                    Regex.Replace(text, replace.Маска, replace.Замена);
                isMatch = true;
            }
            return isMatch;
        }

        private void btItemPlus_Click(object sender, EventArgs e)
        {
            var index = dbg.SelectedRows[0].Index;
            if (dbg.NewRowIndex == index)
                _telephoneRecords.Add(new TelephoneRecord());

            if (Height == MinimumSize.Height)
                Height += 150;

            var telephoneRecord = _telephoneRecords[index];
            telephoneRecord.Fill(GetTelephoneRecord());

            GridViewState(_telephoneRecords.Count);
            ViewTelephoneRecord();

            ViewState();
            edTelephone.Focus();
            edTelephone.SelectAll();
        }

        private TelephoneRecord GetTelephoneRecord()
        {
            return new TelephoneRecord()
                       {
                           Telephone = stTelephone.Text,
                           Face = edTelephoneFace.Text,
                           Appendix = edTelephoneDescription.Text
                       };
        }

        private void btItemSave_Click(object sender, EventArgs e)
        {
            SaveTelephoneRecord();

            ViewState();
            edTelephone.Focus();
            edTelephone.SelectAll();
        }

        private void SaveTelephoneRecord()
        {
            var index = dbg.SelectedRows[0].Index;
            if (dbg.NewRowIndex == index)
                _telephoneRecords.Add(new TelephoneRecord());

            var telephoneRecord = _telephoneRecords[index];
            telephoneRecord.Fill(GetTelephoneRecord());

            GridViewState(index);
            ViewTelephoneRecord();
        }

        private void GridViewState(int index)
        {
            dbg.SelectionChanged -= dbg_SelectionChanged;

            try
            {
                dbg.DataSource = new BindingList<TelephoneRecord>(_telephoneRecords);
                dbg.Rows[index].Selected = true;
                try
                {
                    dbg.FirstDisplayedScrollingRowIndex = index;
                }
                catch { };
            }
            finally 
            {
                dbg.SelectionChanged += dbg_SelectionChanged;
            }

        }

        private void btItemMinus_Click(object sender, EventArgs e)
        {
            var index = dbg.SelectedRows[0].Index;

            _telephoneRecords.RemoveAt(index);

            if (index == _telephoneRecords.Count && index > 0)
                GridViewState(index - 1);
            else
                GridViewState(index);

            ViewTelephoneRecord();

            ViewState();
            edTelephone.Focus();
            edTelephone.SelectAll();
        }

        private void btItemCancel_Click(object sender, EventArgs e)
        {
            ViewTelephoneRecord();

            ViewState();
            edTelephone.Focus();
            edTelephone.SelectAll();
        }

        private void ViewTelephoneRecord()
        {
            var index = dbg.SelectedRows[0].Index;
            if (dbg.NewRowIndex == index)
                ViewTelephoneRecord(new TelephoneRecord());    
            else
                ViewTelephoneRecord(_telephoneRecords[index]);
        }

        private void ViewTelephoneRecord(TelephoneRecord telephoneRecord)
        {

            edTelephone.Text = telephoneRecord.Telephone;
            edTelephoneFace.Text = telephoneRecord.Face;
            edTelephoneDescription.Text = telephoneRecord.Appendix;
        }

        private void dbg_SelectionChanged(object sender, EventArgs e)
        {
            ViewTelephoneRecord();

            ViewState();
            edTelephone.Focus();
            edTelephone.SelectAll();

        }

        private void cbPerson_CheckedChanged(object sender, EventArgs e)
        {
            ViewState();
        }

        private void cbBuisiness_CheckedChanged(object sender, EventArgs e)
        {
            ViewState();
        }

        private void cbEmpty_CheckedChanged(object sender, EventArgs e)
        {
            ViewState();
        }

        public string CustomerName { get; set; }
        public string CustomerTelephone { get; set; }
        public string CustomerMainTelephone { get; set; }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (!cbEmpty.Checked)
            {
                SaveTelephoneRecord();
            }

            if (!Regex.IsMatch(GetContact(), _fullMask))
            {
                var balloon = CreateBalloon();
                balloon.ToolTipTitle = "Непривильный телефон";
                balloon.Show("Телефоны не прошли валидацию.", edTelephone);
                return;
            }

            var name = edName.Text.Trim().Substring(0, 1) +
                       edName.Text.Trim().Substring(1, edName.Text.Trim().Length - 1);

            if (IsSameName(name))
            {
                var balloon = CreateBalloon();
                balloon.ToolTipTitle = "Непривильное название";
                balloon.Show("Клиент с таким название уже существует в базе.", edName);
                return;
            }

            CustomerName = name;
            CustomerTelephone = GetContact();
            CustomerMainTelephone =
                _telephoneRecords.Any() ? _telephoneRecords.First().Telephone : null;

            DialogResult = DialogResult.OK;
        }

        private bool IsSameName(string name)
        {
            using (var dc = new ClientDataContext(_connectionString))
            {
                var filter = dc.Customers
                    .Where(customer =>
                        customer.ФИО.Trim().ToUpper() == name.ToUpper() &&
                        customer.Код != _customer.Код);
                return filter.Any();
            }
        }

        private static ToolTip CreateBalloon()
        {
            return new ToolTip
                       {
                           UseFading = true,
                           UseAnimation = true,
                           IsBalloon = true,
                           ShowAlways = true,
                           AutoPopDelay = 5000,
                           InitialDelay = 10000,
                           ReshowDelay = 500
                       };
        }

        private string GetContact()
        {
            string telephones;
            if (cbEmpty.Checked)
            {
                telephones = "<нет телефона>";
            }
            else
            {
                SaveTelephoneRecord();
                telephones = _telephoneRecords
                    .Select(rec =>
                            rec.Telephone +
                            (rec.Face == ""
                                 ? ""
                                 : String.Format(" ({0})", rec.Face)) +
                            (rec.Appendix == ""
                                 ? ""
                                 : String.Format(" /{0}/", rec.Appendix)))
                    .Aggregate("", (sum, curr) =>
                                   sum == "" ? curr : sum + ", " + curr);
            }

            return telephones +
                   (edEmail.Text == ""
                        ? ""
                        : String.Format(" [{0}]", edEmail.Text)) +
                   (edDescription.Text == ""
                        ? ""
                        : String.Format(" [{0}]", edDescription.Text));
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
