using ExDirectUI.NET.Native;
using System;
using System.Security.Cryptography;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExPath : IDisposable
    {
        protected IntPtr m_hPath;

        public IntPtr Handle => m_hPath;

        public ExPath(int brushmode, int dwFlags)
        {
            ExAPI._path_create(brushmode, dwFlags, out m_hPath);
        }

        public ExPath(IntPtr hPath)
        {
            m_hPath = hPath;
        }

        public void Dispose()
        {
            ExAPI._path_destroy(m_hPath);
            m_hPath = IntPtr.Zero;
        }

        public int AddArc(float x1, float y1, float x2, float y2, float radiusX, float radiusY, bool fClockwise)
        {
            return ExAPI._path_addarc(m_hPath, x1, y1, x2, y2, radiusX, radiusY, fClockwise);
        }

        public int AddArc2(float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            return ExAPI._path_addarc2(m_hPath, x, y, width, height, startAngle, sweepAngle);
        }

        public int AddLine(float x1, float y1, float x2, float y2)
        {
            return ExAPI._path_addline(m_hPath, x1, y1, x2, y2);
        }

        public int AddRect(float left, float top, float right, float bottom)
        {
            return ExAPI._path_addrect(m_hPath, left, top, right, bottom);
        }

        public int AddRoundedRect(float left, float top, float right, float bottom, float radiusTopLeft, float radiusTopRight, float radiusBottomLeft, float radiusBottomRight, int unit)
        {
            return ExAPI._path_addroundedrect(m_hPath, left, top, right, bottom, radiusTopLeft, radiusTopRight, radiusBottomLeft, radiusBottomRight, unit);
        }

        public int BeginFigure()
        {
            return ExAPI._path_beginfigure(m_hPath);
        }

        public int BeginFigue(float x, float y)
        {
            return ExAPI._path_beginfigure2(m_hPath, x, y);
        }

        public int BeginFigue(float x, float y, int figureBegin)
        {
            return ExAPI._path_beginfigure3(m_hPath, x, y, figureBegin);
        }

        public int Close()
        {
            return ExAPI._path_close(m_hPath);
        }

        public int EndFigure(bool fCloseFigure)
        {
            return ExAPI._path_endfigure(m_hPath, fCloseFigure);
        }

        public ExRectF Bounds
        {
            get
            {
                ExRectF lpBounds = new ExRectF();
                ExAPI._path_getbounds(m_hPath, ref lpBounds);
                return lpBounds;
            }
        }

        public bool HitTest(float x, float y)
        {
            return ExAPI._path_hittest(m_hPath, x, y);
        }

        public int Open()
        {
            return ExAPI._path_open(m_hPath);
        }

        public int Reset()
        {
            return ExAPI._path_reset(m_hPath);
        }

        public int AddBezier(IntPtr hPath, float x1, float y1, float x2, float y2, float x3, float y3)
        {
            return ExAPI._path_addbezier(m_hPath, x1, y1, x2, y2, x3, y3);
        }
    }
}
