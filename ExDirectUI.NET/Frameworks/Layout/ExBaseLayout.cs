using System;
using ExDirectUI.NET.Frameworks.Controls;
using ExDirectUI.NET.Native;

namespace ExDirectUI.NET.Frameworks.Layout
{
    class ExBaseLayout : IDisposable
    {
        protected IntPtr m_hLayout;

        public IntPtr Handle => m_hLayout;

        public ExBaseLayout(int nType, ExControl objBind)
        {
            m_hLayout = (IntPtr)ExAPI._layout_create(nType, objBind.Handle);
        }

        public ExBaseLayout(IntPtr hLayout)
        {
            m_hLayout = hLayout;
        }

        public void Dispose()
        {
            ExAPI._layout_destroy(m_hLayout);
            m_hLayout = IntPtr.Zero;
        }

        public bool AddChild(ExControl obj)
        {
            return ExAPI._layout_addchild(m_hLayout, obj.Handle);
        }

        public bool AddChildren(bool fDesc, int dwObjClassAtom, out int nCount)
        {
            return ExAPI._layout_addchildren(m_hLayout, fDesc, dwObjClassAtom, out nCount);
        }

        public bool DeleteChild(ExControl obj)
        {
            return ExAPI._layout_deletechild(m_hLayout, obj.Handle);
        }

        public bool DeleteChildren(int dwObjClassATOM)
        {
            return ExAPI._layout_deletechildren(m_hLayout, dwObjClassATOM);
        }

        public bool SetChildProp(ExControl obj, int dwPropID, ref int pvValue)
        {
            return ExAPI._layout_setchildprop(m_hLayout, obj.Handle, dwPropID, ref pvValue);
        }

        public bool SetProp(int dwPropID, ref int pvValue)
        {
            return ExAPI._layout_setprop(m_hLayout, dwPropID, ref pvValue);
        }

        public bool Unregister(int nType)
        {
            return ExAPI._layout_unregister(nType);
        }

        public bool Update()
        {
            return ExAPI._layout_update(m_hLayout);
        }

        public bool EnableUpdate
        {
            set
            {
                ExAPI._layout_enableupdate(m_hLayout, value);
            }
        }

        public bool GetChildProp(ExControl obj, int dwPropID, out int pvValue)
        {
            return ExAPI._layout_getchildprop(m_hLayout, obj.Handle, dwPropID, out pvValue);
        }

        public bool GetChildPropList(ExControl obj, out int lpProps)
        {
            return ExAPI._layout_getchildproplist(m_hLayout, obj.Handle, out lpProps);
        }

        public int GetProp(int dwPropID)
        {
            return ExAPI._layout_getprop(m_hLayout, dwPropID);
        }

        public int GetPropList()
        {
            return ExAPI._layout_getproplist(m_hLayout);
        }

        public int Type
        {
            get
            {
                return ExAPI._layout_gettype(m_hLayout);
            }
        }

        public int Notify(int nEvent, int wParam, int lParam)
        {
            return ExAPI._layout_notify(m_hLayout, nEvent, wParam, lParam);
        }

        public bool Register(int nType, ExLayoutProcDelegate lpfnLayoutProc)
        {
            return ExAPI._layout_register(nType, lpfnLayoutProc);
        }

        #region #ELT_
        /** <summary>
        * 布局类型_无
        * </summary>
        **/
        public const int ELT_NULL = 0;

        /** <summary>
         * 布局类型_线性
         * </summary>
         **/
        public const int ELT_LINEAR = 1;

        /** <summary>
         * 布局类型_流式
         * </summary>
         **/
        public const int ELT_FLOW = 2;

        /** <summary>
         * 布局类型_页面
         * </summary>
         **/
        public const int ELT_PAGE = 3;

        /** <summary>
         * 布局类型_表格
         * </summary>
         **/
        public const int ELT_TABLE = 4;

        /** <summary>
         * 布局类型_相对
         * </summary>
         **/
        public const int ELT_RELATIVE = 5;

        /** <summary>
         * 布局类型_绝对
         * </summary>
         **/
        public const int ELT_ABSOLUTE = 6;
        #endregion

