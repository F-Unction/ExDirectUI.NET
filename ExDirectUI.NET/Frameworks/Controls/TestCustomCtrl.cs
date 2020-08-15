using ExDirectUI.NET.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ExDirectUI.NET.Frameworks.Controls
{
    public class TestCustomCtrl : ExControl
    {
        private static ExObjClassProcDelegate s_pfnObjClassProc = new ExObjClassProcDelegate(
            (IntPtr hWnd, IntPtr hObj, int uMsg, int wParam, int lParam, IntPtr pvData) =>
        {
            ExControl Obj = new ExControl(hObj);
            switch (uMsg)
            {
                case 15: //WM_PAINT
                    {
                        ExPaintStruct ps;
                        Obj.BeginPaint(out ps);

                        ExAPI._canvas_clear(ps.hCanvas, Color.Yellow.ToArgb());

                        Obj.EndPaint(ref ps);
                    }
                    break;
                default:
                    return CallDefProc(hWnd, hObj, uMsg, wParam, lParam);
            }
            return 0;
        });


        public static int RegisterControl()
        {
            return ExAPI.Ex_ObjRegister("TestCustomCtrl", EOS_VISIBLE, EOS_EX_FOCUSABLE, 0, 0, IntPtr.Zero, 0, s_pfnObjClassProc);
        }



        public TestCustomCtrl(IExBaseUIEle pOwner, string sText, int x, int y, int nWidth, int nHeight)
           : base(pOwner, "TestCustomCtrl", sText, x, y, nWidth, nHeight)
        {

        }


        public new string ClassName => "TestCustomCtrl";
    }
}
