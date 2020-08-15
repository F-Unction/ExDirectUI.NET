﻿using ExDirectUI.NET.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExDirectUI.NET.Frameworks
{
    public interface IExBaseUIEle
    {
        int GetLong(int nIndex);
        int SetLong(int nIndex, int nValue);

        int SendMessage(int uMsg, int wParam = 0, int lParam = 0);
        bool PostMessage(int uMsg, int wParam = 0, int lParam = 0);

        bool Move(int x, int y, int nWidth, int nHeight, bool fRedraw = true);
        bool SetPos(int x, int y, int nWidth, int nHeight, IntPtr hEleAfter, int dwFlags);

        bool SetBackgroundImage(byte[] image, int x, int y, int dwRepeat, IntPtr rcGrids, int dwFlags, int dwAlpha, bool fUpdate);

        bool SetBackgroundPlayState(bool fPlayFrames, bool fResetFrame, bool fUpdate);
        bool GetBackgroundImage(out ExBackgroundImageInfo pImageInfo);

        ExControl GetObjFromID(int id);
        ExControl GetObjFromName(string name);
        ExControl GetObjFromNodeID(int nodeid);

        ExControl GetFocus();

        bool TrackPopupMenu(IntPtr hMenu, int uFlags, int x, int y, int nReserved, ref ExRect pRc, ExWndProcDelegate pfnWndProc, int dwFlags);

        bool LoadLayoutXml(byte[] pLayout, IntPtr hRes);

        ExControl Find(ExControl pObjChildAfter = null, string sClassName = null, string sTitle = null);



        bool Validate { get; }

        bool Enable { get; set; }
        bool Visible { get; set; }
        IntPtr Handle { get; }

        string Text { get; set; }

    }
}