        #region #ELP_
        /** <summary>
         * 布局属性_通用_内间距_左
         * </summary>
         **/
        public const int ELP_PADDING_LEFT = -1;
        /** <summary>
         * 布局属性_通用_内间距_顶
         * </summary>
         **/
        public const int ELP_PADDING_TOP = -2;
        /** <summary>
         * 布局属性_通用_内间距_右
         * </summary>
         **/
        public const int ELP_PADDING_RIGHT = -3;
        /** <summary>
         * 布局属性_通用_内间距_底
         * </summary>
         **/
        public const int ELP_PADDING_BOTTOM = -4;
        /** <summary>
         * 布局属性:方向
         * </summary>
         **/
        public const int ELP_LINEAR_DIRECTION = 1;
        /** <summary>
         * 布局属性:布局方向对齐方式
         * </summary>
         **/
        public const int ELP_LINEAR_DALIGN = 2;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int ELP_LINEAR_DALIGN_LEFT_TOP = 0;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int ELP_LINEAR_DALIGN_CENTER = 1;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int ELP_LINEAR_DALIGN_RIGHT_BOTTOM = 2;
        /** <summary>
         * 方向:水平
         * </summary>
         **/
        public const int ELP_DIRECTION_H = 0;
        /** <summary>
         * 方向:垂直
         * </summary>
         **/
        public const int ELP_DIRECTION_V = 1;
        /** <summary>
         * 布局属性:方向
         * </summary>
         **/
        public const int ELP_FLOW_DIRECTION = 1;
        /** <summary>
         * 布局属性:当前显示页面索引
         * </summary>
         **/
        public const int ELP_PAGE_CURRENT = 1;
        #endregion

