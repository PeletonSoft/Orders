using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace DataGridViewDictionaryElements
{

    public class DataGridViewDictionaryColumn : DataGridViewColumn
    {
        public DataGridViewDictionaryColumn()
            : base(new DataGridViewDictionaryCell())
        {
            Format = "{0}";
            DisplayFormat = "";
            DescriptionFormat = "";
            DataSource = null;
            ButtonVisible = true;
        }

        public override object Clone()
        {
            var col = (DataGridViewDictionaryColumn) base.Clone();
            col.DataSource = DataSource;
            col.DisplayMember = DisplayMember;
            col.ValueMember = ValueMember;
            col.DescriptionMember = DescriptionMember;
            col.MaxDropDownItems = MaxDropDownItems;
            col.DropDownDisplayWidth = DropDownDisplayWidth;
            col.DropDownDescriptionWidth = DropDownDescriptionWidth;
            col.DisplayFormat = DisplayFormat;
            col.DescriptionFormat = DescriptionFormat;
            col.Format = Format;
            col.ButtonVisible = ButtonVisible;
            return col;
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }

            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewDictionaryCell)))
                    throw new InvalidCastException("Cell type is not based upon the DataGridViewDictionaryCell.");
                base.CellTemplate = value;
            }
        }

        [Category("Data")]
        [Description("Indicates the source of data for the control.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(null)]
        [AttributeProvider(typeof (IListSource))]
        public object DataSource { get; set; }

        [Category("Data")]
        [DefaultValue("")]
        [Description("Indicates the display member of data for the control.")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        public string DisplayMember { get; set; }

        [Category("Data")]
        [DefaultValue("")]
        [Description("Indicates the selected member of data for the control.")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        public string ValueMember { get; set; }

        [Category("Data")]
        [DefaultValue("")]
        [Description("Indicates the description member of data for the control.")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        public string DescriptionMember { get; set; }

        [BrowsableAttribute(true)]
        [Category("DropDown")]
        public int MaxDropDownItems { get; set; }

        [BrowsableAttribute(true)]
        [Category("DropDown")]
        [DefaultValue(100)]
        public int DropDownDisplayWidth { get; set; }


        [BrowsableAttribute(true)]
        [Category("DropDown")]
        [DefaultValue(200)]
        public int DropDownDescriptionWidth { get; set; }


        [Category("Data")]
        [DefaultValue("")]
        public string DisplayFormat { get; set; }


        [Category("Data")]
        [DefaultValue("")]
        public string DescriptionFormat { get; set; }


        [Category("Data")]
        [DefaultValue("{0}")]
        public string Format { get; set; }


        [Category("Behavior")]
        [DefaultValue(true)]
        public bool ButtonVisible { get; set; }

    }
}
