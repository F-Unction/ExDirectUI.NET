using ExDirectUI.NET.Frameworks.Controls;
using static ExDirectUI.NET.Native.ExConst;
using System;

namespace ExDirectUI.NET.Frameworks.Layout
{
    public class ExFlowLayout : ExBaseLayout
    {
        public ExFlowLayout(ExControl objBind)
            : base(ELT_FLOW, objBind)
        {
        }

        public ExFlowLayout(IntPtr hLayout)
            : base(hLayout)
        {
        }
    }
}
