﻿using ExDirectUI.NET.Native;
using System;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExRegion : IDisposable
    {
        protected IntPtr m_hRgn;

        public IntPtr Handle => m_hRgn;

        public ExRegion(ExPath path)
        {
            m_hRgn = (IntPtr)ExAPI._rgn_createfrompath(path.Handle);
        }

        public ExRegion(float left, float top, float right, float bottom)
        {
            m_hRgn = (IntPtr)ExAPI._rgn_createfromrect(left, top, right, bottom);
        }

        public ExRegion(float left, float top, float right, float bottom, float radiusX, float radiusY)
        {
            m_hRgn = (IntPtr)ExAPI._rgn_createfromroundrect(left, top, right, bottom, radiusX, radiusY);
        }

        public void Dispose()
        {
            ExAPI._rgn_destroy(m_hRgn);
            m_hRgn = IntPtr.Zero;
        }

        public int Combine(ExRegion RgnDst,int nCombineMode,int dstOffsetX,int dstOffsetY)
        {
            return ExAPI._rgn_combine(m_hRgn, RgnDst.m_hRgn, nCombineMode, dstOffsetX, dstOffsetY);
        }

        public bool HitTest(float x, float y)
        {
            return ExAPI._rgn_hittest(m_hRgn, x, y);
        }
    }
}
