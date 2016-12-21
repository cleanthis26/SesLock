using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SesLock.Helpers
{
    public static class SingleAppHandler
    {
        private const string MUTEX_NAME = "SESLOCK_MUTEX";
        private static System.Threading.Mutex mutex;

        public static bool VerifyIsSingleApp() {
            bool result;
            mutex = new System.Threading.Mutex(true, MUTEX_NAME, out result);

            if (!result)
            {
                MessageBox.Show("Another instance of this application is already running.");
                Environment.Exit(0);
            }
            else
            {
                GC.KeepAlive(mutex);
            }

            return result;
        }

        public static void ClosingApp()
        {
            mutex.ReleaseMutex();
        }
    }
}
