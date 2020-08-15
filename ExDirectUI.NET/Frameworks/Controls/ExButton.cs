using System;
using System.Collections.Generic;
using System.Text;

namespace ExDirectUI.NET.Frameworks.Controls
{
    public class ExButton : ExControl
    {
        public ExButton(IExBaseUIEle oParent, string sTitle, int x, int y, int nWidth, int nHeight)
            : base(oParent, "Button", sTitle, x, y, nWidth, nHeight)
        {

        }

        public new string ClassName => "Button";
    }
}
