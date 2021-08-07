using ExDirectUI.NET.Native;
using System;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    public class ExEasing : IDisposable
    {
        protected IntPtr m_hEasing;

        public IntPtr Handle => m_hEasing;


        public ExEasing(int dwType, IntPtr pEasingContext, int dwMode, IntPtr pContext, int nTotalTime, int nInterval, int nState, int nStart, int nStop, int param1, int param2, int param3, int param4)
        {
            m_hEasing = (IntPtr)ExAPI._easing_create(dwType, pEasingContext, dwMode, pContext, nTotalTime, nInterval, nState, nStart, nStop, param1, param2, param3, param4);
        }

        public ExEasing(int dwType, IntPtr pEasingContext, int dwMode, ExEasingContextDelegate pContext, int nTotalTime, int nInterval, int nState, int nStart, int nStop, int param1, int param2, int param3, int param4)
        {
            m_hEasing = (IntPtr)ExAPI._easing_create(dwType, pEasingContext, dwMode, pContext, nTotalTime, nInterval, nState, nStart, nStop, param1, param2, param3, param4);
        }

        public ExEasing(int dwType, ExEasingEasingContextDelegate pEasingContext, int dwMode, IntPtr pContext, int nTotalTime, int nInterval, int nState, int nStart, int nStop, int param1, int param2, int param3, int param4)
        {
            m_hEasing = (IntPtr)ExAPI._easing_create(dwType, pEasingContext, dwMode, pContext, nTotalTime, nInterval, nState, nStart, nStop, param1, param2, param3, param4);
        }

        public ExEasing(int dwType, ExEasingEasingContextDelegate pEasingContext, int dwMode, ExEasingContextDelegate pContext, int nTotalTime, int nInterval, int nState, int nStart, int nStop, int param1, int param2, int param3, int param4)
        {
            m_hEasing = (IntPtr)ExAPI._easing_create(dwType, pEasingContext, dwMode, pContext, nTotalTime, nInterval, nState, nStart, nStop, param1, param2, param3, param4);
        }

        public ExEasing(IntPtr hEasing)
        {
            m_hEasing = hEasing;
        }

        public void CurveFree(IntPtr pCurveInfo)
        {
             ExAPI._easing_curve_free(pCurveInfo);
        }

        public IntPtr CurveLoad(byte[] lpCurveInfo,int cbCurveInfo)
        {
            return ExAPI._easing_curve_load(lpCurveInfo, cbCurveInfo);
        }

        public void Dispose()
        {
            ExAPI._easing_setstate(m_hEasing,ExConst.EES_STOP);
        }

        public int State
        {
            get
            {
                return ExAPI._easing_getstate(m_hEasing);
            }
            set
            {
                ExAPI._easing_setstate(m_hEasing, value);
            }
        }
    }
}
