using ExDirectUI.NET.Native;
using System;

namespace ExDirectUI.NET.Frameworks
{
    public class ExApp
    {
        public ExApp(byte[] theme, int dwGlobalFlags = 0)
        {
            if (theme != null)
            {

                IntPtr hInstance = WinAPI.GetModuleHandle(null);
                if (hInstance != IntPtr.Zero)
                {
                    if (ExAPI.Ex_Init(hInstance, dwGlobalFlags, IntPtr.Zero, null, theme, theme.Length, null, 0))
                    {
                    }
                    else throw new ExException(-1, "引擎初始化失败");
                }
                else throw new ExException(ExStatus.HANDLE_INVALID, "实例句柄获取失败");
            }
            else throw new ExException(ExStatus.MEMORY_BADPTR, "参数错误");
        }

        ~ExApp()
        {
            ExAPI.Ex_UnInit();
        }

        public int Run()
        {
            return ExAPI.Ex_WndMsgLoop();
        }

        public int LastError { get => ExAPI.Ex_GetLastError(); set => ExAPI.Ex_SetLastError(value); }






        #region EXGF_
        /** <summary>
         * 启用DPI缩放
         * </summary>
         **/
        public const int EXGF_DPI_ENABLE = 2;

        /** <summary>
         * 画布_不抗锯齿
         * </summary>
         **/
        public const int EXGF_RENDER_CANVAS_ALIAS = 64;

        /** <summary>
         * 使用GDI/GDI+渲染
         * </summary>
         **/
        public const int EXGF_RENDER_METHOD_GDI = 128;

        /** <summary>
         * 使用D2D渲染
         * </summary>
         **/
        public const int EXGF_RENDER_METHOD_D2D = 256;

        /** <summary>
         * 使用支持GDI交互的D2D渲染
         * </summary>
         **/
        public const int EXGF_RENDER_METHOD_D2D_GDI_COMPATIBLE = 768;

        /** <summary>
         * 禁用动画效果
         * </summary>
         **/
        public const int EXGF_OBJECT_DISABLEANIMATION = 65536;

        /** <summary>
         * 显示组件边界
         * </summary>
         **/
        public const int EXGF_OBJECT_SHOWRECTBORDER = 131072;

        /** <summary>
         * 显示组件位置
         * </summary>
         **/
        public const int EXGF_OBJECT_SHOWPOSTION = 262144;

        /** <summary>
         * 允许JS全局对象访问文件
         * </summary>
         **/
        public const int EXGF_JS_FILE = 524288;

        /** <summary>
         * 允许JS全局对象访问内存
         * </summary>
         **/
        public const int EXGF_JS_MEMORY = 1048576;

        /** <summary>
         * 允许JS全局对象申请内存
         * </summary>
         **/
        public const int EXGF_JS_MEMORY_ALLOC = 2097152;

        /** <summary>
         * 允许JS全局对象创建进程、允许程序、加载DLL
         * </summary>
         **/
        public const int EXGF_JS_PROCESS = 4194304;

        /** <summary>
         * 允许JS全局对象访问所有资源
         * </summary>
         **/
        public const int EXGF_JS_ALL = 7864320;

        /** <summary>
         * 渲染所有菜单
         * </summary>
         **/
        public const int EXGF_MENU_ALL = 8388608;
        #endregion

    }
}
