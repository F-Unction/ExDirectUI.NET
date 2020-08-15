using System;
using System.Collections.Generic;
using System.Text;
using ExDirectUI.NET.Native;

namespace ExDirectUI.NET.Frameworks
{
    public class ExControl : IExBaseUIEle, IDisposable
    {
        public ExControl(IExBaseUIEle oParent, string sClassName, string sTitle, int x, int y, int nWidth, int nHeight,
            int dwStyle = -1, int dwStyleEx = -1, int dwTextFormat = -1, int nID = 0, int hTheme = 0, ExObjProcDelegate pfnObjProc = null)
        {
            m_hObj = ExAPI.Ex_ObjCreateEx(dwStyleEx, sClassName, sTitle, dwStyle, x, y, nWidth, nHeight, oParent.Handle, nID, dwTextFormat, 0, (IntPtr)hTheme, pfnObjProc);
            if (m_hObj != IntPtr.Zero)
            {

            }
            else throw new ExException(ExStatus.HANDLE_INVALID, "创建控件失败");
        }

        public ExControl(IntPtr hObj)
        {
            m_hObj = hObj;
        }

        public void Dispose()
        {
            ExAPI.Ex_ObjDestroy(m_hObj);
            m_hObj = IntPtr.Zero;
        }


        public bool Validate => ExAPI.Ex_ObjIsValidate(m_hObj);

        public bool Visible { get => ExAPI.Ex_ObjIsVisible(m_hObj); set => ExAPI.Ex_ObjShow(m_hObj, value); }
        public bool Enable { get => ExAPI.Ex_ObjIsEnable(m_hObj); set => ExAPI.Ex_ObjEnable(m_hObj, value); }

        protected IntPtr m_hObj;
        public IntPtr Handle => m_hObj;

        public ExRect Rect
        {
            get
            {
                ExRect rc;
                ExAPI.Ex_ObjGetRect(m_hObj, out rc);
                return rc;
            }
            set => ExAPI.Ex_ObjMove(m_hObj, value.nLeft, value.nTop, value.nRight - value.nLeft, value.nBottom - value.nTop, true);
        }

        public ExRect Client
        {
            get
            {
                ExRect rc;
                ExAPI.Ex_ObjGetClientRect(m_hObj, out rc);
                return rc;
            }
        }

        public string Text
        {
            get
            {
                int cch = ExAPI.Ex_ObjGetTextLength(m_hObj);
                StringBuilder sb = new StringBuilder(cch);
                ExAPI.Ex_ObjGetText(m_hObj, sb, cch * 2 + 2);
                sb.Length = cch;
                return sb.ToString();
            }
            set
            {
                ExAPI.Ex_ObjSetText(m_hObj, value, true);
            }
        }


        public string ClassName { get => null; }

        public bool GetBackgroundImage(out ExBackgroundImageInfo pImageInfo)
        {
            return ExAPI.Ex_ObjGetBackgroundImage(m_hObj, out pImageInfo);
        }

        public int GetLong(int nIndex)
        {
            return ExAPI.Ex_ObjGetLong(m_hObj, nIndex);
        }

        public bool Move(int x, int y, int nWidth, int nHeight, bool fRedraw = true)
        {
            return ExAPI.Ex_ObjMove(m_hObj, x, y, nWidth, nHeight, fRedraw);
        }

        public bool PostMessage(int uMsg, int wParam = 0, int lParam = 0)
        {
            return ExAPI.Ex_ObjPostMessage(m_hObj, uMsg, wParam, lParam);
        }

        public int SendMessage(int uMsg, int wParam = 0, int lParam = 0)
        {
            return ExAPI.Ex_ObjSendMessage(m_hObj, uMsg, wParam, lParam);
        }

        public bool SetBackgroundImage(byte[] image, int x, int y, int dwRepeat, IntPtr rcGrids, int dwFlags, int dwAlpha, bool fUpdate)
        {
            return ExAPI.Ex_ObjSetBackgroundImage(m_hObj, image, image.Length, x, y, dwRepeat, rcGrids, dwFlags, dwAlpha, fUpdate);
        }

