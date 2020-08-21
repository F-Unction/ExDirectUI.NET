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
    }
}