        #region #ELCP_
        /** <summary>
         * 布局属性_通用_外间距_左
         * </summary>
         **/
        public const int ELCP_MARGIN_LEFT = -1;
        /** <summary>
         * 布局属性_通用_外间距_顶
         * </summary>
         **/
        public const int ELCP_MARGIN_TOP = -2;
        /** <summary>
         * 布局属性_通用_外间距_右
         * </summary>
         **/
        public const int ELCP_MARGIN_RIGHT = -3;
        /** <summary>
         * 布局属性_通用_外间距_底
         * </summary>
         **/
        public const int ELCP_MARGIN_BOTTOM = -4;
        /** <summary>
         * 布局子属性:尺寸[-1或未填写为组件当前尺寸]
         * </summary>
         **/
        public const int ELCP_LINEAR_SIZE = 1;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int ELCP_LINEAR_ALGIN_FILL = 0;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int ELCP_LINEAR_ALIGN_LEFT_TOP = 1;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int ELCP_LINEAR_ALIGN_CENTER = 2;
        /** <summary>
         * 暂无注释
         * </summary>
         **/
        public const int ELCP_LINEAR_ALIGN_RIGHT_BOTTOM = 3;
        /** <summary>
         * 布局紫属性:另外一个方向的对齐方式
         * </summary>
         **/
        public const int ELCP_LINEAR_ALIGN = 2;
        /** <summary>
         * 布局子属性:尺寸[-1或未填写为组件当前尺寸]
         * </summary>
         **/
        public const int ELCP_FLOW_SIZE = 1;
        /** <summary>
         * 布局子属性:组件强制换行
         * </summary>
         **/
        public const int ELCP_FLOW_NEW_LINE = 2;
        /** <summary>
         * 布局子属性:是否填充整个布局
         * </summary>
         **/
        public const int ELCP_PAGE_FILL = 1;
        /** <summary>
         * 布局属性_表格_所在行
         * </summary>
         **/
        public const int ELCP_TABLE_ROW = 1;
        /** <summary>
         * 布局属性_表格_所在列
         * </summary>
         **/
        public const int ELCP_TABLE_CELL = 2;
        /** <summary>
         * 布局属性_表格_跨行数
         * </summary>
         **/
        public const int ELCP_TABLE_ROW_SPAN = 3;
        /** <summary>
         * 布局属性_表格_跨列数
         * </summary>
         **/
        public const int ELCP_TABLE_CELL_SPAN = 4;
        /** <summary>
         * 布局属性_表格_是否填满
         * </summary>
         **/
        public const int ELCP_TABLE_FILL = 5;
        /** <summary>
         * 布局属性_相对_左侧于(组件)
         * </summary>
         **/
        public const int ELCP_RELATIVE_LEFT_OF = 1;
        /** <summary>
         * 布局属性_相对_之上于(组件)
         * </summary>
         **/
        public const int ELCP_RELATIVE_TOP_OF = 2;
        /** <summary>
         * 布局属性_相对_右侧于(组件)
         * </summary>
         **/
        public const int ELCP_RELATIVE_RIGHT_OF = 3;
        /** <summary>
         * 布局属性_相对_之下于(组件)
         * </summary>
         **/
        public const int ELCP_RELATIVE_BOTTOM_OF = 4;
        /** <summary>
         * 布局属性_相对_左对齐于(组件)
         * </summary>
         **/
        public const int ELCP_RELATIVE_LEFT_ALIGN_OF = 5;
        /** <summary>
         * 布局属性_相对_顶对齐于(组件)
         * </summary>
         **/
        public const int ELCP_RELATIVE_TOP_ALIGN_OF = 6;
        /** <summary>
         * 布局属性_相对_右对齐于(组件)
         * </summary>
         **/
        public const int ELCP_RELATIVE_RIGHT_ALIGN_OF = 7;
        /** <summary>
         * 布局属性_相对_底对齐于(组件)
         * </summary>
         **/
        public const int ELCP_RELATIVE_BOTTOM_ALIGN_OF = 8;
        /** <summary>
         * 布局属性_相对_水平居中于父
         * </summary>
         **/
        public const int ELCP_RELATIVE_CENTER_PARENT_H = 9;
        /** <summary>
         * 布局属性_相对_垂直居中于父
         * </summary>
         **/
        public const int ELCP_RELATIVE_CENTER_PARENT_V = 10;
        /** <summary>
         * 布局属性_绝对_左侧
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_LEFT = 1;
        /** <summary>
         * 布局属性_绝对_左侧类型
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_LEFT_TYPE = 2;
        /** <summary>
         * 布局属性_绝对_顶部
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_TOP = 3;
        /** <summary>
         * 布局属性_绝对_顶部类型
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_TOP_TYPE = 4;
        /** <summary>
         * 布局属性_绝对_右侧
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_RIGHT = 5;
        /** <summary>
         * 布局属性_绝对_右侧类型
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_RIGHT_TYPE = 6;
        /** <summary>
         * 布局属性_绝对_底部
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_BOTTOM = 7;
        /** <summary>
         * 布局属性_绝对_底部类型
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_BOTTOM_TYPE = 8;
        /** <summary>
         * 布局属性_绝对_宽度（优先级低于右侧）
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_WIDTH = 9;
        /** <summary>
         * 布局属性_绝对_宽度类型
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_WIDTH_TYPE = 10;
        /** <summary>
         * 布局属性_绝对_高度（优先级低于底部）
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_HEIGHT = 11;
        /** <summary>
         * 布局属性_绝对_高度类型
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_HEIGHT_TYPE = 12;
        /** <summary>
         * 布局属性_绝对_水平偏移量
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_OFFSET_H = 13;
        /** <summary>
         * 布局属性_绝对_水平偏移量类型
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_OFFSET_H_TYPE = 14;
        /** <summary>
         * 布局属性_绝对_垂直偏移量
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_OFFSET_V = 15;
        /** <summary>
         * 布局属性_绝对_垂直偏移量类型
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_OFFSET_V_TYPE = 16;
        /** <summary>
         * 布局属性_绝对_类型_未知(未设置或保持不变)
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_TYPE_UNKNOWN = 0;
        /** <summary>
         * 布局属性_绝对_类型_像素
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_TYPE_PX = 1;
        /** <summary>
         * 布局属性_绝对_类型_百分比
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_TYPE_PS = 2;
        /** <summary>
         * 布局属性_绝对_类型_组件尺寸百分比，仅OFFSET可用
         * </summary>
         **/
        public const int ELCP_ABSOLUTE_TYPE_OBJPS = 3;
        #endregion
    }
}