        public bool SetBackgroundPlayState(bool fPlayFrames, bool fResetFrame, bool fUpdate)
        {
            return ExAPI.Ex_ObjSetBackgroundPlayState(m_hObj, fPlayFrames, fResetFrame, fUpdate);
        }

        public int SetLong(int nIndex, int nValue)
        {
            return ExAPI.Ex_ObjSetLong(m_hObj, nIndex, nValue);
        }

        public bool SetPos(int x, int y, int nWidth, int nHeight, IntPtr hEleAfter, int dwFlags)
        {
            return ExAPI.Ex_ObjSetPos(m_hObj, hEleAfter, x, y, nWidth, nHeight, dwFlags);
        }
        public ExControl GetObjFromID(int id)
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjGetFromID(m_hObj, id);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public ExControl GetObjFromName(string name)
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjGetFromName(m_hObj, name);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public ExControl GetObjFromNodeID(int nodeid)
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjGetFromNodeID(m_hObj, nodeid);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public bool CanRedraw(bool fRedarw)
        {
            return ExAPI.Ex_ObjSetRedraw(m_hObj, fRedarw);
        }

        public bool HandleEvent(int nCode, ExObjEventProcDelegate pfnEvent)
        {
            return ExAPI.Ex_ObjHandleEvent(m_hObj, nCode, pfnEvent);
        }

        public int GetColor(int nIndex)
        {
            return ExAPI.Ex_ObjGetColor(m_hObj, nIndex);
        }

        public int SetColor(int nIndex, int nColor, bool fRedraw = true)
        {
            return ExAPI.Ex_ObjSetColor(m_hObj, nIndex, nColor, fRedraw);
        }

        public bool BeginPaint(out ExPaintStruct ps)
        {
            return ExAPI.Ex_ObjBeginPaint(m_hObj, out ps);
        }

        public bool EndPaint(ref ExPaintStruct ps)
        {
            return ExAPI.Ex_ObjEndPaint(m_hObj, ref ps);
        }

        public ExControl GetFocus()
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjGetFocus(m_hObj);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public bool KillFocus()
        {
            return ExAPI.Ex_ObjKillFocus(m_hObj);
        }

        public bool TrackPopupMenu(IntPtr hMenu, int uFlags, int x, int y, int nReserved, ref ExRect pRc, ExWndProcDelegate pfnWndProc, int dwFlags)
        {
            return ExAPI.Ex_TrackPopupMenu(hMenu, uFlags, x, y, nReserved, m_hObj, ref pRc, pfnWndProc, dwFlags);
        }

        public bool LoadLayoutXml(byte[] pLayout, IntPtr hRes)
        {
            return ExAPI.Ex_ObjLoadFromLayout(m_hObj, hRes, pLayout, pLayout.Length);
        }

        public static ExControl GetObjFromPoint(int x, int y, IntPtr hParent)
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_DUIGetObjFromPoint(hParent, x, y);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public IntPtr SubClass(ExObjProcDelegate pfnObjProc)
        {

            return ExAPI.Ex_ObjSetLong(m_hObj, ExControl.EOL_OBJPROC, pfnObjProc);
        }

        public static int CallProc(IntPtr pfnObjProc, IntPtr hWnd, IntPtr hObj, int uMsg, int wParam, int lParam, IntPtr pvData)
        {
            return ExAPI.Ex_ObjCallProc(pfnObjProc, hWnd, hObj, uMsg, wParam, lParam, pvData);
        }

        public static int CallDefProc(IntPtr hWnd, IntPtr hObj, int uMsg, int wParam, int lParam)
        {
            return ExAPI.Ex_ObjDefProc(hWnd, hObj, uMsg, wParam, lParam);
        }

        public int DispatchMessage(int uMsg, int wParam, int lParam)
        {
            return ExAPI.Ex_ObjDispatchMessage(m_hObj, uMsg, wParam, lParam);
        }

        public int DispatchNotify(int nCode, int wParam, int lParam)
        {
            return ExAPI.Ex_ObjDispatchNotify(m_hObj, nCode, wParam, lParam);
        }

        public bool ClientToScreen(ref int x, ref int y)
        {
            return ExAPI.Ex_ObjClientToScreen(m_hObj, ref x, ref y);
        }

        public bool ClientToWindow(ref int x, ref int y)
        {
            return ExAPI.Ex_ObjClientToWindow(m_hObj, ref x, ref y);
        }

