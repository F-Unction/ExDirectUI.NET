using ExDirectUI.NET.Frameworks.Controls;
using ExDirectUI.NET.Native;

namespace ExDirectUI.NET.Frameworks.Layout
{
    class ExTableLayout : ExBaseLayout
    {
        public ExTableLayout(ExControl objBind)
            : base(ELT_TABLE, objBind)
        {
        }

        public bool SetInfo(int aRowHeight, int cRows, int aCellWidth, int cCells)
        {
            return ExAPI._layout_table_setinfo(m_hLayout, aRowHeight, cRows, cRows, cCells);
        }
    }
}
