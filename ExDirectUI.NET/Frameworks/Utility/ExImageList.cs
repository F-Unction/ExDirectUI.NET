using ExDirectUI.NET.Frameworks.Graphics;
using ExDirectUI.NET.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDirectUI.NET.Frameworks.Utility
{
    class ExImageList : IDisposable
    {
        protected IntPtr m_hImgList;

        public IntPtr Handle => m_hImgList;

        public ExImageList(int nWidth, int nHeight)
        {
            ExAPI._imglist_create(nWidth, nHeight);
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

        
    }
}
