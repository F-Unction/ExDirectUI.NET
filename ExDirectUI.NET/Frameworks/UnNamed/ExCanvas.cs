using ExDirectUI.NET.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDirectUI.NET.Frameworks.UnNamed
{
    class ExCanvas : IDisposable
    {
        protected IntPtr m_hCanvas;

        public IntPtr Handle => m_hCanvas;

        public ExCanvas(ExSkin skin, int width, int height, int dwFlags)
        {
            m_hCanvas = (IntPtr)ExAPI._canvas_createfromexdui(skin.Handle, width, height, dwFlags);
        }

        public ExCanvas(ExControl obj, int uWidth, int uHeight, int dwFlags, out int nError)
        {
            m_hCanvas = (IntPtr)ExAPI._canvas_createfromobj(obj.Handle, uWidth, uHeight, dwFlags, out nError);
        }

        public void Dispose()
        {
            ExAPI._canvas_destroy(m_hCanvas);
            m_hCanvas = IntPtr.Zero;
        }

        public bool BeginDraw()
        {
            return ExAPI._canvas_begindraw(m_hCanvas);
        }

        public bool Blur(float fDeviation, ref int lpRc)
        {
            return ExAPI._canvas_blur(m_hCanvas, fDeviation, ref lpRc);
        }

        public bool CalcTextSize(ExFont font, string text, int dwLen, int dwDTFormat, int lParam, float layoutWidth, float layoutHeight, out float lpWidth, out float lpHeight)
        {
            return ExAPI._canvas_calctextsize(m_hCanvas, font.Handle, text, dwLen, dwDTFormat, lParam, layoutWidth, layoutHeight, out lpWidth, out lpHeight);
        }

        public bool Clear(int nColor)
        {
            return ExAPI._canvas_clear(m_hCanvas, nColor);
        }

        public bool ClipRect(int left, int top, int right, int bottom)
        {
            return ExAPI._canvas_cliprect(m_hCanvas, left, top, right, bottom);
        }

        public bool DrawRoundedRect(ExBrush brush, float left, float top, float right, float bottom, float radiusX, float radiusY, float strokeWidth, int strokeStyle)
        {
            return ExAPI._canvas_drawroundedrect(m_hCanvas, brush.Handle, left, top, right, bottom, radiusX, radiusY, strokeWidth, strokeStyle);
        }

        public bool DrawText(ExFont font, int crText, string lpwzText, int dwLen, int dwDTFormat, float left, float top, float right, float bottom)
        {
            return ExAPI._canvas_drawtext(m_hCanvas, font.Handle, crText, lpwzText, dwLen, dwDTFormat, left, top, right, bottom);
        }

        public bool DrawTextEx(ExFont font, int crText, ref int lpwzText, int dwLen, int dwDTFormat, float left, float top, float right, float bottom, int iGlowsize, int crShadow, int lParam, ref ExRect prclayout)
        {
            return ExAPI._canvas_drawtextex(m_hCanvas, font.Handle, crText, ref lpwzText, dwLen, dwDTFormat, left, top, right, bottom, iGlowsize, crShadow, lParam, ref prclayout);
        }

        public bool EndDraw()
        {
            return ExAPI._canvas_enddraw(m_hCanvas);
        }

        public bool FillEllipse(ExBrush brush, float x, float y, float radiusX, float radiusY)
        {
            return ExAPI._canvas_fillellipse(m_hCanvas, brush.Handle, x, y, radiusX, radiusY);
        }
    }
}
