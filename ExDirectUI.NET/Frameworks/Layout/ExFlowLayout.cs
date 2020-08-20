using ExDirectUI.NET.Frameworks.Controls;
using System;

namespace ExDirectUI.NET.Frameworks.Layout
{
    class ExFlowLayout : ExBaseLayout
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
