using ExDirectUI.NET.Frameworks.Graphics;
using ExDirectUI.NET.Native;
using System;

namespace ExDirectUI.NET.Frameworks.Utility
{
    public class ExImageList : IDisposable
    {
        protected IntPtr m_hImgList;

        public IntPtr Handle => m_hImgList;

        public ExImageList(int nWidth, int nHeight)
        {
            ExAPI._imglist_create(nWidth, nHeight);
        }

        public ExImageList(IntPtr hImgList)
        {
            m_hImgList = hImgList;
        }

        public void Dispose()
        {
            ExAPI._imglist_destroy(m_hImgList);
            m_hImgList = IntPtr.Zero;
        }

        public int Add(byte[] lpImage, int cbImage, int nIndexInsert)
        {
            return ExAPI._imglist_add(m_hImgList, lpImage, cbImage, nIndexInsert);
        }

        public int AddImage(ExImage image, int nIndexInsert)
        {
            return ExAPI._imglist_addimage(m_hImgList, image.Handle, nIndexInsert);
        }

        public int Count
        {
            get
            {
                return ExAPI._imglist_count(m_hImgList);
            }
        }

        public int Del(int nIndex)
        {
            return ExAPI._imglist_del(m_hImgList, nIndex);
        }

        public bool Draw(int nIndex, ExCanvas canvas, int nLeft, int nTop, int nRight, int nBottom, int nAlpha)
        {
            return ExAPI._imglist_draw(m_hImgList, nIndex, canvas.Handle, nLeft, nTop, nRight, nBottom, nAlpha);
        }

        public ExImage Get(int nIndex)
        {
            return new ExImage((int)ExAPI._imglist_get(m_hImgList, nIndex));
        }

        public int Set(int nIndex, byte[] lpImage, int cbImage)
        {
            return ExAPI._imglist_set(m_hImgList, nIndex, lpImage, cbImage);
        }

        public int SetImage(int nIndex, ExImage image)
        {
            return ExAPI._imglist_setimage(m_hImgList, nIndex, image.Handle);
        }

        public int Width
        {
            get
            {
                int width = 0, tmp = 0;
                ExAPI._imglist_size(m_hImgList, ref width, ref tmp);
                return width;
            }
        }

        public int Height
        {
            get
            {
                int height = 0, tmp = 0;
                ExAPI._imglist_size(m_hImgList, ref tmp, ref height);
                return height;
            }
        }
    }
}
