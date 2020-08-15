using ExDirectUI.NET.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExDirectUI.NET.Frameworks
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



        #region MESSAGEBOX
        /** <summary>
         * 
         * </summary>
         **/
        public const int MB_OK = 0;

        /** <summary>
         * 
         * </summary>
         **/
        public const int MB_YESNO = 4;

        /** <summary>
         * 
         * </summary>
         **/
        public const int MB_YESNOCANCEL = 3;

        /** <summary>
         * 
         * </summary>
         **/
        public const int MB_OKCANCEL = 1;

        /** <summary>
         * 
         * </summary>
         **/
        public const int MB_ICONERROR = 16;

        /** <summary>
         * 
         * </summary>
         **/
        public const int MB_ICONWARNING = 48;

        /** <summary>
         * 
         * </summary>
         **/
        public const int MB_ICONQUESTION = 32;

        /** <summary>
         * 
         * </summary>
         **/
        public const int MB_ICONINFORMATION = 64;


        /** <summary>
         * 
         * </summary>
         **/
        public const int MB_TOPMOST = 262144;

        /** <summary>
         * 
         * </summary>
         **/
        public const int IDYES = 6;

        /** <summary>
         * 
         * </summary>
         **/
        public const int IDNO = 7;

        /** <summary>
         * 
         * </summary>
         **/
        public const int IDCANCEL = 2;

        /** <summary>
         * 
         * </summary>
         **/
        public const int IDOK = 1;

        /** <summary>
         * 
         * </summary>
         **/
        public const int IDCLOSE = 8;

        /** <summary>
         * 不显示菜单阴影
         * </summary>
         **/
        public const int EMNF_NOSHADOW = -2147483648;

        /** <summary>
         * 显示窗口图标
         * </summary>
         **/
        public const int EMBF_WINDOWICON = -2147483648;

        /** <summary>
         * 消息框居父窗口中间
         * </summary>
         **/
        public const int EMBF_CENTEWINDOW = 1073741824;

        /** <summary>
         * 显示倒计时
         * </summary>
         **/
        public const int EMBF_SHOWTIMEOUT = 536870912;


        #endregion

    }
}
