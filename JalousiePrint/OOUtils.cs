using System;
using Microsoft.Win32;
using System.IO;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.util;
using System.Diagnostics;

namespace JalousiePrint
{
    class OOUtils
    {

        public static void InitOpenOfficeEnv()
        {
            var baseKey = "";

            baseKey = @"SOFTWARE\OpenOffice.org\";

            // Get the URE directory

            var key = baseKey + @"Layers\URE\1";
            var reg = Registry.CurrentUser.OpenSubKey(key);
            if (reg == null)
                reg = Registry.LocalMachine.OpenSubKey(key);
            var urePath = reg.GetValue("UREINSTALLLOCATION") as string;
            reg.Close();
            urePath = Path.Combine(urePath, "bin");

            // Get the UNO Path
            key = baseKey + @"UNO\InstallPath";
            reg = Registry.CurrentUser.OpenSubKey(key);
            if (reg == null)
                reg = Registry.LocalMachine.OpenSubKey(key);
            var unoPath = reg.GetValue(null) as string;
            reg.Close();

            var path = string.Format("{0};{1}", Environment.GetEnvironmentVariable("PATH"), urePath);
            Environment.SetEnvironmentVariable("PATH", path);
            Environment.SetEnvironmentVariable("UNO_PATH", unoPath);
            
        }

        public static void InitLibreOfficeEnv()
        {
            var baseKey = "";

            baseKey = @"SOFTWARE\LibreOffice\";

            // Get the URE directory

            var key = baseKey + @"Layers_\URE\1";
            var reg = Registry.CurrentUser.OpenSubKey(key);
            if (reg == null)
                reg = Registry.LocalMachine.OpenSubKey(key);
            var urePath = reg.GetValue("UREINSTALLLOCATION") as string;
            reg.Close();
            urePath = Path.Combine(urePath, "bin");

            // Get the UNO Path
            key = baseKey + @"UNO\InstallPath";
            reg = Registry.CurrentUser.OpenSubKey(key);
            if (reg == null)
                reg = Registry.LocalMachine.OpenSubKey(key);
            var unoPath = reg.GetValue(null) as string;
            reg.Close();

            var path = string.Format("{0};{1}", Environment.GetEnvironmentVariable("PATH"), urePath);
            Environment.SetEnvironmentVariable("PATH", path);
            Environment.SetEnvironmentVariable("UNO_PATH", unoPath);

        }
        public static void InitOO3Env()
        {
            try
            {
                //InitOpenOfficeEnv();
            }
            catch (Exception)
            {
            }

            try
            {
                InitLibreOfficeEnv();
            }
            catch (Exception)
            {
            }
        }

        public static string PathConverter(string file)
        {
            try
            {
                file = file.Replace(@"\", "/");
                return "file:///" + file;
            }

            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static XComponent OpenFile(
            XComponentLoader XComponentLoader, string FileName, 
            bool Hidden, bool ReadOnly)
        {
            var FileProperties = 
                new unoidl.com.sun.star.beans.PropertyValue[2];

            FileProperties[0] = new unoidl.com.sun.star.beans.PropertyValue() 
                                    { Name = "Hidden", Value = new uno.Any(Hidden) };
            FileProperties[1] = new unoidl.com.sun.star.beans.PropertyValue()
                                    { Name = "ReadOnly", Value = new uno.Any(ReadOnly) };


            return XComponentLoader.loadComponentFromURL(
                PathConverter(FileName),"_blank", 0, FileProperties);
        }

        public static void SaveFile(XStorable XStorable)
        {
            XStorable.store();
        }

        public static void CloseFile(XCloseable XCloseable)
        {
            XCloseable.close(true);
        }

        public static void CloseDesktop(XDesktop XDesktop)
        {
            if (!XDesktop.getComponents().createEnumeration().hasMoreElements())
                XDesktop.terminate();

        }
        public static void ViewFile(string FileName)
        {
            Process.Start("soffice", 
                String.Format("-norestore -nodefault -view \"{0:G}\" -nologo",FileName));
        }
    }
}
