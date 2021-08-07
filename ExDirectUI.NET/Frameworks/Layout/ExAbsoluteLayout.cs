using ExDirectUI.NET.Frameworks.Controls;
using ExDirectUI.NET.Native;
using static ExDirectUI.NET.Native.ExConst;
using System;

namespace ExDirectUI.NET.Frameworks.Layout
{
    public class ExAbsoluteLayout : ExBaseLayout
    {
        public ExAbsoluteLayout(IExBaseUIEle objBind)
            : base(ELT_ABSOLUTE, objBind)
        {
        }

        public ExAbsoluteLayout(IntPtr hLayout)
            : base(hLayout)
        {
        }

        public bool Lock(ExControl obj, int tLeft, int tTop, int tRight, int tBottom, int tWidth, int tHeight)
        {
            return ExAPI._layout_absolute_lock(m_hLayout, obj.Handle, tLeft, tTop, tRight, tBottom, tWidth, tHeight);
        }

        public bool SetEdge(ExControl obj, int dwEdge, int dwType, int nValue)
        {
            return ExAPI._layout_absolute_setedge(m_hLayout, obj.Handle, dwEdge, dwType, nValue);
        }
    }
}
