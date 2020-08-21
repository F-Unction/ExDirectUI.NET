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
    }
}
