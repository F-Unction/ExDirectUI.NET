using ExDirectUI.NET.Frameworks;
using ExDirectUI.NET.Frameworks.Controls;
using ExDirectUI.NET.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExDirectUI.NET.Debug
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //读入主题包
            byte[] theme = File.ReadAllBytes(".\\Default.ext");

            //初始化应用程序对象
            ExApp theApp = new ExApp(theme);

            //创建ExDUI窗口
            ExSkin skin = new ExSkin(null, null, "你好世界", 0, 0, 600, 400,
                ExSkin.EWS_BUTTON_CLOSE | ExSkin.EWS_BUTTON_MIN | ExSkin.EWS_CENTERWINDOW | ExSkin.EWS_HASICON |
                ExSkin.EWS_TITLE | ExSkin.EWS_MOVEABLE | ExSkin.EWS_MAINWINDOW
                );
            if (skin.Validate)
            {
                TestCustomCtrl.RegisterControl();

                //设置背景色
                skin.SetLong(ExSkin.EWL_CRBKG, Color.Blue.ToArgb());

                //ExBaseCtrl ctrl1 = new ExBaseCtrl(skin, "Button", "你好", 50, 50, 200, 35);
                ExButton btn1 = new ExButton(skin, "你好", 50, 50, 150, 40);

                byte[] img = File.ReadAllBytes(".\\Res\\bkg.png");
                ExStatic img1 = new ExStatic(skin, img, 50, 110, 300, 200);
                img1.SetBackgroundPlayState(true, false, false);

                ExEdit edit1 = new ExEdit(img1, "测试", 25, 25, 100, 30);

                TestCustomCtrl custom = new TestCustomCtrl(skin, "abc", 360, 110, 50, 50);


                //挂接事件
                btn1.HandleEvent(ExControl.NM_CLICK,
                    //lambda delegate
                    (IntPtr hObj, int nID, int nCode, int wParam, int lParam) =>
                    {
                        ExMessageBox.Show(new ExControl(hObj), "单击按钮" + skin.Text, btn1.ClassName, ExMessageBox.MB_ICONINFORMATION, 0);

                        btn1.Text = "测试";

                        return false;
                    }
                );

                //显示
                skin.Visible = true;

                //运行程序
                theApp.Run();
            }

        }

        


    }
}
