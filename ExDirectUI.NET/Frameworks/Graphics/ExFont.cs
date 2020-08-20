using ExDirectUI.NET.Native;
using System;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExFont : IDisposable
    {
        protected IntPtr m_hFont;

        public IntPtr Handle => m_hFont;

        public ExFont()
        {
            m_hFont = (IntPtr)ExAPI._font_create();
        }

        public ExFont(string fontFace,int dwFontSize,int dwFontStyle)
        {
            m_hFont = (IntPtr)ExAPI._font_createfromfamily(fontFace, dwFontSize, dwFontStyle);
        }

        public ExFont(ref WinAPI.LogFont lpLogFont)
        {
            m_hFont = (IntPtr)ExAPI._font_createfromlogfont(ref lpLogFont);
        }

        public void Dispose()
        {
            ExAPI._font_destroy(m_hFont);
            m_hFont = IntPtr.Zero;
        }

        public ExFont Copy()
        {
            return new ExFont 
            {
                m_hFont = (IntPtr)ExAPI._font_copy(m_hFont) 
            };
        }

        public int Context
        {
            get
            {
                return ExAPI._font_getcontext(m_hFont);
            }
        }

        public WinAPI.LogFont LogFont
        {
            get
            {
                WinAPI.LogFont lpLogFont = new WinAPI.LogFont();
                ExAPI._font_getlogfont(m_hFont, ref lpLogFont);
                return lpLogFont;
            }
        }
    }
}
