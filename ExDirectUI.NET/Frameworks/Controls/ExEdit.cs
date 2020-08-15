using System;
using System.Collections.Generic;
using System.Text;

namespace ExDirectUI.NET.Frameworks.Controls
{
    public class ExEdit : ExControl
    {
        public ExEdit(IExBaseUIEle pOwner, string sText, int x, int y, int nWidth, int nHeight, int dwTextFormat = -1)
           : base(pOwner, "Edit", sText, x, y, nWidth, nHeight, -1, -1, dwTextFormat)
        {

        }

        public new string ClassName => "Edit";

        
    }
}
