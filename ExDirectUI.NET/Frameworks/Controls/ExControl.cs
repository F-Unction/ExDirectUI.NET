using System;
using System.Text;
using ExDirectUI.NET.Native;

namespace ExDirectUI.NET.Frameworks.Controls
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
                ExAPI.Ex_ObjGetRect(m_hObj, out ExRect rc);
                return rc;
            }
            set => ExAPI.Ex_ObjMove(m_hObj, value.nLeft, value.nTop, value.nRight - value.nLeft, value.nBottom - value.nTop, true);
        }

        public ExRect Client
        {
            get
            {
                ExAPI.Ex_ObjGetClientRect(m_hObj, out ExRect rc);
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

        public int DestroyBackground()
        {
            return ExAPI.Ex_ObjDestroyBackground(m_hObj);
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

            return ExAPI.Ex_ObjSetLong(m_hObj, ExConst.EOL_OBJPROC, pfnObjProc);
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

        public bool SetFont(string sName = null, int nSize = -1, int dwStyle = -1, bool fRedraw = true)
        {
            return ExAPI.Ex_ObjSetFontFromFamily(m_hObj, sName, nSize, dwStyle, fRedraw);
        }

        public void PointTransform(ExControl pObjDest, ref int x, ref int y)
        {
            IntPtr hObj = pObjDest == null ? IntPtr.Zero : pObjDest.Handle;
            ExAPI.Ex_ObjPointTransform(m_hObj, hObj, ref x, ref y);
        }

        public void EnablePaintingMsg(bool fEnable)
        {
            ExAPI.Ex_ObjEnablePaintingMsg(m_hObj, fEnable);
        }

        public IntPtr GetDropData(int pDataObject, int dwFormat, out int pcbData)
        {
            return ExAPI.Ex_ObjGetDropData(m_hObj, pDataObject, dwFormat, out pcbData);
        }

        public int GetDropString(int pDataObject, out string lpwzBuffer, int cchMaxLength)
        {
            return ExAPI.Ex_ObjGetDropString(m_hObj, pDataObject, out lpwzBuffer, cchMaxLength);
        }

        public bool CheckDropFormat(int pDataObject, int dwFormat)
        {
            return ExAPI.Ex_ObjCheckDropFormat(m_hObj, pDataObject, dwFormat);
        }
    }
}
