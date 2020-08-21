using System;

namespace ExDirectUI.NET.Frameworks.Controls
{
    public class ExEdit : ExControl
    {
        public ExEdit(IExBaseUIEle pOwner, string sText, int x, int y, int nWidth, int nHeight, int dwTextFormat = -1)
           : base(pOwner, "Edit", sText, x, y, nWidth, nHeight, -1, -1, dwTextFormat)
        {

        }

        public new string ClassName => "Edit";

        #region 编辑框风格_
        /** <summary>
         * 暂无注释  
         * </summary>
         **/
        public const int 编辑框风格_允许拖拽 = 1;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_密码输入 = 2;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_显示选择文本 = 4;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_丰富文本 = 8;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_允许鸣叫 = 16;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_只读 = 32;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_回车换行 = 64;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_数值输入 = 128;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_自动选择字符 = 256;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_禁用右键默认菜单 = 512;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_解析URL = 1024;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_允许TAB字符 = 2048;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_总是显示提示文本 = 4096;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int 编辑框风格_隐藏插入符 = 8192;
        #endregion
    }
}
