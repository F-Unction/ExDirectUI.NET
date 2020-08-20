using ExDirectUI.NET.Native;
using System;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExMatrix : IDisposable
    {
        protected IntPtr m_hMatrix;

        public IntPtr Handle => m_hMatrix;

        public ExMatrix()
        {
            m_hMatrix = (IntPtr)ExAPI._matrix_create();
        }

        public ExMatrix(IntPtr hMatrix)
        {
            m_hMatrix = hMatrix;
        }

        public void Dispose()
        {
            ExAPI._matrix_destroy(m_hMatrix);
            m_hMatrix = IntPtr.Zero;
        }

        public bool Reset()
        {
            return ExAPI._matrix_reset(m_hMatrix);
        }

        public bool Rotate(float fAngle, int order)
        {
            return ExAPI._matrix_rotate(m_hMatrix, fAngle, order);
        }

        public bool Scale(float scaleX, float scaleY, int order)
        {
            return ExAPI._matrix_scale(m_hMatrix, scaleX, scaleY, order);
        }

        public bool Translate(float offsetX, float offsetY, int order)
        {
            return ExAPI._matrix_translate(m_hMatrix, offsetX, offsetY, order);
        }
    }
}
