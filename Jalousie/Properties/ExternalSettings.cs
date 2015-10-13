using System.Configuration;
using System.Diagnostics;

namespace Jalousie.Properties
{
    internal sealed partial class Settings
    {
        [UserScopedSetting()]
        [DebuggerNonUserCode()]
        [SpecialSetting(SpecialSetting.ConnectionString)]
        public string ShopConnectionString => ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString;

        [UserScopedSetting()]
        [DebuggerNonUserCode()]
        public string OutputPath
        {
            get { return ((string)(this["OutputPath"])); }
            set { this["OutputPath"] = value; }
        }

        [UserScopedSetting()]
        [DebuggerNonUserCode()]
        public string TemplatePath
        {
            get { return ((string)(this["TemplatePath"])); }
            set { this["TemplatePath"] = value; }
        }
    }
}
