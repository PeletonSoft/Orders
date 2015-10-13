using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewDictionaryElements
{
    public partial class DictionaryComboBox
    {
        public DictionaryComboBox()
        {
            InitializeComponent();
            Format = "{0}";
            DisplayFormat = "";
            DescriptionFormat = "";
            ButtonVisible = true;
        }

        private string descriptionMember;
        private int dropDownDisplayWidth = 100;
        private int dropDownDescriptionWidth = 200;

        private string displayText(DataRow row)
        {
            return dropDownDisplayWidth > 0 &&
                   !String.IsNullOrEmpty(DisplayMember)
                       ? String.Format("{0:" + DisplayFormat + "}", row[DisplayMember])
                       : "";
        }

        private string descriptionText(DataRow row)
        {
            return dropDownDescriptionWidth > 0 &&
                   !String.IsNullOrEmpty(DescriptionMember)
                       ? String.Format("{0:" + DescriptionFormat + "}", row[DescriptionMember])
                       : "";
        }

        private string getText(DataRow row)
        {
            return String.IsNullOrEmpty(DescriptionMember)
                       ? String.Format(Format, row[DisplayMember])
                       : String.Format(Format, row[DisplayMember], row[DescriptionMember]);
        }

        public override string Text
        {
            get
            {
                return
                    (ComboBoxValue.SelectedItem as DataRowView) != null
                        ? getText((ComboBoxValue.SelectedItem as DataRowView).Row)
                        : "";
            }
        }

        [Category("Data")]
        [Description("Indicates the source of data for the control.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue((string)null)]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get
            {
                return ComboBoxValue.DataSource;
            }

            set
            {
                ComboBoxValue.DataSource = value;
            }
        }

        [Category("Data")]
        [DefaultValue("")]
        [Description("Indicates the display member of data for the control.")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        public string DisplayMember
        {
            get
            {
                return (ComboBoxValue.DisplayMember);
            }
            set
            {
                ComboBoxValue.DisplayMember = value;
            }
        }

        [Category("Data")]
        [DefaultValue("")]
        [Description("Indicates the selected member of data for the control.")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        public string ValueMember
        {
            get
            {
                return ComboBoxValue.ValueMember;
            }
            set
            {
                ComboBoxValue.ValueMember = value;
            }
        }

        [Category("Data")]
        [DefaultValue("")]
        [Description("Indicates the description member of data for the control.")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        public string DescriptionMember
        {
            get
            {
                return (descriptionMember);
            }
            set
            {
                descriptionMember = value;
            }
        }

        [BrowsableAttribute(true)]
        [Category("DropDown")]
        public int MaxDropDownItems
        {
            get
            {
                return ComboBoxValue.MaxDropDownItems;
            }
            set
            {
                ComboBoxValue.MaxDropDownItems = value > 5 ? value : 5;
            }
        }

        [BrowsableAttribute(true)]
        [Category("DropDown")]
        [DefaultValue(100)]
        public int DropDownDisplayWidth
        {
            get
            {
                return dropDownDisplayWidth;
            }
            set
            {
                dropDownDisplayWidth = value > 0 ? value : 0;
                ComboBoxValue.DropDownWidth = dropDownDisplayWidth+dropDownDescriptionWidth;
            }
        }

        [Category("Data")]
        [DefaultValue("")]
        public string DisplayFormat { get; set; }

        [Category("Data")]
        [DefaultValue("")]
        public string DescriptionFormat { get; set; }

        [Category("Data")]
        [DefaultValue("{0}")]
        public string Format { get; set; }

        [BrowsableAttribute(true)]
        [Category("DropDown")]
        [DefaultValue(200)]
        public int DropDownDescriptionWidth
        {
            get
            {
                return dropDownDescriptionWidth;
            }
            set
            {
                dropDownDescriptionWidth = value>0 ? value : 0;
                ComboBoxValue.DropDownWidth = dropDownDisplayWidth + dropDownDescriptionWidth;
            }
        }

        [Category("Behavior")]
        public event EventHandler SelectedIndexChanged;

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool ButtonVisible
        {
            get
            {
                return SelectButton.Visible;
            }
            set
            {
                SelectButton.Visible = value;
                ComboBoxValue.Width =
                    Width - (value ? SelectButton.Width : 0);

            }
        }
        [BrowsableAttribute(false)]
        public int SelectedIndex
        {
            get
            {
                return ComboBoxValue.SelectedIndex;
            }
            set
            {
                ComboBoxValue.SelectedIndex = value;
            }
        }

        [BrowsableAttribute(false)]
        [BindableAttribute(true)]
        public object SelectedItem
        {
            get
            {
                return ComboBoxValue.SelectedItem;
            }
            set
            {
                ComboBoxValue.SelectedItem = value;
            }
        }

        [BrowsableAttribute(false)]
        public string SelectedText
        {
            get
            {
                return ComboBoxValue.SelectedText;
            }
            set
            {
                ComboBoxValue.SelectedText = value;
            }
        }

        [BrowsableAttribute(false)]
        [BindableAttribute(true)]
        [DefaultValue(null)]
        public object SelectedValue
        {
            get
            {
                return ComboBoxValue.SelectedValue;
            }
            set
            {
                ComboBoxValue.SelectedValue = value;
            }
        }


        private void DictionaryComboBox_SizeChanged(object sender, EventArgs e)
        {
            SelectButton.Height = ComboBoxValue.Height;
            Height = ComboBoxValue.Height;
            //Refresh();
        }

        public virtual void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, e);
        }
        private void ComboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedIndexChanged(e);
        }

        private void ComboBoxValue_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || ComboBoxValue.DataSource == null)
                return;

            var TargetDisplayWidth = dropDownDisplayWidth > 0 &&
                                     !String.IsNullOrEmpty(DescriptionMember) &&
                                     dropDownDescriptionWidth > 0
                                         ? dropDownDisplayWidth
                                         : ComboBoxValue.DropDownWidth;
            var TargetDecriptionWidth = ComboBoxValue.DropDownWidth - TargetDisplayWidth;

            var rec = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            var NormalText = new SolidBrush(ComboBoxValue.ForeColor);

            var currentRow = ComboBoxValue.Items[e.Index] as DataRowView;
            if (currentRow == null)
                return;
            
            var row = currentRow.Row;
            var normalBack = new SolidBrush(ComboBoxValue.BackColor); 
            e.Graphics.FillRectangle(normalBack, rec);


            if (ComboBoxValue.DroppedDown)
            {
                var HightlightedBack = new SolidBrush(SystemColors.Highlight);
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e.Graphics.FillRectangle(HightlightedBack, rec);

                if (TargetDisplayWidth > 0 && TargetDecriptionWidth > 0)
                {
                    var gridBrush = new SolidBrush(SystemColors.ActiveBorder);
                    var first = new Point(rec.Left + dropDownDisplayWidth, rec.Top);
                    var last = new Point(rec.Left + dropDownDisplayWidth, rec.Bottom);
                    e.Graphics.DrawLine(new Pen(gridBrush), first, last);
                }

                var DisplayText = displayText(row);
                var DisplaySize = e.Graphics.MeasureString(DisplayText, e.Font);
                var DisplayWidth = (decimal)DisplaySize.Width;
                var TextDisplayRec = new Rectangle(rec.X, rec.Y, 
                    (int)decimal.Ceiling(DisplayWidth), rec.Height);

                var DecriptionText = descriptionText(row);
                var DecriptionSize = e.Graphics.MeasureString(DecriptionText, e.Font);
                var DecriptionWidth = (decimal)DecriptionSize.Width;
                var TextDecriptionRec = new Rectangle(rec.X + TargetDisplayWidth, rec.Y,
                    (int)decimal.Ceiling(DecriptionWidth), rec.Height);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    var HightlightedText = new SolidBrush(SystemColors.HighlightText);
                    if (TargetDisplayWidth > 0)
                    {
                        e.Graphics.FillRectangle(HightlightedBack, rec.X, rec.Y,
                                                 TargetDisplayWidth - 1, DecriptionSize.Height);
                        e.Graphics.DrawString(DisplayText, e.Font, HightlightedText, TextDisplayRec);
                    }
                    if (TargetDecriptionWidth > 0)
                    {
                        e.Graphics.FillRectangle(HightlightedBack, rec.X + TargetDisplayWidth + 1, rec.Y,
                                                 TargetDecriptionWidth - 1, DecriptionSize.Height);
                        e.Graphics.DrawString(DecriptionText, e.Font, HightlightedText, TextDecriptionRec);
                    }

                }
                else
                {
                    if (TargetDisplayWidth > 0)
                    {

                        e.Graphics.FillRectangle(normalBack, rec.X, rec.Y,
                                                 TargetDisplayWidth - 1, DecriptionSize.Height);
                        e.Graphics.DrawString(DisplayText, e.Font, NormalText, TextDisplayRec);
                    }
                    if (TargetDecriptionWidth > 0)
                    {
                        e.Graphics.FillRectangle(normalBack, rec.X + TargetDisplayWidth + 1, rec.Y,
                                                 TargetDecriptionWidth - 1, DecriptionSize.Height);
                        e.Graphics.DrawString(DecriptionText, e.Font, NormalText, TextDecriptionRec);
                    }
                }
            }
            else
            {
                e.Graphics.DrawString(getText(row), e.Font, NormalText, rec);    
            }


        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            var CurrBS = DataSource as BindingSource;
            if (CurrBS == null)
                return;
            var f = new DictionaryFormSelect
                        {
                            Width = ComboBoxValue.DropDownWidth + 20,
                            GridView = {AutoGenerateColumns = false},
                            BindingSource =
                                {
                                    DataSource = CurrBS.DataSource,
                                    DataMember = CurrBS.DataMember,
                                    Sort = CurrBS.Sort,
                                    Position = CurrBS.Position,
                                    Filter = CurrBS.Filter
                                }
                        };

            f.Filter = String.IsNullOrEmpty(CurrBS.Filter) ? "1=1" : CurrBS.Filter;
            f.Display.DataPropertyName = DisplayMember;
            f.Display.DefaultCellStyle.Format = DisplayFormat;
            f.Display.Visible = dropDownDisplayWidth > 0 &&
                                !String.IsNullOrEmpty(DisplayMember);
            f.Display.Width = dropDownDescriptionWidth > 0
                                         ? dropDownDisplayWidth
                                         : ComboBoxValue.DropDownWidth;

            f.Description.DataPropertyName = DescriptionMember;
            f.Description.DefaultCellStyle.Format = DescriptionFormat;
            f.Description.Visible = dropDownDescriptionWidth > 0 &&
                                !String.IsNullOrEmpty(DescriptionMember);
            if (f.ShowDialog() != DialogResult.OK)
                return;
            if ((f.BindingSource.Current as DataRowView)==null)
                return;
            ComboBoxValue.SelectedValue =
                (f.BindingSource.Current as DataRowView).Row[ValueMember];
        }

    }
}
