using ExDirectUI.NET.Native;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExImage : IDisposable
    {
        protected IntPtr m_hImg;

        public IntPtr Handle => m_hImg;

        public int Height
        {
            get
            {
                return ExAPI._img_height(m_hImg);
            }
        }

        public int Width
        {
            get
            {
                return ExAPI._img_width(m_hImg);
            }
        }

        public ExImage()
        {
        }

        public ExImage(int width, int height)
        {
            ExAPI._img_create(width, height, out m_hImg);
        }

        public ExImage(ExCanvas canvas)
        {
            ExAPI._img_createfromcanvas(canvas.Handle, out m_hImg);
        }

        public ExImage(string wzFilename)
        {
            ExAPI._img_createfromfile(wzFilename, out m_hImg);
        }

        public ExImage(IntPtr hBitmap, IntPtr hPalette, bool fPreAlpha)
        {
            ExAPI._img_createfromhbitmap(hBitmap, hPalette, fPreAlpha, out m_hImg);
        }

        public ExImage(IntPtr hIcon)
        {
            ExAPI._img_createfromhicon(hIcon, out m_hImg);
        }

        public ExImage(byte[] lpData, int dwLen)
        {
            ExAPI._img_createfrommemory(lpData, dwLen, out m_hImg);
        }

        public ExImage(ExResource res, int atomPath)
        {
            ExAPI._img_createfromres(res.Handle, atomPath, out m_hImg);
        }

        public ExImage(IStream lpStream)
        {
            ExAPI._img_createfromstream(lpStream, out m_hImg);
        }

        public void Dispose()
        {
            ExAPI._img_destroy(m_hImg);
            m_hImg = IntPtr.Zero;
        }

        public int Copy(out IntPtr dsgImg)
        {
            return ExAPI._img_copy(m_hImg, out dsgImg);
        }

        public int Copy(int x, int y, int width, int height, out IntPtr dsgImg)
        {
            return ExAPI._img_copyrect(m_hImg, x, y, width, height, out dsgImg);
        }

        public int FrameCount
        {
            get
            {
                ExAPI._img_getframecount(m_hImg, out int nFrameCount);
                return nFrameCount;
            }
        }

        public int GetFrameDelay(int[] lpDelayAry, out int nFrames)
        {
            return ExAPI._img_getframedelay(m_hImg, lpDelayAry, out nFrames);
        }

        public int GetPixel(int x, int y, out int color)
        {
            return ExAPI._img_getpixel(m_hImg, x, y, out color);
        }

        public int GetSize(out int lpWidth, out int lpHeight)
        {
            return ExAPI._img_getsize(m_hImg, out lpWidth, out lpHeight);
        }

        public int GetThumbnail(int thumbWidth, int thumbHeight, out ExImage ImgThumbnail)
        {
            var ans = IntPtr.Zero;
            var ret = ExAPI._img_getthumbnail(m_hImg, thumbWidth, thumbHeight, out ans);
            ImgThumbnail = new ExImage() { m_hImg = ans };
            return ret;
        }

        unsafe public int Lock(ExRect RectL, int flags, int PixelFormat, ref ExBitmapData lpLockedBitmapData)
        {
            var lpRectL = (int)&RectL;
            return ExAPI._img_lock(m_hImg, ref lpRectL, flags, PixelFormat, ref lpLockedBitmapData);
        }

        public int RotateFlip(int rfType)
        {
            return ExAPI._img_rotateflip(m_hImg, rfType);
        }

        public int Scale(int dstWidth, int dstHeight, out ExImage dstImg)
        {

            var ans = IntPtr.Zero;
            var ret = ExAPI._img_scale(m_hImg, dstWidth, dstHeight, out ans);
            dstImg = new ExImage() { m_hImg = ans };
            return ret;
        }

        public int SelectActiveFrame(int nIndex)
        {
            return ExAPI._img_selectactiveframe(m_hImg, nIndex);
        }

        public int SetPixel(int x, int y, int color)
        {
            return ExAPI._img_setpixel(m_hImg, x, y, color);
        }

        public int Unlock(ref ExBitmapData lpLockedBitmapData)
        {
            return ExAPI._img_unlock(m_hImg, ref lpLockedBitmapData);
        }

        public void SaveToFile(string lpWzFile)
        {
            ExAPI._img_savetofile(m_hImg, lpWzFile);
        }

        public void SaveToMemory(out byte[] lpBuffer)
        {
            ExAPI._img_savetomemory(m_hImg, out lpBuffer);
        }
    }
}
