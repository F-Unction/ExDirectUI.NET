using ExDirectUI.NET.Frameworks.Controls;
using static ExDirectUI.NET.Native.ExConst;
using System;

namespace ExDirectUI.NET.Frameworks.Layout
{
    class ExPageLayout : ExBaseLayout
    {
        public ExPageLayout(ExControl objBind)
            : base(ELT_PAGE, objBind)
        {
        }

        public ExPageLayout(IntPtr hLayout)
            : base(hLayout)
        {
        }
    }
}
