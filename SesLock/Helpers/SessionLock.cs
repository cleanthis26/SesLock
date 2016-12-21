using System;
using System.Runtime.InteropServices;

namespace SesLock.Helpers
{
    public static class SessionLock
    {
        [DllImport("user32")]
        private static extern void LockWorkStation();

        [DllImport("wtsapi32.dll", SetLastError = true)]
        private static extern bool WTSDisconnectSession(IntPtr hServer, int sessionId, bool bWait);

        private const int WTS_CURRENT_SESSION = -1;
        private static readonly IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;

        public static void LockPc()
        {
            LockWorkStation();
        }
        
        public static void SwitchUser()
        {
            if (!WTSDisconnectSession(WTS_CURRENT_SERVER_HANDLE, WTS_CURRENT_SESSION, false))
            {
                // Error / Exception
            }
        }
    }
}
