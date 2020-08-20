using ExDirectUI.NET.Frameworks.Controls;
using System;

namespace ExDirectUI.NET.Frameworks.Layout
{
    class ExLinearLayout : ExBaseLayout
    {
        public ExLinearLayout(ExControl objBind)
            : base(ELT_LINEAR, objBind)
        {
        }

        public ExLinearLayout(IntPtr hLayout)
            : base(hLayout)
        {
        }
    }
}
