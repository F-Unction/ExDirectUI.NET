﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExDirectUI.NET.Frameworks.Controls
{
    public class ExStatic : ExControl
    {
        public ExStatic(IExBaseUIEle pOwner, string sText, int x, int y, int nWidth, int nHeight, int dwTextFormat = -1)
            : base(pOwner, "Static", sText, x, y, nWidth, nHeight, -1, -1, dwTextFormat)
        {

        }

        public ExStatic(IExBaseUIEle pOwner, byte[] pImageData, int x, int y, int nWidth, int nHeight)
            : base(pOwner, "Static", null, x, y, nWidth, nHeight)
        {
            SetBackgroundImage(pImageData, 0, 0, 0, IntPtr.Zero, 0, 255, true);
        }

        public new string ClassName => "Static";
    }
}
