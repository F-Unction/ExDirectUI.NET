using System;
using System.Text;
using ExDirectUI.NET.Native;
using ExDirectUI.NET.Frameworks.Controls;

namespace ExDirectUI.NET.Frameworks
{
    public class ExSkin : ExWindow, IExBaseUIEle
    {

        public ExSkin(ExSkin pOwner, string sClassName, string sWindowName, int x, int y, int nWidth, int nHeight, int dwStyleDUI,
            int dwStyle = 0, int dwStyleEx = 0, int hTheme = 0, ExWndProcDelegate pfnWndProc = null)
        {
            IntPtr hWndParent = pOwner == null ? IntPtr.Zero : pOwner.Handle;
            m_hWnd = ExWindow.Create(hWndParent, sClassName, sWindowName, x, y, nWidth, nHeight, dwStyle, dwStyleEx);
            if (m_hWnd != IntPtr.Zero)
            {
                m_hExDUI = ExAPI.Ex_DUIBindWindowEx(m_hWnd, (IntPtr)hTheme, dwStyleDUI, 0, pfnWndProc);
                if(m_hExDUI != IntPtr.Zero)
                {

                }
                else throw new ExException(ExStatus.HANDLE_INVALID, "绑定皮肤失败");
            }
            else throw new ExException(ExStatus.HANDLE_INVALID, "创建窗口失败");
        }

        public ExSkin(ExWindow pWindow, int dwStyleDUI, int hTheme = 0, ExWndProcDelegate pfnWndProc = null)
        {
            m_hExDUI = ExAPI.Ex_DUIBindWindowEx(pWindow.WindowHandle, (IntPtr)hTheme, dwStyleDUI, 0, pfnWndProc);
            if (m_hExDUI != IntPtr.Zero)
            {

            }
            else throw new ExException(ExStatus.HANDLE_INVALID, "绑定皮肤失败");
        }

        public ExSkin(ExSkin pOwner, byte[] pLayout, int hTheme = 0)
        {
            IntPtr hWndParent = pOwner == null ? IntPtr.Zero : pOwner.Handle;
            if(ExAPI.Ex_DUICreateFromLayout(hWndParent, (IntPtr)hTheme, pLayout, pLayout.Length, out m_hWnd, out m_hExDUI))
            {

            }
            else throw new ExException(ExStatus.HANDLE_INVALID, "绑定皮肤失败");
        }
        
        public ExSkin(IntPtr hWnd, IntPtr hExDUI)
        {
            m_hWnd = hWnd;
            m_hExDUI = hExDUI;
        }


        public bool Enable { get => WinAPI.IsWindowEnable(m_hWnd); set => WinAPI.EnableWindow(m_hWnd, value); }
        public bool Visible { get => WinAPI.IsWindowVisible(m_hWnd); set => ExAPI.Ex_DUIShowWindow(m_hExDUI, value ? 1 : 0, 0, 0, 0); }

        protected IntPtr m_hExDUI;
        public IntPtr Handle => m_hExDUI;

        public bool Validate => WinAPI.IsWindow(m_hWnd) && m_hExDUI != IntPtr.Zero;

        public string Text {
            get
            {
                int cch = WinAPI.GetWindowTextLength(m_hWnd);
                StringBuilder sb = new StringBuilder(cch);
                WinAPI.GetWindowText(m_hWnd, sb, cch + 1);
                return sb.ToString();
            }
            set
            {
                WinAPI.SetWindowText(m_hWnd, value, true);
            }
        }

        public bool GetBackgroundImage(out ExBackgroundImageInfo pImageInfo)
        {
            return ExAPI.Ex_ObjGetBackgroundImage(m_hExDUI, out pImageInfo);
        }

        public int GetLong(int nIndex)
        {
            return ExAPI.Ex_DUIGetLong(m_hExDUI, nIndex);
        }

        public bool Move(int x, int y, int nWidth, int nHeight, bool fRedraw = true)
        {
            return WinAPI.MoveWindow(m_hWnd, x, y, nWidth, nHeight, fRedraw);
        }

        public bool PostMessage(int uMsg, int wParam = 0, int lParam = 0)
        {
            return WinAPI.PostMessage(m_hWnd, uMsg, wParam, lParam);
        }

        public int SendMessage(int uMsg, int wParam = 0, int lParam = 0)
        {
            return WinAPI.SendMessage(m_hWnd, uMsg, wParam, lParam);
        }

        public bool SetBackgroundImage(byte[] image, int x, int y, int dwRepeat, IntPtr rcGrids, int dwFlags, int dwAlpha, bool fUpdate)
        {
            return ExAPI.Ex_ObjSetBackgroundImage(m_hExDUI, image, image.Length, x, y, dwRepeat, rcGrids, dwFlags, dwAlpha, fUpdate);
        }

        public bool SetBackgroundPlayState(bool fPlayFrames, bool fResetFrame, bool fUpdate)
        {
            return ExAPI.Ex_ObjSetBackgroundPlayState(m_hExDUI, fPlayFrames, fResetFrame, fUpdate);
        }

        public int SetLong(int nIndex, int nValue)
        {
            return ExAPI.Ex_DUISetLong(m_hExDUI, nIndex, nValue);
        }

        public bool SetPos(int x, int y, int nWidth, int nHeight, IntPtr hEleAfter, int dwFlags)
        {
            return WinAPI.SetWindowPos(m_hWnd, hEleAfter, x, y, nWidth, nHeight, dwFlags);
        }

        public ExControl GetObjFromID(int id)
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjGetFromID(m_hExDUI, id);
            if(hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public ExControl GetObjFromName(string name)
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjGetFromName(m_hExDUI, name);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public ExControl GetObjFromNodeID(int nodeid)
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjGetFromNodeID(m_hExDUI, nodeid);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public ExControl GetFocus()
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjGetFocus(m_hExDUI);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public bool TrackPopupMenu(IntPtr hMenu, int uFlags, int x, int y, int nReserved, ref ExRect pRc, ExWndProcDelegate pfnWndProc, int dwFlags)
        {
            return ExAPI.Ex_TrackPopupMenu(hMenu, uFlags, x, y, nReserved, m_hExDUI, ref pRc, pfnWndProc, dwFlags);
        }

        public bool LoadLayoutXml(byte[] pLayout, IntPtr hRes)
        {
            return ExAPI.Ex_ObjLoadFromLayout(m_hExDUI, hRes, pLayout, pLayout.Length);
        }

        public ExControl Find(ExControl pObjChildAfter = null, string sClassName = null, string sTitle = null)
        {
            IntPtr hObjAfter = pObjChildAfter == null ? IntPtr.Zero : pObjChildAfter.Handle;
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjFind(m_hExDUI, hObjAfter, sClassName, sTitle);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }
    }
}
