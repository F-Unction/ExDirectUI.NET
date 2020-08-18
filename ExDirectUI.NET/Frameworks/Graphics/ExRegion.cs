using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExRegion
    {
        protected IntPtr m_hRgn;

        public IntPtr Handle => m_hRgn;
    }
}
