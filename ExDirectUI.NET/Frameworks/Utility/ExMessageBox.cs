using ExDirectUI.NET.Native;
using System;

namespace ExDirectUI.NET.Frameworks.Utility
{
    public class ExMessageBox
    {
        public static int Show(string sText, string sCaption = null, int uType = 0, int dwFlags = 0, IExBaseUIEle pOwner = null)
        {
            IntPtr hOwner = pOwner == null ? IntPtr.Zero : pOwner.Handle;
            return ExAPI.Ex_MessageBox(hOwner, sText, sCaption, uType, dwFlags);
        }

        public static int Show(IExBaseUIEle pOwner, string sText, string sCaption, int uType, int dwFlags)
        {
            IntPtr hOwner = pOwner == null ? IntPtr.Zero : pOwner.Handle;
            return ExAPI.Ex_MessageBox(hOwner, sText, sCaption, uType, dwFlags);
        }

        public static int Show(IExBaseUIEle pOwner, string sText, string sCaption, int uType, string sCheckbox, ref bool pfChecked, int dwTimeout, int dwFlags, ExWndProcDelegate pfnWndProc = null)
        {
            IntPtr hOwner = pOwner == null ? IntPtr.Zero : pOwner.Handle;
            return ExAPI.Ex_MessageBoxEx(hOwner, sText, sCaption, uType, sCheckbox, ref pfChecked, dwTimeout, dwFlags, pfnWndProc);
        }
    }
}
