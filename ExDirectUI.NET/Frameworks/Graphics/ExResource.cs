using ExDirectUI.NET.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDirectUI.NET.Frameworks.Graphics
{
    class ExResource : IDisposable
    {
        protected IntPtr m_hRes;

        public IntPtr Handle => m_hRes;

        public ExResource(string lpwzFile)
        {
            m_hRes = (IntPtr)ExAPI.Ex_ResLoadFromFile(lpwzFile);
        }

        public ExResource(byte[] lpData, int dwDataLen)
        {
            m_hRes = (IntPtr)ExAPI.Ex_ResLoadFromMemory(lpData, dwDataLen);
        }

        public void Dispose()
        {
            ExAPI.Ex_ResFree(m_hRes);
            m_hRes = IntPtr.Zero;
        }

        public bool GetFile(string lpwzPath, out byte[] lpFile, out int dwFileLen)
        {
            return ExAPI.Ex_ResGetFile(m_hRes, lpwzPath, out lpFile, out dwFileLen);
        }

        public bool GetFileFromAtom(int atomPath, byte[] lpFile, int dwFileLen)
        {
            return ExAPI.Ex_ResGetFileFromAtom(m_hRes, atomPath, out lpFile, out dwFileLen);
        }

        static public void Pack(string root, string file, bool fSubDir, char byteHeader, bool bPntBits)
        {
            ExAPI._res_pack(root, file, fSubDir, byteHeader, bPntBits);
        }
    }
}
