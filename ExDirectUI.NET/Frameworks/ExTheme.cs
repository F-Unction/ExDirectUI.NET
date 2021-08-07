using ExDirectUI.NET.Native;
using System;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExTheme : IDisposable
    {
        protected IntPtr m_hTheme;

        public IntPtr Handle => m_hTheme;

        public ExTheme(string lptszFile, byte[] lpKey, int dwKeyLen, bool bDefault)
        {
            m_hTheme = (IntPtr)ExAPI.Ex_ThemeLoadFromFile(lptszFile, lpKey, dwKeyLen, bDefault);
        }

        public ExTheme(byte[] lpData, int dwDataLen, byte[] lpKey, int dwKeyLen, bool bDefault)
        {
            m_hTheme = (IntPtr)ExAPI.Ex_ThemeLoadFromMemory(lpData, dwDataLen, lpKey, dwKeyLen, bDefault);
        }

        public void Dispose()
        {
            ExAPI.Ex_ThemeFree(m_hTheme);
            m_hTheme = IntPtr.Zero;
        }

        public bool DrawControl(ExCanvas canvas, float dstLeft, float dstTop, float dstRight, float dstBottom, int atomClass, int atomSrcRect, int dwAlpha)
        {
            return ExAPI.Ex_ThemeDrawControl(m_hTheme, canvas.Handle, dstLeft, dstTop, dstRight, dstBottom, atomClass, atomSrcRect, dwAlpha);
        }

        public bool DrawControlEx(ExCanvas canvas, float dstLeft, float dstTop, float dstRight, float dstBottom, int atomClass, int atomSrcRect, int atomBackgroundRepeat, int atomBackgroundPositon, int atomBackgroundGrid, int atomBackgroundFlags, int dwAlpha)
        {
            return ExAPI.Ex_ThemeDrawControlEx(m_hTheme, canvas.Handle, dstLeft, dstTop, dstRight, dstBottom, atomClass, atomSrcRect, atomBackgroundRepeat, atomBackgroundPositon, atomBackgroundGrid, atomBackgroundFlags, dwAlpha);
        }

        public int GetColor(int nIndex)
        {
            return ExAPI.Ex_ThemeGetColor(m_hTheme, nIndex);
        }

        public IntPtr GetValuePtr(int atomClass, int atomProp)
        {
            return (IntPtr)ExAPI.Ex_ThemeGetValuePtr(m_hTheme, atomClass, atomProp);
        }
    }
}
