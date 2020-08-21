using ExDirectUI.NET.Native;

namespace ExDirectUI.NET.Frameworks.Controls
{
    public class ExScrollBar : ExControl
    {
        public ExScrollBar(IExBaseUIEle oParent, string sTitle, int x, int y, int nWidth, int nHeight)
            : base(oParent, "ScrollBar", sTitle, x, y, nWidth, nHeight)
        {
        }

        public bool Enable(int wSB,int wArrows)
        {
            return ExAPI.Ex_ObjScrollEnable(m_hObj, wSB, wArrows);
        }

        public new string ClassName => "ScrollBar";


        #region SB_
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int SB_HORZ = 0;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int SB_VERT = 1;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int SB_CTL = 2;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int SB_BOTH = 3;
        #endregion
    }
}
