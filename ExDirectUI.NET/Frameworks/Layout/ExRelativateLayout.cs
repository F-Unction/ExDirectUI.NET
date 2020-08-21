using ExDirectUI.NET.Frameworks.Controls;
using static ExDirectUI.NET.Native.ExConst;
using System;

namespace ExDirectUI.NET.Frameworks.Layout
{
    class ExRelativateLayout : ExBaseLayout
    {
        public ExRelativateLayout(ExControl objBind)
            : base(ELT_RELATIVE, objBind)
        {
        }

        public ExRelativateLayout(IntPtr hLayout)
            : base(hLayout)
        {
        }
    }
}
