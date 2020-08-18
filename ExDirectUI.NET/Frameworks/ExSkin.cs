using System;
using System.Text;
using ExDirectUI.NET.Native;

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




        #region EWS_
        /** <summary>
         * 窗体风格_关闭按钮
         * </summary>
         **/
        public const int EWS_BUTTON_CLOSE = 1;

        /** <summary>
         * 窗体风格_最大化按钮
         * </summary>
         **/
        public const int EWS_BUTTON_MAX = 2;

        /** <summary>
         * 窗体风格_最小化按钮
         * </summary>
         **/
        public const int EWS_BUTTON_MIN = 4;

        /** <summary>
         * 窗体风格_菜单按钮
         * </summary>
         **/
        public const int EWS_BUTTON_MENU = 8;

        /** <summary>
         * 窗体风格_皮肤按钮
         * </summary>
         **/
        public const int EWS_BUTTON_SKIN = 16;

        /** <summary>
         * 窗体风格_设置按钮
         * </summary>
         **/
        public const int EWS_BUTTON_SETTING = 32;

        /** <summary>
         * 窗体风格_帮助按钮
         * </summary>
         **/
        public const int EWS_BUTTON_HELP = 64;

        /** <summary>
         * 窗体风格_图标
         * </summary>
         **/
        public const int EWS_HASICON = 128;

        /** <summary>
         * 窗体风格_标题
         * </summary>
         **/
        public const int EWS_TITLE = 256;

        /** <summary>
         * 窗体风格_全屏模式.设置该标记窗口最大化时
         * </summary>
         **/
        public const int EWS_FULLSCREEN = 512;

        /** <summary>
         * 窗体风格_允许调整尺寸
         * </summary>
         **/
        public const int EWS_SIZEABLE = 1024;

        /** <summary>
         * 窗体风格_允许随意移动
         * </summary>
         **/
        public const int EWS_MOVEABLE = 2048;

        /** <summary>
         * 窗体风格_不显示窗口阴影
         * </summary>
         **/
        public const int EWS_NOSHADOW = 4096;

        /** <summary>
         * 窗体风格_不继承父窗口背景数据
         * </summary>
         **/
        public const int EWS_NOINHERITBKG = 8192;

        /** <summary>
         * 窗体风格_不显示TAB焦点边框
         * </summary>
         **/
        public const int EWS_NOTABBORDER = 16384;

        /** <summary>
         * 窗体风格_ESC关闭窗口
         * </summary>
         **/
        public const int EWS_ESCEXIT = 32768;

        /** <summary>
         * 窗体风格_主窗口(拥有该风格时
         * </summary>
         **/
        public const int EWS_MAINWINDOW = 65536;

        /** <summary>
         * 窗体风格_窗口居中(如果有父窗口
         * </summary>
         **/
        public const int EWS_CENTERWINDOW = 131072;

        /** <summary>
         * 窗体风格_标题栏取消置顶
         * </summary>
         **/
        public const int EWS_NOCAPTIONTOPMOST = 262144;

        /** <summary>
         * 窗体风格_弹出式窗口
         * </summary>
         **/
        public const int EWS_POPUPWINDOW = 524288;

        #endregion

        #region EWL_

        /** <summary>
         * 背景模糊
         * </summary>
         **/
        public const int EWL_BLUR = -2;

        /** <summary>
         * 窗口消息过程
         * </summary>
         **/
        public const int EWL_MSGPROC = -4;

        /** <summary>
         * 窗口透明度
         * </summary>
         **/
        public const int EWL_ALPHA = -5;

        /** <summary>
         * 自定义参数
         * </summary>
         **/
        public const int EWL_LPARAM = -7;

        /** <summary>
         * 边框颜色
         * </summary>
         **/
        public const int EWL_CRBORDER = -30;

        /** <summary>
         * 背景颜色
         * </summary>
         **/
        public const int EWL_CRBKG = -31;

        /** <summary>
         * 最小高度
         * </summary>
         **/
        public const int EWL_MINHEIGHT = -33;

        /** <summary>
         * 最小宽度
         * </summary>
         **/
        public const int EWL_MINWIDTH = -34;

        /** <summary>
         * 焦点组件组件
         * </summary>
         **/
        public const int EWL_OBJFOCUS = -53;

        /** <summary>
         * 标题栏组件句柄
         * </summary>
         **/
        public const int EWL_OBJCAPTION = -54;
        #endregion

        #region WM_EX_

        /** <summary>
         * XML属性分发回调(wParam->atomPropName
         * </summary>
         **/
        public const int WM_EX_XML_PROPDISPATCH = -1;

        /** <summary>
         * JS脚本分发回调(wParam->atomPropName
         * </summary>
         **/
        public const int WM_EX_JS_DISPATCH = -2;

        /** <summary>
         * 左键单击组件
         * </summary>
         **/
        public const int WM_EX_LCLICK = -3;

        /** <summary>
         * 右键单击组件
         * </summary>
         **/
        public const int WM_EX_RCLICK = -4;

        /** <summary>
         * 中键单击组件
         * </summary>
         **/
        public const int WM_EX_MCLICK = -5;

        /** <summary>
         * 弹出式窗口已经初始化完毕
         * </summary>
         **/
        public const int WM_EX_INITPOPUP = -6;

        /** <summary>
         * 弹出式窗口即将销毁 (wParam=0:即将销毁.wParam=1:是否可销毁
         * </summary>
         **/
        public const int WM_EX_EXITPOPUP = -7;

        /** <summary>
         * 发给控件用这个
         * </summary>
         **/
        public const int WM_EX_EASING = -8;

        #endregion



    }
}