        public bool Invalidate()
        {
            return ExAPI.Ex_ObjInvalidateRect(m_hObj, IntPtr.Zero);
        }

        public bool Invalidate(ExRect rc)
        {
            return ExAPI.Ex_ObjInvalidateRect(m_hObj, ref rc);
        }

        public ExControl Find(ExControl pObjChildAfter = null, string sClassName = null, string sTitle = null)
        {
            IntPtr hObjAfter = pObjChildAfter == null ? IntPtr.Zero : pObjChildAfter.Handle;
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjFind(m_hObj, hObjAfter, sClassName, sTitle);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public ExControl GetObj(int nCmd)
        {
            ExControl ctrl = null;
            IntPtr hObj = ExAPI.Ex_ObjGetObj(m_hObj, nCmd);
            if (hObj != IntPtr.Zero)
            {
                ctrl = new ExControl(hObj);
            }
            return ctrl;
        }

        public bool EnumChild(ExObjEnumCallbackDelegate pfnEnum, int lParam)
        {
            return ExAPI.Ex_ObjEnumChild(m_hObj, pfnEnum, lParam);
        }

        public bool PopupTips(string sText, string sTitle = null, int x = -1, int y = -1, int nTime = -1, int nIcon = 0, bool fShow = false)
        {
            return ExAPI.Ex_ObjTooltipsPopEx(m_hObj, sText, sTitle, x, y, nTime, nIcon, fShow);
        }

        private int m_nTimer = 0;
        public int Timer
        {
            get => m_nTimer;
            set
            {
                if (value <= 0)
                {
                    ExAPI.Ex_ObjKillTimer(m_hObj);
                    m_nTimer = 0;
                }
                else
                {
                    if (m_nTimer != 0)
                        ExAPI.Ex_ObjKillTimer(m_hObj);
                    ExAPI.Ex_ObjSetTimer(m_hObj, value);
                    m_nTimer = value;
                }
            }
        }

        public bool InitPropList(int nPropCount)
        {
            return ExAPI.Ex_ObjInitPropList(m_hObj, nPropCount);
        }

        public int GetProp(int nKey)
        {
            return ExAPI.Ex_ObjGetProp(m_hObj, nKey);
        }

        public int SetProp(int nKey, int nValue)
        {
            return ExAPI.Ex_ObjSetProp(m_hObj, nKey, nValue);
        }

        public int RemoveProp(int nKey)
        {
            return ExAPI.Ex_ObjRemoveProp(m_hObj, nKey);
        }

        public int EnumProps(ExObjPropEnumCallbackDelegate pfnEnum, int lParam)
        {
            return ExAPI.Ex_ObjEnumProps(m_hObj, pfnEnum, lParam);
        }

        public bool SetFont(string sName = null, int nSize = -1, int dwStyle = -1,bool fRedraw = true)
        {
            return ExAPI.Ex_ObjSetFontFromFamily(m_hObj, sName, nSize, dwStyle, fRedraw);
        }

        public void PointTransform(ExControl pObjDest,ref int x,ref int y)
        {
            IntPtr hObj = pObjDest == null ? IntPtr.Zero : pObjDest.Handle;
            ExAPI.Ex_ObjPointTransform(m_hObj, hObj, ref x, ref y);
        }




        #region NM_
        /** <summary>
         * 事件_创建
         * </summary>
         **/
        public const int NM_CREATE = -99;

        /** <summary>
         * 事件_销毁
         * </summary>
         **/
        public const int NM_DESTROY = -98;

        /** <summary>
         * 事件_计算尺寸
         * </summary>
         **/
        public const int NM_CALCSIZE = -97;

        /** <summary>
         * 事件_鼠标移动
         * </summary>
         **/
        public const int NM_MOVE = -96;

        /** <summary>
         * 事件_尺寸被改变
         * </summary>
         **/
        public const int NM_SIZE = -95;

        /** <summary>
         * 事件_禁止状态被改变
         * </summary>
         **/
        public const int NM_ENABLE = -94;

        /** <summary>
         * 事件_可视状态被改变
         * </summary>
         **/
        public const int NM_SHOW = -93;

        /** <summary>
         * 事件_左键被放开
         * </summary>
         **/
        public const int NM_LUP = -92;

        /** <summary>
         * 事件_离开组件
         * </summary>
         **/
        public const int NM_LEAVE = -91;

        /** <summary>
         * 事件_时钟
         * </summary>
         **/
        public const int NM_TIMER = -90;

        /** <summary>
         * 事件_选中
         * </summary>
         **/
        public const int NM_CHECK = -89;

        /** <summary>
         * 事件_托盘图标
         * </summary>
         **/
        public const int NM_TRAYICON = -88;

        /** <summary>
         * 事件_对话框初始化完毕
         * </summary>
         **/
        public const int NM_INTDLG = -87;

        /** <summary>
         * 事件_缓动
         * </summary>
         **/
        public const int NM_EASING = -86;

        /** <summary>
         * 事件_左键被单击
         * </summary>
         **/
        public const int NM_CLICK = -2;

        /** <summary>
         * 事件_左键被双击
         * </summary>
         **/
        public const int NM_DBLCLK = -3;

        /** <summary>
         * 事件_回车键被按下
         * </summary>
         **/
        public const int NM_RETURN = -4;

        /** <summary>
         * 事件_右键被单击
         * </summary>
         **/
        public const int NM_RCLICK = -5;

        /** <summary>
         * 事件_右键被双击
         * </summary>
         **/
        public const int NM_RDBLCLK = -6;

        /** <summary>
         * 事件_设置焦点
         * </summary>
         **/
        public const int NM_SETFOCUS = -7;

        /** <summary>
         * 事件_失去焦点
         * </summary>
         **/
        public const int NM_KILLFOCUS = -8;

        /** <summary>
         * 事件_自定义绘制
         * </summary>
         **/
        public const int NM_CUSTOMDRAW = -12;

        /** <summary>
         * 事件_进入组件
         * </summary>
         **/
        public const int NM_HOVER = -13;

        /** <summary>
         * 事件_点击测试
         * </summary>
         **/
        public const int NM_NCHITTEST = -14;

        /** <summary>
         * 事件_按下某键
         * </summary>
         **/
        public const int NM_KEYDOWN = -15;

        /** <summary>
         * 事件_取消鼠标捕获
         * </summary>
         **/
        public const int NM_RELEASEDCAPTURE = -16;

        /** <summary>
         * 事件_字符输入
         * </summary>
         **/
        public const int NM_CHAR = -18;

        /** <summary>
         * 事件_提示框即将弹出
         * </summary>
         **/
        public const int NM_TOOLTIPSCREATED = -19;

        /** <summary>
         * 事件_左键被按下
         * </summary>
         **/
        public const int NM_LDOWN = -20;

        /** <summary>
         * 事件_右键被按下
         * </summary>
         **/
        public const int NM_RDOWN = -21;

        /** <summary>
         * 事件_字体被改变
         * </summary>
         **/
        public const int NM_FONTCHANGED = -23;


        #endregion

        #region COLOR_EX
        /** <summary>
         * 背景颜色
         * </summary>
         **/
        public const int COLOR_EX_BACKGROUND = 0;

        /** <summary>
         * 边框颜色
         * </summary>
         **/
        public const int COLOR_EX_BORDER = 1;

        /** <summary>
         * 文本颜色.正常
         * </summary>
         **/
        public const int COLOR_EX_TEXT_NORMAL = 2;

        /** <summary>
         * 文本颜色.点燃
         * </summary>
         **/
        public const int COLOR_EX_TEXT_HOVER = 3;

        /** <summary>
         * 文本颜色.按下
         * </summary>
         **/
        public const int COLOR_EX_TEXT_DOWN = 4;

        /** <summary>
         * 文本颜色.焦点
         * </summary>
         **/
        public const int COLOR_EX_TEXT_FOCUS = 5;

        /** <summary>
         * 文本颜色.选中
         * </summary>
         **/
        public const int COLOR_EX_TEXT_CHECKED = 6;

        /** <summary>
         * 文本颜色.选择
         * </summary>
         **/
        public const int COLOR_EX_TEXT_SELECT = 7;

        /** <summary>
         * 文本颜色.热点
         * </summary>
         **/
        public const int COLOR_EX_TEXT_HOT = 8;

        /** <summary>
         * 文本颜色.已访问
         * </summary>
         **/
        public const int COLOR_EX_TEXT_VISTED = 9;

        /** <summary>
         * 文本颜色.阴影
         * </summary>
         **/
        public const int COLOR_EX_TEXT_SHADOW = 10;

        /** <summary>
         * 编辑框.光标原色
         * </summary>
         **/
        public const int COLOR_EX_EDIT_CARET = 30;

        /** <summary>
         * 编辑框.提示文本颜色
         * </summary>
         **/
        public const int COLOR_EX_EDIT_BANNER = 31;


        #endregion

        #region EOS_
        /** <summary>
         * 组件风格_滚动条不可用时显示禁止状态
         * </summary>
         **/
        public const int EOS_DISABLENOSCROLL = 33554432;

        /** <summary>
         * 组件风格_可调整尺寸
         * </summary>
         **/
        public const int EOS_SIZEBOX = 67108864;

        /** <summary>
         * 组件风格_禁止
         * </summary>
         **/
        public const int EOS_DISABLED = 134217728;

        /** <summary>
         * 组件风格_可视
         * </summary>
         **/
        public const int EOS_VISIBLE = 268435456;

        /** <summary>
         * 组件风格_边框
         * </summary>
         **/
        public const int EOS_BORDER = 536870912;

        /** <summary>
         * 组件风格_水平滚动条
         * </summary>
         **/
        public const int EOS_VSCROLL = 1073741824;

        /** <summary>
         * 组件风格_垂直滚动条
         * </summary>
         **/
        public const int EOS_HSCROLL = -2147483648;

        /** <summary>
         * 组件风格_扩展_自适应尺寸
         * </summary>
         **/
        public const int EOS_EX_AUTOSIZE = 4194304;

        /** <summary>
         * 组件风格_扩展_鼠标穿透
         * </summary>
         **/
        public const int EOS_EX_TRANSPARENT = 8388608;

        /** <summary>
         * 组件风格_扩展_允许拖拽
         * </summary>
         **/
        public const int EOS_EX_DRAGDROP = 33554432;

        /** <summary>
         * 组件风格_扩展_接收文件拖放
         * </summary>
         **/
        public const int EOS_EX_ACCEPTFILES = 67108864;

        /** <summary>
         * 组件风格_扩展_允许焦点
         * </summary>
         **/
        public const int EOS_EX_FOCUSABLE = 134217728;

        /** <summary>
         * 组件风格_扩展_允许TAB焦点
         * </summary>
         **/
        public const int EOS_EX_TABSTOP = 268435456;

        /** <summary>
         * 组件风格_扩展_总在最前
         * </summary>
         **/
        public const int EOS_EX_TOPMOST = 536870912;

        /** <summary>
         * 组件风格_扩展_背景混合
         * </summary>
         **/
        public const int EOS_EX_COMPOSITED = 1073741824;

        /** <summary>
         * 组件风格_扩展_自定义绘制
         * </summary>
         **/
        public const int EOS_EX_CUSTOMDRAW = -2147483648;


        #endregion

        #region EOL_
        /** <summary>
         * 组件节点ID
         * </summary>
         **/
        public const int EOL_NODEID = -1;

        /** <summary>
         * 组件模糊系数
         * </summary>
         **/
        public const int EOL_BLUR = -2;

        /** <summary>
         * 组件回调
         * </summary>
         **/
        public const int EOL_OBJPROC = -4;

        /** <summary>
         * 组件透明度
         * </summary>
         **/
        public const int EOL_ALPHA = -5;

        /** <summary>
         * 自定义参数
         * </summary>
         **/
        public const int EOL_LPARAM = -7;

        /** <summary>
         * 父句柄
         * </summary>
         **/
        public const int EOL_OBJPARENT = -8;

        /** <summary>
         * 组件文本格式
         * </summary>
         **/
        public const int EOL_TEXTFORMAT = -11;

        /** <summary>
         * 组件ID
         * </summary>
         **/
        public const int EOL_ID = -12;

        /** <summary>
         * 组件基本风格
         * </summary>
         **/
        public const int EOL_STYLE = -16;

        /** <summary>
         * 组件字体句柄
         * </summary>
         **/
        public const int EOL_HFONT = -19;

        /** <summary>
         * 组件扩展风格
         * </summary>
         **/
        public const int EOL_EXSTYLE = -20;

        /** <summary>
         * 用户数据
         * </summary>
         **/
        public const int EOL_USERDATA = -21;

        /** <summary>
         * 画布句柄（不要乱改）
         * </summary>
         **/
        public const int EOL_HCANVAS = -22;

        /** <summary>
         * 控件数据（不要乱改）
         * </summary>
         **/
        public const int EOL_OWNER = -23;

        /** <summary>
         * 组件状态
         * </summary>
         **/
        public const int EOL_STATE = -24;

        /** <summary>
         * 组件标题内容指针
         * </summary>
         **/
        public const int EOL_LPWZTITLE = -28;

        /** <summary>
         * 光标句柄
         * </summary>
         **/
        public const int EOL_CURSOR = -17;


        #endregion

        #region EOST_
        /** <summary>
         * 正常
         * </summary>
         **/
        public const int EOST_NORMAL = 0;

        /** <summary>
         * 禁用
         * </summary>
         **/
        public const int EOST_DISABLE = 1;

        /** <summary>
         * 选择
         * </summary>
         **/
        public const int EOST_SELECTED = 2;

        /** <summary>
         * 焦点
         * </summary>
         **/
        public const int EOST_FOCUS = 4;

        /** <summary>
         * 按下
         * </summary>
         **/
        public const int EOST_PRESS = 8;

        /** <summary>
         * 选中
         * </summary>
         **/
        public const int EOST_CHECKED = 16;

        /** <summary>
         * 半选中
         * </summary>
         **/
        public const int EOST_CHECKED_HALF = 32;

        /** <summary>
         * 只读
         * </summary>
         **/
        public const int EOST_READONLY = 64;

        /** <summary>
         * 点燃
         * </summary>
         **/
        public const int EOST_HOVER = 128;

        /** <summary>
         * 默认
         * </summary>
         **/
        public const int EOST_DEFAULT = 256;

        /** <summary>
         * 子项可视
         * </summary>
         **/
        public const int EOST_SUBITEM_VISIBLE = 512;

        /** <summary>
         * 子项隐藏
         * </summary>
         **/
        public const int EOST_SUBITEM_HIDE = 1024;

        /** <summary>
         * 忙碌中
         * </summary>
         **/
        public const int EOST_BUSY = 2048;

        /** <summary>
         * 滚动中
         * </summary>
         **/
        public const int EOST_SCROLLING = 8192;

        /** <summary>
         * 动画中
         * </summary>
         **/
        public const int EOST_ANIMATING = 16384;

        /** <summary>
         * 隐藏
         * </summary>
         **/
        public const int EOST_HIDE = 32768;

        /** <summary>
         * 可调尺寸
         * </summary>
         **/
        public const int EOST_SIZEABLE = 131072;

        /** <summary>
         * 可拖拽
         * </summary>
         **/
        public const int EOST_DRAGABLE = 262144;

        /** <summary>
         * 可有焦点
         * </summary>
         **/
        public const int EOST_FOCUSABLE = 1048576;

        /** <summary>
         * 可选择
         * </summary>
         **/
        public const int EOST_SELECTABLE = 2097152;

        /** <summary>
         * 超链接点燃
         * </summary>
         **/
        public const int EOST_LINK_HOVER = 4194304;

        /** <summary>
         * 超链接访问过
         * </summary>
         **/
        public const int EOST_LINK_VISITED = 8388608;

        /** <summary>
         * 允许多选
         * </summary>
         **/
        public const int EOST_MULTISELECT = 16777216;

        /** <summary>
         * 密码状态
         * </summary>
         **/
        public const int EOST_PASSWORD = 536870912;


        #endregion

        #region GW_
        /** <summary>
         * 子控件
         * </summary>
         **/
        public const int GW_CHILD = 5;

        /** <summary>
         * 上一个兄弟
         * </summary>
         **/
        public const int GW_HWNDPREV = 3;

        /** <summary>
         * 下一个兄弟
         * </summary>
         **/
        public const int GW_HWNDNEXT = 2;

        #endregion

    }
}
