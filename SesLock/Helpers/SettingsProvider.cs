using Microsoft.Win32;
using System;

namespace SesLock.Helpers
{
    public static class SettingsProvider
    {
        private static bool _IsStartupApplication;
        public static bool IsStartUpApplication
        {
            get { return _IsStartupApplication; }
            set
            {
                if (ConfigureStartupApplicationSettings(value))
                {
                    _IsStartupApplication = value;
                }
            }
        }

        private static bool ConfigureStartupApplicationSettings(bool SetStartupApp)
        {
            try
            {
                // Get the registry subkey
                RegistryKey startupRegistry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                var startupRegistryVal = startupRegistry.GetValue(Properties.Resources.RegistryKeyName);

                if (SetStartupApp)
                {
                    // Set/Update value (fix path in case it is incorrect)
                    startupRegistry.SetValue(Properties.Resources.RegistryKeyName, "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
                }
                else if (startupRegistryVal != null) // Set as false but exists, delete it
                {
                    startupRegistry.DeleteValue(Properties.Resources.RegistryKeyName);
                }
                startupRegistry.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void InitStartUpAppValue()
        {
            // Read current value from registry
            RegistryKey startupRegistry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
            var startupRegistryVal = startupRegistry.GetValue(Properties.Resources.RegistryKeyName);

            _IsStartupApplication = startupRegistryVal != null;
            ConfigureStartupApplicationSettings(_IsStartupApplication);
        }

        static SettingsProvider()
        {
            InitStartUpAppValue();
        }
    }
}
