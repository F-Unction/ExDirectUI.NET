using ExDirectUI.NET.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExBrush : IDisposable
    {
        protected IntPtr m_hBrush;
        protected int _color;

        public IntPtr Handle => m_hBrush;

        public ExBrush()
        {
        }

        public ExBrush(int Color)
        {
            m_hBrush = (IntPtr)ExAPI._brush_create(Color);
            _color = Color;
        }

        public ExBrush(ExCanvas canvas)
        {
            m_hBrush = (IntPtr)ExAPI._brush_createfromcanvas(canvas.Handle);
        }

        public ExBrush(ExImage img)
        {
            m_hBrush = (IntPtr)ExAPI._brush_createfromimg(img.Handle);
        }


        public int Color
        {
            get
            {
                return _color;
            }
            set
            {
                ExAPI._brush_setcolor(m_hBrush, value);
            }
        }

        public int SetTransFrom(ExMatrix matrix)
        {
            return ExAPI._brush_settransform(m_hBrush, matrix.Handle);
        }

        public void Dispose()
        {
            ExAPI._brush_destroy(m_hBrush);
            m_hBrush = IntPtr.Zero;
        }
    }
}
