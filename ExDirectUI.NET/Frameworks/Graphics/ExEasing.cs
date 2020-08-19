using ExDirectUI.NET.Native;
using System;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExEasing
    {
        protected IntPtr m_hEasing;

        public IntPtr Handle => m_hEasing;

        public ExEasing(int dwType, IntPtr pEasingContext, int dwMode, ref int pContext, int nTotalTime, int nInterval, int nState, int nStart, int nStop, ref int param1, ref int param2, ref int param3, ref int param4)
        {
            m_hEasing = (IntPtr)ExAPI._easing_create(dwType, pEasingContext, dwMode, ref pContext, nTotalTime, nInterval, nState, nStart, nStop, ref param1, ref param2, ref param3, ref param4);
        }

        public void CurveFree(IntPtr pCurveInfo)
        {
             ExAPI._easing_curve_free(pCurveInfo);
        }

        public IntPtr CurveLoad(byte[] lpCurveInfo,int cbCurveInfo)
        {
            return ExAPI._easing_curve_load(lpCurveInfo, cbCurveInfo);
        }

        public int State
        {
            get
            {
                return ExAPI._easing_getstate(m_hEasing);
            }
            set
            {
                return ExAPI._easing_setstate(m_hEasing, value);
            }
        }
    }
}
