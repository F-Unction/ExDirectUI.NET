using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using static ExDirectUI.NET.Native.WinAPI;

namespace ExDirectUI.NET.Native
{
    public delegate bool ExWndProcDelegate(IntPtr hWnd, IntPtr hExDUI, int uMsg, int wParam, int lParam, IntPtr pResult);
    public delegate bool ExObjProcDelegate(IntPtr hWnd, IntPtr hObj, int uMsg, int wParam, int lParam, IntPtr pResult);
    public delegate int ExObjClassProcDelegate(IntPtr hWnd, IntPtr hObj, int uMsg, int wParam, int lParam, IntPtr pvData);
    public delegate bool ExObjEventProcDelegate(IntPtr hObj, int nID, int nCode, int wParam, int lParam);
    //public delegate bool ExI18NCallbackDelegate(int atomID, out string ppString);
    public delegate int ExLayoutProcDelegate(IntPtr pLayout, int nEvent, int wParam, int lParam);
    public delegate bool ExObjEnumCallbackDelegate(IntPtr hObj, int lParam);
    public delegate bool ExObjPropEnumCallbackDelegate(IntPtr hObj, int nKey, int nValue, int lParam);

    public struct ExRectF
    {
        public float nLeft;
        public float nTop;
        public float nRight;
        public float nBottom;
    }

    public struct ExRect
    {
        public int nLeft;
        public int nTop;
        public int nRight;
        public int nBottom;
    }

    public struct ExPaintStruct
    {
        public IntPtr hCanvas;
        public IntPtr hTheme;
        public int dwStyle;
        public int dwStyleEx;
        public int dwTextFormat;
        public int dwState;
        public IntPtr dwOwnerData;
        public int nWidth;
        public int nHeight;
        public ExRect rcPaint;
        public ExRect rcText;
        public int dwReserved;
    }

    public struct ExCustomDraw
    {
        public IntPtr hCanvas;
        public IntPtr hTheme;
        public int dwState;
        public int dwStyle;
        public int nLeft;
        public int nTop;
        public int nRight;
        public int nBottom;
        public int iItem;
        public int nItemParam;
    }

    public struct ExBackgroundImageInfo
    {
        public int dwFlags;
        public IntPtr hImage;
        public int x;
        public int y;
        public int dwRepeat;
        public IntPtr lpGrid;
        public IntPtr lpDelay;
        public int nCurFrame;
        public int nMaxFrame;
        public int nAlpha;
    }

    public struct ExClassInfo
    {
        public int dwFlags;
        public int dwStyle;
        public int dwStyleEx;
        public int dwTextFormat;
        public int cbObjExtra;
        public IntPtr hCursor;
        public IntPtr pfnProc;
        public int atomName;
    }

    public struct ExNotifyHeader
    {
        public IntPtr hObjFrom;
        public int idFrom;
        public int nCode;
        public int wParam;
        public int lParam;
    }

    public struct ExEasingInfo
    {
        public IntPtr pEasing;
        public double nProgress;
        public double nCurrent;
        public int nParam;
        public int nLastTimes;
        public int nParam1;
        public int nParam2;
        public int nParam3;
        public int nParam4;
    }

    public struct ExBitmapData
    {
        public int nWidth;
        public int nHeight;
        public int nStride;
        public int nPixelFormat;
        public IntPtr pScan0;
        public int nReserved;
    }

    public class ExAPI
    {

        /** <summary>
         * 初始化引擎.
         * </summary>
         * <param name="hInstance">(值可为0)</param>
         * <param name="dwGlobalFlags">相关常量:#EXGF_ .(值可为0)</param>
         * <param name="hDefaultCursor">默认鼠标指针.(值可为0)</param>
         * <param name="lpszDefaultClassName">默认窗口类名.(值可为0)</param>
         * <param name="lpDefaultTheme">默认主题包指针.</param>
         * <param name="dwDefaultThemeLen">默认主题包长度.</param>
         * <param name="lpDefaultI18N">默认语言包指针.(值可为0)</param>
         * <param name="dwDefaultI18NLen">默认语言包长度.(值可为0)</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_Init")]
        public static extern bool Ex_Init(IntPtr hInstance, int dwGlobalFlags, IntPtr hDefaultCursor,
            string lpszDefaultClassName, byte[] lpDefaultTheme, int dwDefaultThemeLen, byte[] lpDefaultI18N, int dwDefaultI18NLen);

        /** <summary>
         * 反初始化引擎
         * </summary>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_UnInit")]
        public static extern void Ex_UnInit();

        /** <summary>
         * 获取最后错误代码.相关常量 :#ERROR_EX_
         * </summary>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_GetLastError")]
        public static extern int Ex_GetLastError();

        /** <summary>
         * 创建自内存。成功返回0。
         * </summary>
         * <param name="lpData">图像指针</param>
         * <param name="dwLen">图像长度</param>
         * <param name="hImg">返回图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_createfrommemory")]
        public static extern int _img_createfrommemory(byte[] lpData, int dwLen, out IntPtr hImg);

        /** <summary>
         * 创建图像。成功返回0。
         * </summary>
         * <param name="width">图像宽度</param>
         * <param name="height">图像高度</param>
         * <param name="hImg">返回图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_create")]
        public static extern int _img_create(int width, int height, out IntPtr hImg);

        /** <summary>
         * 锁定图像.成功返回0.
         * </summary>
         * <param name="hImg"></param>
         * <param name="lpRectL">锁定矩形指针，如果为0，则锁定整张图像。</param>
         * <param name="flags">READ:1 / WRITE:2 / READ&WRITE:3</param>
         * <param name="PixelFormat">参考:https://msdn.microsoft.com/en-us/library/ms534412(v=vs.85).aspx</param>
         * <param name="lpLockedBitmapData">BITMAPDATA</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_lock")]
        public static extern int _img_lock(IntPtr hImg, ref int lpRectL, int flags, int PixelFormat, ref ExBitmapData lpLockedBitmapData);

        /** <summary>
         * 解锁图像.成功返回0.
         * </summary>
         * <param name="hImg"></param>
         * <param name="lpLockedBitmapData"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_unlock")]
        public static extern int _img_unlock(IntPtr hImg, ref ExBitmapData lpLockedBitmapData);

        /** <summary>
         * 销毁图像
         * </summary>
         * <param name="hImg"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_destroy")]
        public static extern int _img_destroy(IntPtr hImg);

        /** <summary>
         * 设置最后错误代码.相关常量 :#ERROR_EX_
         * </summary>
         * <param name="nError"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_SetLastError")]
        public static extern void Ex_SetLastError(int nError);

        /** <summary>
         * 取图像帧数。成功返回0。
         * </summary>
         * <param name="hImg"></param>
         * <param name="nFrameCount">返回帧数.</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_getframecount")]
        public static extern int _img_getframecount(IntPtr hImg, out int nFrameCount);

        /** <summary>
         * 设置当前活动帧。成功返回0。
         * </summary>
         * <param name="hImg"></param>
         * <param name="nIndex"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_selectactiveframe")]
        public static extern int _img_selectactiveframe(IntPtr hImg, int nIndex);

        /** <summary>
         * 创建自字节流。成功返回0。
         * </summary>
         * <param name="lpStream"></param>
         * <param name="hImg">返回图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_createfromstream")]
        public static extern int _img_createfromstream(IStream lpStream, out IntPtr hImg);

        /** <summary>
         * (拷贝)创建自画布。成功返回0。
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hImg">返回图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_createfromcanvas")]
        public static extern int _img_createfromcanvas(IntPtr hCanvas, out IntPtr hImg);

        /** <summary>
         * 取图像帧延时。成功返回0。
         * </summary>
         * <param name="hImg"></param>
         * <param name="lpDelayAry">指针指向图像帧延时数组。</param>
         * <param name="nFrames">返回总帧数</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_getframedelay")]
        public static extern int _img_getframedelay(IntPtr hImg, int[] lpDelayAry, out int nFrames);

        /** <summary>
         * 获取图像尺寸.成功返回0
         * </summary>
         * <param name="hImg"></param>
         * <param name="lpWidth"></param>
         * <param name="lpHeight"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_getsize")]
        public static extern int _img_getsize(IntPtr hImg, out int lpWidth, out int lpHeight);

        /** <summary>
         * 是否使用D2D渲染
         * </summary>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_IsDxRender")]
        public static extern bool Ex_IsDxRender();

        /** <summary>
         * 返回宽度
         * </summary>
         * <param name="hImg"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_width")]
        public static extern int _img_width(IntPtr hImg);

        /** <summary>
         * 返回高度
         * </summary>
         * <param name="hImg"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_height")]
        public static extern int _img_height(IntPtr hImg);

        /** <summary>
         * 复制图像.成功返回0
         * </summary>
         * <param name="hImg"></param>
         * <param name="dstImg">返回新图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_copy")]
        public static extern int _img_copy(IntPtr hImg, out IntPtr dstImg);

        /** <summary>
         * 复制部分图像.成功返回0
         * </summary>
         * <param name="hImg"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         * <param name="width"></param>
         * <param name="height"></param>
         * <param name="dstImg">返回新图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_copyrect")]
        public static extern int _img_copyrect(IntPtr hImg, int x, int y, int width, int height, out IntPtr dstImg);

        /** <summary>
         * 创建自GDI位图句柄。成功返回0。
         * </summary>
         * <param name="hBitmap"></param>
         * <param name="hPalette"></param>
         * <param name="fPreAlpha">是否预乘透明通道</param>
         * <param name="hImg">返回图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_createfromhbitmap")]
        public static extern int _img_createfromhbitmap(IntPtr hBitmap, IntPtr hPalette, bool fPreAlpha, out IntPtr hImg);

        /** <summary>
         * 创建自图标句柄。成功返回0。
         * </summary>
         * <param name="hIcon"></param>
         * <param name="hImg">返回图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_createfromhicon")]
        public static extern int _img_createfromhicon(IntPtr hIcon, out IntPtr hImg);

        /** <summary>
         * 创建自文件。成功返回0。
         * </summary>
         * <param name="wzFilename"></param>
         * <param name="hImg">返回图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_createfromfile")]
        public static extern int _img_createfromfile(string wzFilename, out IntPtr hImg);

        /** <summary>
         * 获取点像素
         * </summary>
         * <param name="hImg"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         * <param name="color">返回ARGB颜色</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_getpixel")]
        public static extern int _img_getpixel(IntPtr hImg, int x, int y, out int color);

        /** <summary>
         * 设置点像素.成功返回0
         * </summary>
         * <param name="hImg"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         * <param name="color">argb</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_setpixel")]
        public static extern int _img_setpixel(IntPtr hImg, int x, int y, int color);

        /** <summary>
         * 旋转翻转图像.成功返回0
         * </summary>
         * <param name="hImg"></param>
         * <param name="rfType">参考:https://msdn.microsoft.com/en-us/library/windows/desktop/ms534171(v=vs.85).aspx</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_rotateflip")]
        public static extern int _img_rotateflip(IntPtr hImg, int rfType);

        /** <summary>
         * 取缩略图.成功返回0
         * </summary>
         * <param name="hImg"></param>
         * <param name="thumbWidth"></param>
         * <param name="thumbHeight"></param>
         * <param name="hImgThumbnail">返回缩略图图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_getthumbnail")]
        public static extern int _img_getthumbnail(IntPtr hImg, int thumbWidth, int thumbHeight, out IntPtr hImgThumbnail);

        /** <summary>
         * 重新设置尺寸。
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="width"></param>
         * <param name="height"></param>
         * <param name="fCopy"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_resize")]
        public static extern bool _canvas_resize(IntPtr hCanvas, int width, int height, bool fCopy);

        /** <summary>
         * 获取canvas上下文相关信息
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="nType">#CVC_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_getcontext")]
        public static extern int _canvas_getcontext(IntPtr hCanvas, int nType);

        /** <summary>
         * 绑定窗口
         * </summary>
         * <param name="hWnd">窗口句柄</param>
         * <param name="hTheme">主题句柄.(值可为0)</param>
         * <param name="dwStyle">相关常量:#EWS_</param>
         * <param name="lParam">附加参数.(值可为0)</param>
         * <param name="lpfnMsgProc">(BOOL)MsgProc(hWnd</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUIBindWindowEx")]
        public static extern IntPtr Ex_DUIBindWindowEx(IntPtr hWnd, IntPtr hTheme, int dwStyle, int lParam, ExWndProcDelegate lpfnMsgProc);

        /** <summary>
         * 创建画布自组件句柄。成功返回画布句柄，失败返回0
         * </summary>
         * <param name="hObj"></param>
         * <param name="uWidth"></param>
         * <param name="uHeight"></param>
         * <param name="dwFlags">CVF_</param>
         * <param name="nError"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_createfromobj")]
        public static extern int _canvas_createfromobj(IntPtr hObj, int uWidth, int uHeight, int dwFlags, out int nError);

        /** <summary>
         * 注册窗口类
         * </summary>
         * <param name="lpwzClassName"></param>
         * <param name="hIcon"></param>
         * <param name="hIconsm"></param>
         * <param name="hCursor"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_WndRegisterClass")]
        public static extern int Ex_WndRegisterClass(string lpwzClassName, IntPtr hIcon, IntPtr hIconsm, IntPtr hCursor);

        /** <summary>
         * 创建窗口
         * </summary>
         * <param name="hWndParent"></param>
         * <param name="lpwzClassName"></param>
         * <param name="lpwzWindowName"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         * <param name="Width"></param>
         * <param name="Height"></param>
         * <param name="dwStyle"></param>
         * <param name="dwStyleEx"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_WndCreate")]
        public static extern IntPtr Ex_WndCreate(IntPtr hWndParent, string lpwzClassName, string lpwzWindowName, int x, int y, int Width, int Height, int dwStyle, int dwStyleEx);

        /** <summary>
         * 窗口消息循环
         * </summary>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_WndMsgLoop")]
        public static extern int Ex_WndMsgLoop();

        /** <summary>
         * 窗口居中
         * </summary>
         * <param name="hWnd">预居中的原始窗口</param>
         * <param name="hWndFrom">预居中的目标窗口</param>
         * <param name="bFullScreen">是否全屏模式</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_WndCenterFrom")]
        public static extern void Ex_WndCenterFrom(IntPtr hWnd, IntPtr hWndFrom, bool bFullScreen);

        /** <summary>
         * 显示窗口
         * </summary>
         * <param name="hExDui">引擎句柄</param>
         * <param name="nCmdShow">相关常量:#SW_</param>
         * <param name="dwTimer">动画时间间隔.(ms)</param>
         * <param name="dwFrames">动画总帧数.</param>
         * <param name="dwFlags">动画标记.#EXA_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUIShowWindow")]
        public static extern bool Ex_DUIShowWindow(IntPtr hExDui, int nCmdShow, int dwTimer, int dwFrames, int dwFlags);

        /** <summary>
         * 显示窗口
         * </summary>
         * <param name="hExDui">引擎句柄</param>
         * <param name="nCmdShow">相关常量:#SW_</param>
         * <param name="dwTimer">动画时间间隔.(ms)</param>
         * <param name="dwFrames">动画总帧数.</param>
         * <param name="dwFlags">动画标记.#EXA_</param>
         * <param name="uEasing">#缓动类型_</param>
         * <param name="wParam">参数1</param>
         * <param name="lParam">参数2</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUIShowWindowEx")]
        public static extern bool Ex_DUIShowWindowEx(IntPtr hExDui, int nCmdShow, int dwTimer, int dwFrames, int dwFlags, int uEasing, int wParam, int lParam);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_destroy")]
        public static extern bool _canvas_destroy(IntPtr hCanvas);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_enddraw")]
        public static extern bool _canvas_enddraw(IntPtr hCanvas);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="lColor"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_clear")]
        public static extern bool _canvas_clear(IntPtr hCanvas, int nColor);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_getdc")]
        public static extern int _canvas_getdc(IntPtr hCanvas);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_releasedc")]
        public static extern bool _canvas_releasedc(IntPtr hCanvas);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas">0</param>
         * <param name="hImage">4</param>
         * <param name="left">8</param>
         * <param name="top">12</param>
         * <param name="alpha">16</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawimage")]
        public static extern bool _canvas_drawimage(IntPtr hCanvas, IntPtr hImage, float left, float top, int alpha);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hImage"></param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         * <param name="alpha"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawimagerect")]
        public static extern bool _canvas_drawimagerect(IntPtr hCanvas, IntPtr hImage, float left, float top, float right, float bottom, int alpha);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas">0</param>
         * <param name="hImage">4</param>
         * <param name="dstLeft">8</param>
         * <param name="dstTop">12</param>
         * <param name="dstRight">16</param>
         * <param name="dstBottom">20</param>
         * <param name="srcLeft">24</param>
         * <param name="srcTop">28</param>
         * <param name="srcRight">32</param>
         * <param name="srcBottom">36</param>
         * <param name="alpha">40</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawimagerectrect")]
        public static extern bool _canvas_drawimagerectrect(IntPtr hCanvas, IntPtr hImage, float dstLeft, float dstTop, float dstRight, float dstBottom, float srcLeft, float srcTop, float srcRight, float srcBottom, int alpha);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hImage"></param>
         * <param name="dstLeft"></param>
         * <param name="dstTop"></param>
         * <param name="dstRight"></param>
         * <param name="dstBottom"></param>
         * <param name="srcLeft"></param>
         * <param name="srcTop"></param>
         * <param name="srcRight"></param>
         * <param name="srcBottom"></param>
         * <param name="gridPaddingLeft"></param>
         * <param name="gridPaddingTop"></param>
         * <param name="gridPaddingRight"></param>
         * <param name="gridPaddingBottom"></param>
         * <param name="dwFlags">#bif_</param>
         * <param name="dwAlpha"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawimagefromgrid")]
        public static extern bool _canvas_drawimagefromgrid(IntPtr hCanvas, IntPtr hImage, float dstLeft, float dstTop, float dstRight, float dstBottom, float srcLeft, float srcTop, float srcRight, float srcBottom, float gridPaddingLeft, float gridPaddingTop, float gridPaddingRight, float gridPaddingBottom, int dwFlags, int dwAlpha);

        /** <summary>
         * 组件默认过程
         * </summary>
         * <param name="hWnd"></param>
         * <param name="hObj"></param>
         * <param name="uMsg"></param>
         * <param name="wParam"></param>
         * <param name="lParam"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjDefProc")]
        public static extern int Ex_ObjDefProc(IntPtr hWnd, IntPtr hObj, int uMsg, int wParam, int lParam);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hBrush"></param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_fillrect")]
        public static extern bool _canvas_fillrect(IntPtr hCanvas, IntPtr hBrush, float left, float top, float right, float bottom);

        /** <summary>
         * 
         * </summary>
         * <param name="argb"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_brush_create")]
        public static extern int _brush_create(int argb);

        /** <summary>
         * 
         * </summary>
         * <param name="xs"></param>
         * <param name="ys"></param>
         * <param name="xe"></param>
         * <param name="ye"></param>
         * <param name="crBegin"></param>
         * <param name="crEnd"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_brush_createlinear")]
        public static extern int _brush_createlinear(float xs, float ys, float xe, float ye, int crBegin, int crEnd);

        /** <summary>
         * 
         * </summary>
         * <param name="xs"></param>
         * <param name="ys"></param>
         * <param name="xe"></param>
         * <param name="ye"></param
         * <param name="arrStopPts"></param>
         * <param name="cStopPts"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_brush_createlinear_ex")]
        public static extern int _brush_createlinear_ex(float xs, float ys, float xe, float ye, int arrStopPts, int cStopPts);

        /** <summary>
         * 
         * </summary>
         * <param name="hBrush"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_brush_destroy")]
        public static extern int _brush_destroy(IntPtr hBrush);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hBrush"></param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         * <param name="strokeWidth"></param>
         * <param name="strokeStyle"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawrect")]
        public static extern bool _canvas_drawrect(IntPtr hCanvas, IntPtr hBrush, float left, float top, float right, float bottom, float strokeWidth, int strokeStyle);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hBrush"></param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         * <param name="radiusX"></param>
         * <param name="radiusY"></param>
         * <param name="strokeWidth"></param>
         * <param name="strokeStyle"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawroundedrect")]
        public static extern bool _canvas_drawroundedrect(IntPtr hCanvas, IntPtr hBrush, float left, float top, float right, float bottom, float radiusX, float radiusY, float strokeWidth, int strokeStyle);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hBrush"></param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         * <param name="radiusX"></param>
         * <param name="radiusY"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_fillroundedrect")]
        public static extern bool _canvas_fillroundedrect(IntPtr hCanvas, IntPtr hBrush, float left, float top, float right, float bottom, float radiusX, float radiusY);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hBrush"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         * <param name="radiusX"></param>
         * <param name="radiusY"></param>
         * <param name="strokeWidth"></param>
         * <param name="strokeStyle"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawellipse")]
        public static extern bool _canvas_drawellipse(IntPtr hCanvas, IntPtr hBrush, float x, float y, float radiusX, float radiusY, float strokeWidth, int strokeStyle);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hBrush"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         * <param name="radiusX"></param>
         * <param name="radiusY"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_fillellipse")]
        public static extern bool _canvas_fillellipse(IntPtr hCanvas, IntPtr hBrush, float x, float y, float radiusX, float radiusY);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hBrush"></param>
         * <param name="X1"></param>
         * <param name="Y1"></param>
         * <param name="X2"></param>
         * <param name="Y2"></param>
         * <param name="strokeWidth"></param>
         * <param name="strokeStyle"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawline")]
        public static extern bool _canvas_drawline(IntPtr hCanvas, IntPtr hBrush, float X1, float Y1, float X2, float Y2, float strokeWidth, int strokeStyle);

        /** <summary>
         * 注册组件.失败返回0
         * </summary>
         * <param name="lptszClassName">组件类名.最大允许长度:MAX_CLASS_NAME_LEN</param>
         * <param name="dwStyle">组件默认风格</param>
         * <param name="dwStyleEx">组件默认扩展风格</param>
         * <param name="dwTextFormat">相关常量 DT_</param>
         * <param name="cbObjExtra">组件额外分配字节数(值可为0)</param>
         * <param name="hCursor">组件默认鼠标指针句柄(值可为0)</param>
         * <param name="dwFlags">类标志 #ECF_(值可为0)</param>
         * <param name="pfnObjProc">组件默认回调</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjRegister")]
        public static extern int Ex_ObjRegister(string lptszClassName, int dwStyle, int dwStyleEx, int dwTextFormat, int cbObjExtra, IntPtr hCursor, int dwFlags, ExObjClassProcDelegate pfnObjProc);

        /** <summary>
         * 创建组件.
         * </summary>
         * <param name="lptszClassName">组件类名</param>
         * <param name="lptszObjTitle">组件标题</param>
         * <param name="dwStyle">组件风格 相关常量 EOS_</param>
         * <param name="x">左边</param>
         * <param name="y">顶边</param>
         * <param name="width">宽度</param>
         * <param name="height">高度</param>
         * <param name="hParent">父组件句柄</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjCreate")]
        public static extern IntPtr Ex_ObjCreate(string lptszClassName, string lptszObjTitle, int dwStyle, int x, int y, int width, int height, IntPtr hParent);

        /** <summary>
         * 创建组件.
         * </summary>
         * <param name="dwStyleEx">组件扩展风格 相关常量 EOS_EX_</param>
         * <param name="lptszClassName">组件类名</param>
         * <param name="lptszObjTitle">组件标题</param>
         * <param name="dwStyle">组件风格 相关常量 EOS_</param>
         * <param name="x">左边</param>
         * <param name="y">顶边</param>
         * <param name="width">宽度</param>
         * <param name="height">高度</param>
         * <param name="hParent">父组件句柄</param>
         * <param name="nID"></param>
         * <param name="dwTextFormat">相关常量 DT_</param>
         * <param name="lParam">附加参数</param>
         * <param name="hTheme">主题句柄.0为默认</param>
         * <param name="lpfnMsgProc">(BOOL)MsgProc(hWnd</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjCreateEx")]
        public static extern IntPtr Ex_ObjCreateEx(int dwStyleEx, string lptszClassName, string lptszObjTitle, int dwStyle, int x, int y, int width, int height, IntPtr hParent, int nID, int dwTextFormat, int lParam, IntPtr hTheme, ExObjProcDelegate lpfnMsgProc);

        /** <summary>
         * 
         * </summary>
         * <param name="n"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_Scale")]
        public static extern float Ex_Scale(float n);

        /** <summary>
         * 
         * </summary>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_rgn_createfromrect")]
        public static extern int _rgn_createfromrect(float left, float top, float right, float bottom);

        /** <summary>
         * 
         * </summary>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         * <param name="radiusX"></param>
         * <param name="radiusY"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_rgn_createfromroundrect")]
        public static extern int _rgn_createfromroundrect(float left, float top, float right, float bottom, float radiusX, float radiusY);

        /** <summary>
         * 
         * </summary>
         * <param name="hRgn"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_rgn_destroy")]
        public static extern bool _rgn_destroy(IntPtr hRgn);

        /** <summary>
         * 
         * </summary>
         * <param name="hRgnSrc"></param>
         * <param name="hRgnDst"></param>
         * <param name="nCombineMode">#RGN_COMBINE_</param>
         * <param name="dstOffsetX"></param>
         * <param name="dstOffsetY"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_rgn_combine")]
        public static extern int _rgn_combine(IntPtr hRgnSrc, IntPtr hRgnDst, int nCombineMode, int dstOffsetX, int dstOffsetY);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hRgn"></param>
         * <param name="hBrush"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_fillregion")]
        public static extern bool _canvas_fillregion(IntPtr hCanvas, IntPtr hRgn, IntPtr hBrush);

        /** <summary>
         * 
         * </summary>
         * <param name="hRgn"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_rgn_hittest")]
        public static extern bool _rgn_hittest(IntPtr hRgn, float x, float y);

        /** <summary>
         * 销毁组件
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjDestroy")]
        public static extern int Ex_ObjDestroy(IntPtr hObj);

        /** <summary>
         * 发送消息
         * </summary>
         * <param name="hObj"></param>
         * <param name="uMsg"></param>
         * <param name="wParam"></param>
         * <param name="lParam"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSendMessage")]
        public static extern int Ex_ObjSendMessage(IntPtr hObj, int uMsg, int wParam, int lParam);

        /** <summary>
         * 开始绘制
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpPS"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjBeginPaint")]
        public static extern bool Ex_ObjBeginPaint(IntPtr hObj, out ExPaintStruct lpPS);

        /** <summary>
         * 结束绘制
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpPS"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjEndPaint")]
        public static extern bool Ex_ObjEndPaint(IntPtr hObj, ref ExPaintStruct lpPS);

        /** <summary>
         * 获取组件矩形
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpRect"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetRect")]
        public static extern bool Ex_ObjGetRect(IntPtr hObj, out ExRect lpRect);

        /** <summary>
         * 客户区坐标到窗口坐标
         * </summary>
         * <param name="hObj"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjClientToWindow")]
        public static extern bool Ex_ObjClientToWindow(IntPtr hObj, ref int x, ref int y);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_cliprect")]
        public static extern bool _canvas_cliprect(IntPtr hCanvas, int left, int top, int right, int bottom);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_resetclip")]
        public static extern bool _canvas_resetclip(IntPtr hCanvas);

        /** <summary>
         * 客户区坐标到屏幕坐标
         * </summary>
         * <param name="hObj"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjClientToScreen")]
        public static extern bool Ex_ObjClientToScreen(IntPtr hObj, ref int x, ref int y);

        /** <summary>
         * 设置重画区域
         * </summary>
         * <param name="hObj"></param>
         * <param name="lprcRedraw"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjInvalidateRect")]
        public static extern bool Ex_ObjInvalidateRect(IntPtr hObj, ref ExRect lprcRedraw);

        /** <summary>
         * 设置重画区域
         * </summary>
         * <param name="hObj"></param>
         * <param name="lprcRedraw"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjInvalidateRect")]
        public static extern bool Ex_ObjInvalidateRect(IntPtr hObj, IntPtr rcRedraw);

        /** <summary>
         * 立即更新组件
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjUpdate")]
        public static extern bool Ex_ObjUpdate(IntPtr hObj);

        /** <summary>
         * 获取组件客户区矩形
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpRect"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetClientRect")]
        public static extern bool Ex_ObjGetClientRect(IntPtr hObj, out ExRect lpRect);

        /** <summary>
         * 设置组件可用状态.
         * </summary>
         * <param name="hObj">组件句柄</param>
         * <param name="fEnable">是否可用</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjEnable")]
        public static extern bool Ex_ObjEnable(IntPtr hObj, bool fEnable);

        /** <summary>
         * 组件是否可用
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjIsEnable")]
        public static extern bool Ex_ObjIsEnable(IntPtr hObj);

        /** <summary>
         * 判断组件是否可视.
         * </summary>
         * <param name="hObj">组件句柄</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjIsVisible")]
        public static extern bool Ex_ObjIsVisible(IntPtr hObj);

        /** <summary>
         * 设置组件可视状态
         * </summary>
         * <param name="hObj"></param>
         * <param name="fShow"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjShow")]
        public static extern bool Ex_ObjShow(IntPtr hObj, bool fShow);

        /** <summary>
         * 获取组件数值
         * </summary>
         * <param name="hObj"></param>
         * <param name="nIndex">相关常量 #EOL_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetLong")]
        public static extern int Ex_ObjGetLong(IntPtr hObj, int nIndex);

        /** <summary>
         * 获取父组件
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetParent")]
        public static extern int Ex_ObjGetParent(IntPtr hObj);

        /** <summary>
         * 设置组件数值
         * </summary>
         * <param name="hObj"></param>
         * <param name="nIndex">#EOL_</param>
         * <param name="dwNewLong"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetLong")]
        public static extern int Ex_ObjSetLong(IntPtr hObj, int nIndex, int dwNewLong);

        /** <summary>
         * 设置组件数值(子类化专用)
         * </summary>
         * <param name="hObj"></param>
         * <param name="nIndex">#EOL_</param>
         * <param name="dwNewLong"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetLong")]
        public static extern IntPtr Ex_ObjSetLong(IntPtr hObj, int nIndex, Delegate dwNewLong);

        /** <summary>
         * 设置组件位置
         * </summary>
         * <param name="hObj"></param>
         * <param name="hObjInsertAfter"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         * <param name="width"></param>
         * <param name="height"></param>
         * <param name="flags">相关常量 #SWP_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetPos")]
        public static extern bool Ex_ObjSetPos(IntPtr hObj, IntPtr hObjInsertAfter, int x, int y, int width, int height, int flags);

        /** <summary>
         * 是否有效的组件
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjIsValidate")]
        public static extern bool Ex_ObjIsValidate(IntPtr hObj);

        /** <summary>
         * 枚举子组件.
         * </summary>
         * <param name="hObjParent">父组件的句柄。从根部枚举则为引擎句柄。</param>
         * <param name="lpEnumFunc">callback(hObj</param>
         * <param name="lParam">附带参数</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjEnumChild")]
        public static extern bool Ex_ObjEnumChild(IntPtr hObjParent, ExObjEnumCallbackDelegate lpEnumFunc, int lParam);

        /** <summary>
         * 获取组件文本.返回值:已拷贝字符长度.
         * </summary>
         * <param name="hObj">组件句柄.</param>
         * <param name="lpString">缓冲区指针.</param>
         * <param name="nMaxCount">缓冲区长度.</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetText")]
        public static extern int Ex_ObjGetText(IntPtr hObj, StringBuilder lpString, int nMaxCount);

        /** <summary>
         * 获取组件文本长度
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetTextLength")]
        public static extern int Ex_ObjGetTextLength(IntPtr hObj);

        /** <summary>
         * 设置组件文本.
         * </summary>
         * <param name="hObj">组件句柄.</param>
         * <param name="lpString">指向一个空结束的字符串的指针.</param>
         * <param name="fRedraw">是否重画组件</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetText")]
        public static extern bool Ex_ObjSetText(IntPtr hObj, string lpString, bool fRedraw);

        /** <summary>
         * 弹出或关闭提示文本
         * </summary>
         * <param name="hObj">组件句柄.</param>
         * <param name="lpString">提示文本.该值为0则关闭提示文本</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjTooltipsPop")]
        public static extern bool Ex_ObjTooltipsPop(IntPtr hObj, string lpString);

        /** <summary>
         * 弹出或关闭提示文本Ex
         * </summary>
         * <param name="hObj">组件句柄.</param>
         * <param name="lpTitle">标题内容</param>
         * <param name="lpText">提示文本.</param>
         * <param name="x">屏幕坐标.(-1:默认)</param>
         * <param name="y">屏幕坐标.(-1:默认)</param>
         * <param name="dwTime">单位:毫秒.(-1:默认</param>
         * <param name="nIcon">#气泡图标_</param>
         * <param name="fShow">是否立即显示</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjTooltipsPopEx")]
        public static extern bool Ex_ObjTooltipsPopEx(IntPtr hObj, string lpTitle, string lpText, int x, int y, int dwTime, int nIcon, bool fShow);

        /** <summary>
         * 获取鼠标所在窗口组件句柄
         * </summary>
         * <param name="handle">0[坐标所在窗口]/窗口句柄/引擎句柄/组件句柄</param>
         * <param name="x">handle:0相对屏幕/其他相对窗口</param>
         * <param name="y"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUIGetObjFromPoint")]
        public static extern IntPtr Ex_DUIGetObjFromPoint(IntPtr handle, int x, int y);

        /** <summary>
         * 设置组件焦点
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetFocus")]
        public static extern bool Ex_ObjSetFocus(IntPtr hObj);

        /** <summary>
         * 销毁组件焦点
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjKillFocus")]
        public static extern bool Ex_ObjKillFocus(IntPtr hObj);

        /** <summary>
         * 获取属性
         * </summary>
         * <param name="hObj"></param>
         * <param name="dwKey"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetProp")]
        public static extern int Ex_ObjGetProp(IntPtr hObj, int dwKey);

        /** <summary>
         * 设置组件属性条目
         * </summary>
         * <param name="hObj"></param>
         * <param name="dwKey"></param>
         * <param name="dwValue"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetProp")]
        public static extern int Ex_ObjSetProp(IntPtr hObj, int dwKey, int dwValue);

        /** <summary>
         * 移动组件
         * </summary>
         * <param name="hObj"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         * <param name="width"></param>
         * <param name="height"></param>
         * <param name="bRepaint"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjMove")]
        public static extern bool Ex_ObjMove(IntPtr hObj, int x, int y, int width, int height, bool bRepaint);

        /** <summary>
         * 返回与指定组件有特定关系（如Z序或所有者）的组件句柄。
         * </summary>
         * <param name="hObj"></param>
         * <param name="nCmd">相关常量 #GW_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetObj")]
        public static extern IntPtr Ex_ObjGetObj(IntPtr hObj, int nCmd);

        /** <summary>
         * 查找组件.
         * </summary>
         * <param name="hObjParent">父组件句柄。从根部查找则为引擎句柄。</param>
         * <param name="hObjChildAfter">由此组件开始查找（不包含该组件）。如果为0，则从第一个组件开始查找。</param>
         * <param name="lpClassName">欲查找的组件类名指针/Ex_ATOM()</param>
         * <param name="lpTitle">欲查找的组件标题</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjFind")]
        public static extern IntPtr Ex_ObjFind(IntPtr hObjParent, IntPtr hObjChildAfter, string lpClassName, string lpTitle);

        /** <summary>
         * 设置组件是否可以重画.如果组件扩展风格存在EOS_EX_COMPOSITED
         * </summary>
         * <param name="hObj">组件句柄</param>
         * <param name="fCanbeRedraw">是否可重画</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetRedraw")]
        public static extern bool Ex_ObjSetRedraw(IntPtr hObj, bool fCanbeRedraw);

        /** <summary>
         * 加载主题包
         * </summary>
         * <param name="lptszFile"></param>
         * <param name="lpKey"></param>
         * <param name="dwKeyLen"></param>
         * <param name="bDefault"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ThemeLoadFromFile")]
        public static extern int Ex_ThemeLoadFromFile(string lptszFile, byte[] lpKey, int dwKeyLen, bool bDefault);

        /** <summary>
         * 加载主题包
         * </summary>
         * <param name="lpData"></param>
         * <param name="dwDataLen"></param>
         * <param name="lpKey"></param>
         * <param name="dwKeyLen"></param>
         * <param name="bDefault"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ThemeLoadFromMemory")]
        public static extern int Ex_ThemeLoadFromMemory(byte[] lpData, int dwDataLen, byte[] lpKey, int dwKeyLen, bool bDefault);

        /** <summary>
         * 释放主题
         * </summary>
         * <param name="hTheme"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ThemeFree")]
        public static extern bool Ex_ThemeFree(IntPtr hTheme);

        /** <summary>
         * 获取字符串唯一原子号
         * </summary>
         * <param name="lptstring"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_Atom")]
        public static extern int Ex_Atom(string lptstring);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="width"></param>
         * <param name="height"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_getsize")]
        public static extern bool _canvas_getsize(IntPtr hCanvas, out int width, out int height);

        /** <summary>
         * 获取组件属性值指针.
         * </summary>
         * <param name="hTheme">主题句柄</param>
         * <param name="atomClass"></param>
         * <param name="atomProp"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ThemeGetValuePtr")]
        public static extern int Ex_ThemeGetValuePtr(IntPtr hTheme, int atomClass, int atomProp);

        /** <summary>
         * 设置引擎数值
         * </summary>
         * <param name="hExDui"></param>
         * <param name="nIndex">#EWL_</param>
         * <param name="dwNewlong"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUISetLong")]
        public static extern int Ex_DUISetLong(IntPtr hExDui, int nIndex, int dwNewlong);

        /** <summary>
         * 获取引擎数值
         * </summary>
         * <param name="hExDui">引擎句柄</param>
         * <param name="nIndex">相关常量: EWL_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUIGetLong")]
        public static extern int Ex_DUIGetLong(IntPtr hExDui, int nIndex);

        /** <summary>
         * 创建默认字体
         * </summary>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_font_create")]
        public static extern int _font_create();

        /** <summary>
         * 
         * </summary>
         * <param name="lpwzFontFace"></param>
         * <param name="dwFontSize"></param>
         * <param name="dwFontStyle"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_font_createfromfamily")]
        public static extern int _font_createfromfamily(byte[] lpwzFontFace, int dwFontSize, int dwFontStyle);

        /** <summary>
         * 
         * </summary>
         * <param name="lpLogfont"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_font_createfromlogfont")]
        public static extern int _font_createfromlogfont(ref LogFont lpLogfont);

        /** <summary>
         * 获取逻辑字体
         * </summary>
         * <param name="hFont"></param>
         * <param name="lpLogFont"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_font_getlogfont")]
        public static extern bool _font_getlogfont(IntPtr hFont, ref LogFont lpLogFont);

        /** <summary>
         * 创建自布局
         * </summary>
         * <param name="hParent">父窗口句柄</param>
         * <param name="hTheme">主题句柄</param>
         * <param name="lpLayout">布局资源数据指针</param>
         * <param name="cbLayout">布局资源数据长度</param>
         * <param name="hWnd">(out)返回窗口句柄</param>
         * <param name="hExDui">(out)返回引擎句柄</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUICreateFromLayout")]
        public static extern bool Ex_DUICreateFromLayout(IntPtr hParent, IntPtr hTheme, byte[] lpLayout, int cbLayout, out IntPtr hWnd, out IntPtr hExDui);

        /** <summary>
         * 创建自资源包句柄
         * </summary>
         * <param name="hParent">父窗口句柄</param>
         * <param name="hTheme">主题句柄</param>
         * <param name="hRes">资源句柄</param>
         * <param name="atomLayout">布局文件名原子号</param>
         * <param name="hWnd">(out)返回窗口句柄</param>
         * <param name="hExDui">(out)返回引擎句柄</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUICreateFromHRes")]
        public static extern bool Ex_DUICreateFromHRes(IntPtr hParent, IntPtr hTheme, IntPtr hRes, int atomLayout, out IntPtr hWnd, out IntPtr hExDui);

        /** <summary>
         * 注册XML键值回调
         * </summary>
         * <param name="atomValue"></param>
         * <param name="pfnCallback"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_XmlRegisterCallback")]
        public static extern void Ex_XmlRegisterCallback(int atomValue, IntPtr pfnCallback);

        /** <summary>
         * 获取客户区矩形
         * </summary>
         * <param name="hExDui">引擎句柄</param>
         * <param name="lpClientRect">矩形指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUIGetClientRect")]
        public static extern bool Ex_DUIGetClientRect(IntPtr hExDui, out ExRect lpClientRect);

        /** <summary>
         * 投递消息
         * </summary>
         * <param name="hObj"></param>
         * <param name="uMsg"></param>
         * <param name="wParam"></param>
         * <param name="lParam"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjPostMessage")]
        public static extern bool Ex_ObjPostMessage(IntPtr hObj, int uMsg, int wParam, int lParam);

        /** <summary>
         * 设置组件背景信息
         * </summary>
         * <param name="handle">引擎句柄/组件句柄</param>
         * <param name="lpImage">图片指针</param>
         * <param name="dwImageLen">图片长度</param>
         * <param name="X">偏移X</param>
         * <param name="Y">偏移Y</param>
         * <param name="dwRepeat">相关常量 BIR_</param>
         * <param name="lpGird">九宫矩形指针 (值可为0)</param>
         * <param name="dwFlags">相关常量 BIF_</param>
         * <param name="dwAlpha">透明度(0-255)</param>
         * <param name="fUpdate">是否立即刷新</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetBackgroundImage")]
        public static extern bool Ex_ObjSetBackgroundImage(IntPtr handle, byte[] lpImage, int dwImageLen, int X, int Y, int dwRepeat, IntPtr pRcGrids, int dwFlags, int dwAlpha, bool fUpdate);

        /** <summary>
         * 获取组件背景信息
         * </summary>
         * <param name="handle"></param>
         * <param name="lpBackgroundImage">相关结构 EX_BACKGROUNDIMAGEINFO</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetBackgroundImage")]
        public static extern bool Ex_ObjGetBackgroundImage(IntPtr handle, out ExBackgroundImageInfo lpBackgroundImage);

        /** <summary>
         * 设置组件背景图片播放状态.
         * </summary>
         * <param name="handle">引擎句柄/组件句柄</param>
         * <param name="fPlayFrames">是否播放.</param>
         * <param name="fResetFrame">是否重置当前帧为首帧.</param>
         * <param name="fUpdate">是否更新背景.</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetBackgroundPlayState")]
        public static extern bool Ex_ObjSetBackgroundPlayState(IntPtr handle, bool fPlayFrames, bool fResetFrame, bool fUpdate);

        /** <summary>
         * 模糊
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="fDeviation"></param>
         * <param name="lprc"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_blur")]
        public static extern bool _canvas_blur(IntPtr hCanvas, float fDeviation, ref int lprc);

        /** <summary>
         * 旋转色相
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="fAngle">0-360</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_rotate_hue")]
        public static extern bool _canvas_rotate_hue(IntPtr hCanvas, float fAngle);

        /** <summary>
         * 设置组件时钟
         * </summary>
         * <param name="hObj"></param>
         * <param name="uElapse"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetTimer")]
        public static extern int Ex_ObjSetTimer(IntPtr hObj, int uElapse);

        /** <summary>
         * 销毁组件时钟
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjKillTimer")]
        public static extern bool Ex_ObjKillTimer(IntPtr hObj);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hFont">如果为0则使用默认字体句柄</param>
         * <param name="crText"></param>
         * <param name="lpwzText"></param>
         * <param name="dwLen">-1则自动计算尺寸(必须是指向空字符串的指针)</param>
         * <param name="dwDTFormat">#DT_</param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawtext")]
        public static extern bool _canvas_drawtext(IntPtr hCanvas, IntPtr hFont, int crText, string lpwzText, int dwLen, int dwDTFormat, float left, float top, float right, float bottom);

        /** <summary>
         * 
         * </summary>
         * <param name="hFont"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_font_destroy")]
        public static extern bool _font_destroy(IntPtr hFont);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hFont"></param>
         * <param name="lpwzText"></param>
         * <param name="dwLen"></param>
         * <param name="dwDTFormat"></param>
         * <param name="lParam"></param>
         * <param name="layoutWidth"></param>
         * <param name="layoutHeight"></param>
         * <param name="lpWidth"></param>
         * <param name="lpHeight"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_calctextsize")]
        public static extern bool _canvas_calctextsize(IntPtr hCanvas, IntPtr hFont, string lpwzText, int dwLen, int dwDTFormat, int lParam, float layoutWidth, float layoutHeight, out float lpWidth, out float lpHeight);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hFont"></param>
         * <param name="crText"></param>
         * <param name="lpwzText"></param>
         * <param name="dwLen">-1则自动计算尺寸(必须是指向空字符串的指针)</param>
         * <param name="dwDTFormat"></param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         * <param name="iGlowsize"></param>
         * <param name="crShadow"></param>
         * <param name="lParam"></param>
         * <param name="prclayout"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawtextex")]
        public static extern bool _canvas_drawtextex(IntPtr hCanvas, IntPtr hFont, int crText, ref int lpwzText, int dwLen, int dwDTFormat, float left, float top, float right, float bottom, int iGlowsize, int crShadow, int lParam, ref ExRect prclayout);

        /** <summary>
         * 分发消息
         * </summary>
         * <param name="hObj"></param>
         * <param name="uMsg"></param>
         * <param name="wParam"></param>
         * <param name="lParam"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjDispatchMessage")]
        public static extern int Ex_ObjDispatchMessage(IntPtr hObj, int uMsg, int wParam, int lParam);

        /** <summary>
         * ok
         * </summary>
         * <param name="hCanvas"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_begindraw")]
        public static extern bool _canvas_begindraw(IntPtr hCanvas);

        /** <summary>
         * 设置组件状态
         * </summary>
         * <param name="hObj"></param>
         * <param name="dwState"></param>
         * <param name="fRemove"></param>
         * <param name="lprcRedraw"></param>
         * <param name="fRedraw"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetUIState")]
        public static extern bool Ex_ObjSetUIState(IntPtr hObj, int dwState, bool fRemove, ref ExRect lprcRedraw, bool fRedraw);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_flush")]
        public static extern bool _canvas_flush(IntPtr hCanvas);

        /** <summary>
         * 设置滚动条信息
         * </summary>
         * <param name="hObj"></param>
         * <param name="fnBar">SB_</param>
         * <param name="fMask">SIF_</param>
         * <param name="nMin"></param>
         * <param name="nMax"></param>
         * <param name="nPage"></param>
         * <param name="nPos"></param>
         * <param name="fRedraw"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollSetInfo")]
        public static extern int Ex_ObjScrollSetInfo(IntPtr hObj, int fnBar, int fMask, int nMin, int nMax, int nPage, int nPos, bool fRedraw);

        /** <summary>
         * 设置滚动条范围
         * </summary>
         * <param name="hObj"></param>
         * <param name="nBar">SB_</param>
         * <param name="nMin"></param>
         * <param name="nMax"></param>
         * <param name="bRedraw"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollSetRange")]
        public static extern bool Ex_ObjScrollSetRange(IntPtr hObj, int nBar, int nMin, int nMax, bool bRedraw);

        /** <summary>
         * 设置滚动条位置
         * </summary>
         * <param name="hObj"></param>
         * <param name="nBar">SB_</param>
         * <param name="nPos"></param>
         * <param name="bRedraw"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollSetPos")]
        public static extern int Ex_ObjScrollSetPos(IntPtr hObj, int nBar, int nPos, bool bRedraw);

        /** <summary>
         * 获取滚动条句柄
         * </summary>
         * <param name="hObj"></param>
         * <param name="nBar">相关常量 #SB_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollGetControl")]
        public static extern int Ex_ObjScrollGetControl(IntPtr hObj, int nBar);

        /** <summary>
         * 调用过程
         * </summary>
         * <param name="lpPrevObjProc"></param>
         * <param name="hWnd"></param>
         * <param name="hObj"></param>
         * <param name="uMsg"></param>
         * <param name="wParam"></param>
         * <param name="lParam"></param>
         * <param name="pvData"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjCallProc")]
        public static extern int Ex_ObjCallProc(IntPtr lpPrevObjProc, IntPtr hWnd, IntPtr hObj, int uMsg, int wParam, int lParam, IntPtr pvData);

        /** <summary>
         * 创建画布自引擎句柄
         * </summary>
         * <param name="hExDui"></param>
         * <param name="width"></param>
         * <param name="height"></param>
         * <param name="dwFlags">CVF_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_createfromexdui")]
        public static extern int _canvas_createfromexdui(IntPtr hExDui, int width, int height, int dwFlags);

        /** <summary>
         * 获取滚动条位置
         * </summary>
         * <param name="hObj"></param>
         * <param name="nBar"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollGetPos")]
        public static extern int Ex_ObjScrollGetPos(IntPtr hObj, int nBar);

        /** <summary>
         * 弹出信息框
         * </summary>
         * <param name="handle">组件句柄/引擎句柄/窗口句柄.(如果该值为窗口句柄且窗口未使用引擎渲染</param>
         * <param name="lpText">消息框内容</param>
         * <param name="lpCaption">消息框标题</param>
         * <param name="uType">相关常量 #MB_</param>
         * <param name="dwFlags">相关常量 #EMBF_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_MessageBox")]
        public static extern int Ex_MessageBox(IntPtr handle, string lpText, string lpCaption, int uType, int dwFlags);

        /** <summary>
         * 弹出信息框
         * </summary>
         * <param name="handle">组件句柄/引擎句柄/窗口句柄.(如果该值为窗口句柄且窗口未使用引擎渲染</param>
         * <param name="lpText">消息框内容</param>
         * <param name="lpCaption">消息框标题</param>
         * <param name="uType">相关常量 #MB_</param>
         * <param name="lpCheckBox">检查框标题(消息框左下角显示一个检查框组件).(如果该窗口未使用引擎渲染</param>
         * <param name="lpCheckBoxChecked">返回检查框选中状态.(如果该窗口未使用引擎渲染</param>
         * <param name="dwMilliseconds">消息框延迟关闭时间，单位：毫秒。如果该值不为0</param>
         * <param name="dwFlags">相关常量 #EMBF_</param>
         * <param name="lpfnMsgProc">(BOOL)MsgProc(hWnd</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_MessageBoxEx")]
        public static extern int Ex_MessageBoxEx(IntPtr handle, string lpText, string lpCaption, int uType, string lpCheckBox, ref bool lpCheckBoxChecked, int dwMilliseconds, int dwFlags, ExWndProcDelegate lpfnMsgProc);

        /** <summary>
         * 绑定窗口
         * </summary>
         * <param name="hWnd">窗口句柄</param>
         * <param name="hTheme">主题句柄.(值可为0)</param>
         * <param name="dwStyle">相关常量:#EWS_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUIBindWindow")]
        public static extern IntPtr Ex_DUIBindWindow(IntPtr hWnd, IntPtr hTheme, int dwStyle);

        /** <summary>
         * 获取组件句柄自ID
         * </summary>
         * <param name="hExDuiOrhObj">如果指定引擎句柄</param>
         * <param name="nID"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetFromID")]
        public static extern IntPtr Ex_ObjGetFromID(IntPtr hExDuiOrhObj, int nID);

        /** <summary>
         * 获取组件句柄自NAME
         * </summary>
         * <param name="hExDuiOrhObj">如果指定引擎句柄</param>
         * <param name="lpwzName"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetFromName")]
        public static extern IntPtr Ex_ObjGetFromName(IntPtr hExDuiOrhObj, string lpwzName);

        /** <summary>
         * 挂接组件事件回调
         * </summary>
         * <param name="hObj"></param>
         * <param name="nEvent">#NM_</param>
         * <param name="pfnCallback">(Bool) Handler(hObj</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjHandleEvent")]
        public static extern bool Ex_ObjHandleEvent(IntPtr hObj, int nEvent, ExObjEventProcDelegate pfnCallback);

        /** <summary>
         * 获取主题相关颜色值
         * </summary>
         * <param name="hTheme">主题句柄</param>
         * <param name="nIndex">#COLOR_EX_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ThemeGetColor")]
        public static extern int Ex_ThemeGetColor(IntPtr hTheme, int nIndex);

        /** <summary>
         * 获取组件状态
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetUIState")]
        public static extern int Ex_ObjGetUIState(IntPtr hObj);

        /** <summary>
         * 设置组件相关颜色
         * </summary>
         * <param name="hObj"></param>
         * <param name="nIndex">相关常量 COLOR_EX_</param>
         * <param name="dwColor"></param>
         * <param name="fRedraw">是否重画</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetColor")]
        public static extern int Ex_ObjSetColor(IntPtr hObj, int nIndex, int dwColor, bool fRedraw);

        /** <summary>
         * 获取组件相关颜色
         * </summary>
         * <param name="hObj"></param>
         * <param name="nIndex">相关常量 COLOR_EX_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetColor")]
        public static extern int Ex_ObjGetColor(IntPtr hObj, int nIndex);

        /** <summary>
         * 从文件加载资源
         * </summary>
         * <param name="lpwzFile"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ResLoadFromFile")]
        public static extern int Ex_ResLoadFromFile(string lpwzFile);

        /** <summary>
         * 从内存加载资源
         * </summary>
         * <param name="lpData"></param>
         * <param name="dwDataLen"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ResLoadFromMemory")]
        public static extern int Ex_ResLoadFromMemory(byte[] lpData, int dwDataLen);

        /** <summary>
         * 语言包_获取文本
         * </summary>
         * <param name="lpwzID"></param>
         * <param name="lpString">[out]指向字符串指针.如果已被格式化</param>
         * <param name="bFormat">[in/out]是否需要格式化</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_I18NGetString")]
        public static extern bool Ex_I18NGetString(string lpwzID, out string lpString, ref bool bFormat);

        /** <summary>
         * 语言包_获取文本
         * </summary>
         * <param name="atomID"></param>
         * <param name="lpString">[out]指向字符串指针.如果已被格式化</param>
         * <param name="bFormat">[in/out]是否需要格式化</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_I18NGetStringFromAtom")]
        public static extern bool Ex_I18NGetStringFromAtom(int atomID, out string lpString, ref bool bFormat);

        /** <summary>
         * 获取资源文件
         * </summary>
         * <param name="hRes"></param>
         * <param name="lpwzPath"></param>
         * <param name="lpFile">[out]文件数据指针.用户不应该释放该内存.</param>
         * <param name="dwFileLen">[out]文件尺寸.</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ResGetFile")]
        public static extern bool Ex_ResGetFile(IntPtr hRes, string lpwzPath, out byte[] lpFile, out int dwFileLen);

        /** <summary>
         * 获取资源文件
         * </summary>
         * <param name="hRes"></param>
         * <param name="atomPath"></param>
         * <param name="lpFile">[out]文件数据指针.用户不应该释放该内存.</param>
         * <param name="dwFileLen">[out]文件尺寸.</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ResGetFileFromAtom")]
        public static extern bool Ex_ResGetFileFromAtom(IntPtr hRes, int atomPath, out byte[] lpFile, out int dwFileLen);

        /** <summary>
         * 释放资源
         * </summary>
         * <param name="hRes"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ResFree")]
        public static extern void Ex_ResFree(IntPtr hRes);

        /** <summary>
         * 分发事件
         * </summary>
         * <param name="hObj"></param>
         * <param name="nCode"></param>
         * <param name="wParam"></param>
         * <param name="lParam"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjDispatchNotify")]
        public static extern int Ex_ObjDispatchNotify(IntPtr hObj, int nCode, int wParam, int lParam);

        /** <summary>
         * 语言包_文本格式化
         * </summary>
         * <param name="lppStringSrc"></param>
         * <param name="lpStringFormated"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_I18NStringFormat")]
        public static extern void Ex_I18NStringFormat(string lppStringSrc, ref bool lpStringFormated);

        /** <summary>
         * 语言包_注册回调
         * </summary>
         * <param name="pfnStringFormatCallback">[bool]callback(atomID</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_I18NRegisterCallback")]
        public static extern void Ex_I18NRegisterCallback(IntPtr pfnStringFormatCallback);

        /** <summary>
         * 设置托盘图标
         * </summary>
         * <param name="hExdui">引擎句柄</param>
         * <param name="hIcon">图标句柄</param>
         * <param name="lpwzTips">提示文本指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUITrayIconSet")]
        public static extern bool Ex_DUITrayIconSet(IntPtr hExdui, IntPtr hIcon, string lpwzTips);

        /** <summary>
         * 弹出托盘图标
         * </summary>
         * <param name="hExDui">引擎句柄</param>
         * <param name="lpwzInfo">弹出文本内容</param>
         * <param name="lpwzInfoTitle">弹出标题文本</param>
         * <param name="dwInfoFlags">相关常量 #NIIF_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUITrayIconPopup")]
        public static extern bool Ex_DUITrayIconPopup(IntPtr hExDui, string lpwzInfo, string lpwzInfoTitle, int dwInfoFlags);

        /** <summary>
         * 释放内存
         * </summary>
         * <param name="lpBuffer"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_FreeBuffer")]
        public static extern void Ex_FreeBuffer(IntPtr lpBuffer);

        /** <summary>
         * 默认绘制背景过程
         * </summary>
         * <param name="hObj"></param>
         * <param name="hCanvas"></param>
         * <param name="lprcPaint"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjDrawBackgroundProc")]
        public static extern bool Ex_ObjDrawBackgroundProc(IntPtr hObj, IntPtr hCanvas, ref ExRect lprcPaint);

        /** <summary>
         * 获取焦点组件
         * </summary>
         * <param name="hExDuiOrhObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetFocus")]
        public static extern IntPtr Ex_ObjGetFocus(IntPtr hExDuiOrhObj);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="pMatrix">0.则重置</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_settransform")]
        public static extern bool _canvas_settransform(IntPtr hCanvas, IntPtr pMatrix);

        /** <summary>
         * 
         * </summary>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_matrix_create")]
        public static extern int _matrix_create();

        /** <summary>
         * 
         * </summary>
         * <param name="pMatrix"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_matrix_destroy")]
        public static extern bool _matrix_destroy(IntPtr pMatrix);

        /** <summary>
         * 
         * </summary>
         * <param name="pMatrix"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_matrix_reset")]
        public static extern bool _matrix_reset(IntPtr pMatrix);

        /** <summary>
         * 
         * </summary>
         * <param name="pMatrix"></param>
         * <param name="offsetX"></param>
         * <param name="offsetY"></param>
         * <param name="order"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_matrix_translate")]
        public static extern bool _matrix_translate(IntPtr pMatrix, float offsetX, float offsetY, int order);

        /** <summary>
         * 
         * </summary>
         * <param name="pMatrix"></param>
         * <param name="fAngle"></param>
         * <param name="order"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_matrix_rotate")]
        public static extern bool _matrix_rotate(IntPtr pMatrix, float fAngle, int order);

        /** <summary>
         * 
         * </summary>
         * <param name="pMatrix"></param>
         * <param name="scaleX"></param>
         * <param name="scaleY"></param>
         * <param name="order"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_matrix_scale")]
        public static extern bool _matrix_scale(IntPtr pMatrix, float scaleX, float scaleY, int order);

        /** <summary>
         * 创建图像自资源包。成功返回0。
         * </summary>
         * <param name="hRes"></param>
         * <param name="atomPath"></param>
         * <param name="hImg">返回图像指针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_createfromres")]
        public static extern int _img_createfromres(IntPtr hRes, int atomPath, out IntPtr hImg);

        /** <summary>
         * 
         * </summary>
         * <param name="hBrush"></param>
         * <param name="argb"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_brush_setcolor")]
        public static extern int _brush_setcolor(IntPtr hBrush, int argb);

        /** <summary>
         * 绘制主题数据
         * </summary>
         * <param name="hTheme">主题句柄</param>
         * <param name="hCanvas">画板句柄</param>
         * <param name="dstLeft">目标左边</param>
         * <param name="dstTop">目标顶边</param>
         * <param name="dstRight">目标右边</param>
         * <param name="dstBottom">目标底边</param>
         * <param name="atomClass"></param>
         * <param name="atomSrcRect"></param>
         * <param name="dwAlpha">透明度(0-255)</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ThemeDrawControl")]
        public static extern bool Ex_ThemeDrawControl(IntPtr hTheme, IntPtr hCanvas, float dstLeft, float dstTop, float dstRight, float dstBottom, int atomClass, int atomSrcRect, int dwAlpha);

        /** <summary>
         * 
         * </summary>
         * <param name="hImg"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_brush_createfromimg")]
        public static extern int _brush_createfromimg(IntPtr hImg);

        /** <summary>
         * 创建路径
         * </summary>
         * <param name="brushmode"></param>
         * <param name="dwFlags">EPF_</param>
         * <param name="hPath"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_create")]
        public static extern int _path_create(int brushmode, int dwFlags, out IntPtr hPath);

        /** <summary>
         * 销毁路径
         * </summary>
         * <param name="hPath"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_destroy")]
        public static extern int _path_destroy(IntPtr hPath);

        /** <summary>
         * 添加线
         * </summary>
         * <param name="hPath"></param>
         * <param name="x1"></param>
         * <param name="y1"></param>
         * <param name="x2"></param>
         * <param name="y2"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_addline")]
        public static extern int _path_addline(IntPtr hPath, float x1, float y1, float x2, float y2);

        /** <summary>
         * 开始新图形
         * </summary>
         * <param name="hPath"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_beginfigure")]
        public static extern int _path_beginfigure(IntPtr hPath);

        /** <summary>
       * 开始新图形
       * </summary>
       * <param name="hPath"></param>
       * <param name="x"></param>
       * <param name="y"></param>
       **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_beginfigure2")]
        public static extern int _path_beginfigure2(IntPtr hPath, float x, float y);

        /** <summary>
         * 结束当前图形
         * </summary>
         * <param name="hPath"></param>
         * <param name="fCloseFigure">是否需要闭合图形</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_endfigure")]
        public static extern int _path_endfigure(IntPtr hPath, bool fCloseFigure);

        /** <summary>
         * 申请内存
         * </summary>
         * <param name="dwLen"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_AllocBuffer")]
        public static extern IntPtr Ex_AllocBuffer(int dwLen);

        /** <summary>
         * 缩放图像.成功返回0
         * </summary>
         * <param name="hImage"></param>
         * <param name="dstWidth"></param>
         * <param name="dstHeight"></param>
         * <param name="dstImg">返回新图像</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_scale")]
        public static extern int _img_scale(IntPtr hImage, int dstWidth, int dstHeight, out IntPtr dstImg);

        /** <summary>
         * 格式化_文本到整数
         * </summary>
         * <param name="lpValue">字符串指针</param>
         * <param name="lpdwPercentFlags">(out)返回是否为百分比单位</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_fmt_int")]
        public static extern int _fmt_int(string lpValue, out int lpdwPercentFlags);

        /** <summary>
         * 格式化_文本到整数数组
         * </summary>
         * <param name="lpValue">字符串指针</param>
         * <param name="lpAry">数组指针</param>
         * <param name="nMaxCount">最大数量</param>
         * <param name="fZero">是否清空</param>
         * <param name="lpdwPercentFlags">(out)返回百分比标记位(0-31位)</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_fmt_intary")]
        public static extern int _fmt_intary(string lpValue, int[] lpAry, int nMaxCount, bool fZero, ref int lpdwPercentFlags);

        /** <summary>
         * 格式化_文本到矩形
         * </summary>
         * <param name="lpValue">字符串指针</param>
         * <param name="lpRect">矩形指针</param>
         * <param name="lpdwPercentFlags">(out)返回百分比标记位(0-31位)</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_fmt_rect")]
        public static extern bool _fmt_rect(string lpValue, ref ExRect lpRect, ref int lpdwPercentFlags);

        /** <summary>
         * 格式化_文本到文本_语言包
         * </summary>
         * <param name="hRes">资源句柄.(值可为0)</param>
         * <param name="lpValue">字符串指针</param>
         * <param name="lpString">(out)</param>
         * <param name="bDispatchI18NCallback">(in/out)</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_fmt_string")]
        public static extern bool _fmt_string(IntPtr hRes, IStream lpValue, out string lpString, ref bool bDispatchI18NCallback);

        /** <summary>
         * 格式化_文本到颜色
         * </summary>
         * <param name="lpValue">字符串指针</param>
         * <param name="lpColor">(out)返回颜色</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_fmt_color")]
        public static extern bool _fmt_color(string lpValue, out int lpColor);

        /** <summary>
         * 格式化_二进制数据
         * </summary>
         * <param name="hRes">资源句柄</param>
         * <param name="lpValue">数据指针</param>
         * <param name="lpBin">(out)返回二进制数据指针</param>
         * <param name="lpLen">(out)返回数据长度</param>
         * <param name="lpFreeBuffer">(out)返回是否需要释放数据</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_fmt_bin")]
        public static extern bool _fmt_bin(IntPtr hRes, string lpValue, out byte[] lpBin, out int lpLen, out bool lpFreeBuffer);

        /** <summary>
         * 格式化_获取数据偏移地址
         * </summary>
         * <param name="lpValue"></param>
         * <param name="atomDest"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_fmt_getvalue")]
        public static extern bool _fmt_getvalue(string lpValue, int atomDest);

        /** <summary>
         * 格式化_获取数据偏移地址
         * </summary>
         * <param name="lpValue"></param>
         * <param name="lpValueOffset"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_fmt_getatom")]
        public static extern int _fmt_getatom(string lpValue, out int lpValueOffset);

        /** <summary>
         * 
         * </summary>
         * <param name="nType">布局类型</param>
         * <param name="lpfnLayoutProc">布局管理器回调函数(lpLayout[有可能是NULL]</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_register")]
        public static extern bool _layout_register(int nType, ExLayoutProcDelegate lpfnLayoutProc);

        /** <summary>
         * 
         * </summary>
         * <param name="nType">布局类型</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_unregister")]
        public static extern bool _layout_unregister(int nType);

        /** <summary>
         * hLayout
         * </summary>
         * <param name="nType">#ELT_ 布局类型</param>
         * <param name="hObjBind">所绑定的HOBJ或HEXDUI</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_create")]
        public static extern int _layout_create(int nType, IntPtr hObjBind);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_destroy")]
        public static extern bool _layout_destroy(IntPtr hLayout);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_addchild")]
        public static extern bool _layout_addchild(IntPtr hLayout, IntPtr hObj);

        /** <summary>
         * 已被加入的不会重复添加(系统按钮不加入)
         * </summary>
         * <param name="hLayout"></param>
         * <param name="fDesc">是否倒序</param>
         * <param name="dwObjClassATOM">0或空为所有</param>
         * <param name="nCount">加入的个数</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_addchildren")]
        public static extern bool _layout_addchildren(IntPtr hLayout, bool fDesc, int dwObjClassATOM, out int nCount);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_deletechild")]
        public static extern bool _layout_deletechild(IntPtr hLayout, IntPtr hObj);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="dwObjClassATOM">0或空为所有</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_deletechildren")]
        public static extern bool _layout_deletechildren(IntPtr hLayout, int dwObjClassATOM);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="hObj"></param>
         * <param name="dwPropID"></param>
         * <param name="pvValue"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_setchildprop")]
        public static extern bool _layout_setchildprop(IntPtr hLayout, IntPtr hObj, int dwPropID, ref int pvValue);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="hObj"></param>
         * <param name="dwPropID"></param>
         * <param name="pvValue"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_getchildprop")]
        public static extern bool _layout_getchildprop(IntPtr hLayout, IntPtr hObj, int dwPropID, out int pvValue);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="hObj"></param>
         * <param name="lpProps">不释放</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_getchildproplist")]
        public static extern bool _layout_getchildproplist(IntPtr hLayout, IntPtr hObj, out int lpProps);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="dwPropID"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_getprop")]
        public static extern int _layout_getprop(IntPtr hLayout, int dwPropID);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="dwPropID"></param>
         * <param name="pvValue"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_setprop")]
        public static extern bool _layout_setprop(IntPtr hLayout, int dwPropID, ref int pvValue);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_getproplist")]
        public static extern int _layout_getproplist(IntPtr hLayout);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_update")]
        public static extern bool _layout_update(IntPtr hLayout);

        /** <summary>
         * 重新设置type应当重新创建LM
         * </summary>
         * <param name="hLayout"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_gettype")]
        public static extern int _layout_gettype(IntPtr hLayout);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="fUpdateable"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_enableupdate")]
        public static extern bool _layout_enableupdate(IntPtr hLayout, bool fUpdateable);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="nEvent"></param>
         * <param name="wParam"></param>
         * <param name="lParam"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_notify")]
        public static extern int _layout_notify(IntPtr hLayout, int nEvent, int wParam, int lParam);

        /** <summary>
         * 获取父组件和EXDUI句柄
         * </summary>
         * <param name="hObj"></param>
         * <param name="phExDUI"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetParentEx")]
        public static extern int Ex_ObjGetParentEx(IntPtr hObj, ref int phExDUI);

        /** <summary>
         * 获取组件文本矩形
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpRect"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetTextRect")]
        public static extern bool Ex_ObjGetTextRect(IntPtr hObj, ref int lpRect);

        /** <summary>
         * 绘制主题数据加强版
         * </summary>
         * <param name="hTheme">主题句柄</param>
         * <param name="hCanvas">画板句柄</param>
         * <param name="dstLeft">目标左边</param>
         * <param name="dstTop">目标顶边</param>
         * <param name="dstRight">目标右边</param>
         * <param name="dstBottom">目标底边</param>
         * <param name="atomClass"></param>
         * <param name="atomSrcRect"></param>
         * <param name="atomBackgroundRepeat"></param>
         * <param name="atomBackgroundPositon"></param>
         * <param name="atomBackgroundGrid"></param>
         * <param name="atomBackgroundFlags"></param>
         * <param name="dwAlpha">透明度(0-255)</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ThemeDrawControlEx")]
        public static extern bool Ex_ThemeDrawControlEx(IntPtr hTheme, IntPtr hCanvas, float dstLeft, float dstTop, float dstRight, float dstBottom, int atomClass, int atomSrcRect, int atomBackgroundRepeat, int atomBackgroundPositon, int atomBackgroundGrid, int atomBackgroundFlags, int dwAlpha);

        /** <summary>
         * 
         * </summary>
         * <param name="hFont"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_font_getcontext")]
        public static extern int _font_getcontext(IntPtr hFont);

        /** <summary>
         * 设置提示文本
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpString"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjTooltipsSetText")]
        public static extern bool Ex_ObjTooltipsSetText(IntPtr hObj, string lpString);

        /** <summary>
         * 弹出菜单
         * </summary>
         * <param name="hMenu">菜单句柄</param>
         * <param name="uFlags">相关常量 TPM_</param>
         * <param name="x">弹出坐标X(屏幕坐标)</param>
         * <param name="y">弹出坐标Y(屏幕坐标)</param>
         * <param name="nReserved">0.备用</param>
         * <param name="handle">组件句柄/引擎句柄/窗口句柄.(如果该值为窗口句柄且窗口未使用引擎渲染</param>
         * <param name="lpRc">0.忽略</param>
         * <param name="pfnCallback">(BOOL)MsgProc(hWnd</param>
         * <param name="dwFlags">相关常量 EMNF_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_TrackPopupMenu")]
        public static extern bool Ex_TrackPopupMenu(IntPtr hMenu, int uFlags, int x, int y, int nReserved, IntPtr handle, ref ExRect lpRc, ExWndProcDelegate pfnCallback, int dwFlags);

        /** <summary>
         * 从窗口句柄获取引擎句柄
         * </summary>
         * <param name="hWnd"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_DUIFromWindow")]
        public static extern int Ex_DUIFromWindow(IntPtr hWnd);

        /** <summary>
         * 获取滚动条范围
         * </summary>
         * <param name="hObj"></param>
         * <param name="nBar"></param>
         * <param name="lpnMinPos"></param>
         * <param name="lpnMaxPos"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollGetRange")]
        public static extern bool Ex_ObjScrollGetRange(IntPtr hObj, int nBar, out int lpnMinPos, out int lpnMaxPos);

        /** <summary>
         * 获取滚动条拖动位置
         * </summary>
         * <param name="hObj"></param>
         * <param name="nBar"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollGetTrackPos")]
        public static extern int Ex_ObjScrollGetTrackPos(IntPtr hObj, int nBar);

        /** <summary>
         * 获取滚动条信息
         * </summary>
         * <param name="hObj"></param>
         * <param name="fnBar"></param>
         * <param name="lpnMin"></param>
         * <param name="lpnMax"></param>
         * <param name="lpnPos"></param>
         * <param name="lpnTrackPos"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollGetInfo")]
        public static extern bool Ex_ObjScrollGetInfo(IntPtr hObj, int fnBar, out int lpnMin, out int lpnMax, out int lpnPos, out int lpnTrackPos);

        /** <summary>
         * 加载XML布局
         * </summary>
         * <param name="handle">窗口句柄/引擎句柄/组件句柄</param>
         * <param name="hRes">资源句柄.(值可为0)</param>
         * <param name="lpLayout">布局资源指针</param>
         * <param name="cbLayout">布局资源长度</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjLoadFromLayout")]
        public static extern bool Ex_ObjLoadFromLayout(IntPtr handle, IntPtr hRes, byte[] lpLayout, int cbLayout);

        /** <summary>
         * 
         * </summary>
         * <param name="hExDUIOrObj"></param>
         * <param name="nNodeID"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetFromNodeID")]
        public static extern IntPtr Ex_ObjGetFromNodeID(IntPtr hExDUIOrObj, int nNodeID);

        /** <summary>
         * 
         * </summary>
         * <param name="const">in/out</param>
         * <param name="consts">atom</param>
         * <param name="values">value</param>
         * <param name="nCount"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_fmt_const")]
        public static extern bool _fmt_const(IntPtr st, int[] consts, int[] values, int nCount);

        /** <summary>
         * 绑定自己的JS对象
         * </summary>
         * <param name="hExDUI_hObj">作用域为DUI</param>
         * <param name="szObjName"></param>
         * <param name="lpfnDispatch">HRESULT DispatchFunc (this</param>
         * <param name="pvParam"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSBindObject")]
        public static extern int Ex_JSBindObject(IntPtr hExDUI_hObj, string szObjName, IntPtr lpfnDispatch, int pvParam);

        /** <summary>
         * 
         * </summary>
         * <param name="hExDUI_hObj"></param>
         * <param name="szExpression"></param>
         * <param name="fUseThis">为真时表达式中this代表参数1对应的JS对象</param>
         * <param name="pVarResult">不为NULL时会将返回值写入</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSEval")]
        public static extern int Ex_JSEval(IntPtr hExDUI_hObj, string szExpression, bool fUseThis, IntPtr pVarResult);

        /** <summary>
         * 
         * </summary>
         * <param name="hExDUI_hObj"></param>
         * <param name="szCode"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSAddCode")]
        public static extern bool Ex_JSAddCode(IntPtr hExDUI_hObj, string szCode);

        /** <summary>
         * 
         * </summary>
         * <param name="hExDUI_hObj"></param>
         * <param name="nErrCode"></param>
         * <param name="nErrLine"></param>
         * <param name="szErrMsg">char[1024]</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetLastError")]
        public static extern bool Ex_JSGetLastError(IntPtr hExDUI_hObj, StringBuilder nErrCode, StringBuilder nErrLine, StringBuilder szErrMsg);

        /** <summary>
         * 
         * </summary>
         * <param name="hObj"></param>
         * <param name="notyfiCode"></param>
         * <param name="szFuncName"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSRegisterFunction")]
        public static extern bool Ex_JSRegisterFunction(IntPtr hObj, int notyfiCode, string szFuncName);

        /** <summary>
         * 
         * </summary>
         * <param name="pVariant"></param>
         * <param name="nType"></param>
         * <param name="dwValue"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSSetVariant")]
        public static extern void Ex_JSSetVariant(IntPtr pVariant, short nType, int dwValue);

        /** <summary>
         * 
         * </summary>
         * <param name="pVariant"></param>
         * <param name="nType"></param>
         * <param name="pValue"></param>
         * <param name="cbSize">1</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSSetVariantPtr")]
        public static extern void Ex_JSSetVariantPtr(IntPtr pVariant, short nType, ref int pValue, int cbSize);

        /** <summary>
         * 
         * </summary>
         * <param name="lpParams"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParamCount")]
        public static extern int Ex_JSGetParamCount(ref int lpParams);

        /** <summary>
         * 
         * </summary>
         * <param name="lpParams"></param>
         * <param name="nIndex"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParamType")]
        public static extern int Ex_JSGetParamType(ref int lpParams, int nIndex);

        /** <summary>
         * 返回pVar
         * </summary>
         * <param name="lpParams"></param>
         * <param name="nIndex"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParam")]
        public static extern int Ex_JSGetParam(ref int lpParams, int nIndex);

        /** <summary>
         * 
         * </summary>
         * <param name="lpParams"></param>
         * <param name="nIndex"></param>
         * <param name="nDefault"></param>
         * <param name="pType"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParamNumber")]
        public static extern double Ex_JSGetParamNumber(ref int lpParams, int nIndex, double nDefault, ref int pType);

        /** <summary>
         * 
         * </summary>
         * <param name="lpParams"></param>
         * <param name="nIndex"></param>
         * <param name="nDefault"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParamInt")]
        public static extern int Ex_JSGetParamInt(ref int lpParams, int nIndex, int nDefault);

        /** <summary>
         * 
         * </summary>
         * <param name="lpParams"></param>
         * <param name="nIndex"></param>
         * <param name="nDefault"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParamFloat")]
        public static extern float Ex_JSGetParamFloat(ref int lpParams, int nIndex, float nDefault);

        /** <summary>
         * 
         * </summary>
         * <param name="lpParams"></param>
         * <param name="nIndex"></param>
         * <param name="nDefault"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParamDouble")]
        public static extern double Ex_JSGetParamDouble(ref int lpParams, int nIndex, double nDefault);

        /** <summary>
         * wchar_t* 不要释放
         * </summary>
         * <param name="lpParams"></param>
         * <param name="nIndex"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParamString")]
        public static extern int Ex_JSGetParamString(ref int lpParams, int nIndex);

        /** <summary>
         * wchar_t* 需要自己释放
         * </summary>
         * <param name="lpParams"></param>
         * <param name="nIndex"></param>
         * <param name="wzDefault"></param>
         * <param name="pType"></param>
         * <param name="fFormat"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParamToString")]
        public static extern int Ex_JSGetParamToString(ref int lpParams, int nIndex, int wzDefault, ref int pType, bool fFormat);

        /** <summary>
         * wchar_t* 需要自己释放
         * </summary>
         * <param name="lpParams"></param>
         * <param name="nIndex"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSGetParamFormatString")]
        public static extern int Ex_JSGetParamFormatString(ref int lpParams, int nIndex);

        /** <summary>
         * 
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpRect"></param>
         * <param name="nType"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetRectEx")]
        public static extern bool Ex_ObjGetRectEx(IntPtr hObj, ref ExRect lpRect, int nType);

        /** <summary>
         * 获取布局对象句柄
         * </summary>
         * <param name="handle"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjLayoutGet")]
        public static extern int Ex_ObjLayoutGet(IntPtr handle);

        /** <summary>
         * 设置布局对象句柄
         * </summary>
         * <param name="handle"></param>
         * <param name="hLayout"></param>
         * <param name="fUpdate"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjLayoutSet")]
        public static extern bool Ex_ObjLayoutSet(IntPtr handle, IntPtr hLayout, bool fUpdate);

        /** <summary>
         * 更新对象布局
         * </summary>
         * <param name="handle"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjLayoutUpdate")]
        public static extern bool Ex_ObjLayoutUpdate(IntPtr handle);

        /** <summary>
         * 清空对象布局信息
         * </summary>
         * <param name="handle"></param>
         * <param name="bChildren">是否清空所有子组件</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjLayoutClear")]
        public static extern bool Ex_ObjLayoutClear(IntPtr handle, bool bChildren);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="aRowHeight"></param>
         * <param name="cRows"></param>
         * <param name="aCellWidth"></param>
         * <param name="cCells"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_table_setinfo")]
        public static extern bool _layout_table_setinfo(IntPtr hLayout, int aRowHeight, int cRows, int aCellWidth, int cCells);

        /** <summary>
         * 设置组件偏移矩形
         * </summary>
         * <param name="hObj"></param>
         * <param name="nPaddingType">EOPT_TEXT=0</param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         * <param name="fRedraw"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetPadding")]
        public static extern bool Ex_ObjSetPadding(IntPtr hObj, int nPaddingType, int left, int top, int right, int bottom, bool fRedraw);

        /** <summary>
         * 设置组件文本字体
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpszFontfamily">-1 为默认字体</param>
         * <param name="dwFontsize">-1 为默认尺寸</param>
         * <param name="dwFontstyle">-1 为默认风格</param>
         * <param name="fRedraw"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetFontFromFamily")]
        public static extern bool Ex_ObjSetFontFromFamily(IntPtr hObj, string lpszFontfamily, int dwFontsize, int dwFontstyle, bool fRedraw);

        /** <summary>
         * 获取字体。用户不应该销毁该字体对象
         * </summary>
         * <param name="hObj"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetFont")]
        public static extern int Ex_ObjGetFont(IntPtr hObj);

        /** <summary>
         * 
         * </summary>
         * <param name="hObjSrc"></param>
         * <param name="hObjDst">0为所属窗口</param>
         * <param name="ptX">in/out</param>
         * <param name="ptY">in/out</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjPointTransform")]
        public static extern void Ex_ObjPointTransform(IntPtr hObjSrc, IntPtr hObjDst, ref int ptX, ref int ptY);

        /** <summary>
         * 设置该控件是否启用事件冒泡
         * </summary>
         * <param name="hObj"></param>
         * <param name="fEnable"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjEnableEventBubble")]
        public static extern bool Ex_ObjEnableEventBubble(IntPtr hObj, bool fEnable);

        /** <summary>
         * 获取组件类信息
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpClassInfo">相关结构 EX_CLASSINFO</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetClassInfo")]
        public static extern bool Ex_ObjGetClassInfo(IntPtr hObj, ref ExClassInfo lpClassInfo);

        /** <summary>
         * 通过类名/类ATOM获取类信息
         * </summary>
         * <param name="wzClassName">wzClassName/AtomClassName</param>
         * <param name="lpClassInfo">相关结构 EX_CLASSINFO</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetClassInfoEx")]
        public static extern bool Ex_ObjGetClassInfoEx(string wzClassName, ref ExClassInfo lpClassInfo);

        /** <summary>
         * 
         * </summary>
         * <param name="lpCurveInfo"></param>
         * <param name="cbCurveInfo"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_easing_curve_load")]
        public static extern IntPtr _easing_curve_load(byte[] lpCurveInfo, int cbCurveInfo);

        /** <summary>
         * 
         * </summary>
         * <param name="pCurveInfo"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_easing_curve_free")]
        public static extern void _easing_curve_free(IntPtr pCurveInfo);

        /** <summary>
         * 
         * </summary>
         * <param name="dwType">#缓动类型_</param>
         * <param name="pEasingContext"></param>
         * <param name="dwMode">#缓动模式_ 的组合</param>
         * <param name="pContext"></param>
         * <param name="nTotalTime">ms</param>
         * <param name="nInterval">ms</param>
         * <param name="nState">#EES_</param>
         * <param name="nStart"></param>
         * <param name="nStop"></param>
         * <param name="param1"></param>
         * <param name="param2"></param>
         * <param name="param3"></param>
         * <param name="param4"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_easing_create")]
        public static extern IntPtr _easing_create(int dwType, IntPtr pEasingContext, int dwMode, ref int pContext, int nTotalTime, int nInterval, int nState, int nStart, int nStop, ref int param1, ref int param2, ref int param3, ref int param4);

        /** <summary>
         * 
         * </summary>
         * <param name="pEasing"></param>
         * <param name="nState">#EES_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_easing_setstate")]
        public static extern bool _easing_setstate(IntPtr pEasing, int nState);

        /** <summary>
         * 
         * </summary>
         * <param name="us"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_Sleep")]
        public static extern void Ex_Sleep(int us);

        /** <summary>
         * 
         * </summary>
         * <param name="pEasing"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_easing_getstate")]
        public static extern int _easing_getstate(IntPtr pEasing);

        /** <summary>
         * 
         * </summary>
         * <param name="hLayout"></param>
         * <param name="hObjChild"></param>
         * <param name="dwEdge">#ELCP_ABSOLUTE_XXX</param>
         * <param name="dwType"></param>
         * <param name="nValue"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_absolute_setedge")]
        public static extern bool _layout_absolute_setedge(IntPtr hLayout, IntPtr hObjChild, int dwEdge, int dwType, int nValue);

        /** <summary>
         * 按当前位置锁定
         * </summary>
         * <param name="hLayout"></param>
         * <param name="hObjChild"></param>
         * <param name="tLeft">#ELCP_ABSOLUTE_XXX_TYPE 下同</param>
         * <param name="tTop"></param>
         * <param name="tRight"></param>
         * <param name="tBottom"></param>
         * <param name="tWidth"></param>
         * <param name="tHeight"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_layout_absolute_lock")]
        public static extern bool _layout_absolute_lock(IntPtr hLayout, IntPtr hObjChild, int tLeft, int tTop, int tRight, int tBottom, int tWidth, int tHeight);

        /** <summary>
         * 要注意每次初始化都会清空之前存储的内容
         * </summary>
         * <param name="hObj"></param>
         * <param name="nPropCount">-1为哈希表模式</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjInitPropList")]
        public static extern bool Ex_ObjInitPropList(IntPtr hObj, int nPropCount);

        /** <summary>
         * 移除属性
         * </summary>
         * <param name="hObj"></param>
         * <param name="dwKey"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjRemoveProp")]
        public static extern int Ex_ObjRemoveProp(IntPtr hObj, int dwKey);

        /** <summary>
         * 返回个数.枚举属性表
         * </summary>
         * <param name="hObj"></param>
         * <param name="lpfnCbk">bool enum(hObj</param>
         * <param name="param"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjEnumProps")]
        public static extern int Ex_ObjEnumProps(IntPtr hObj, ExObjPropEnumCallbackDelegate lpfnCbk, int lParam);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_brush_createfromcanvas")]
        public static extern int _brush_createfromcanvas(IntPtr hCanvas);

        /** <summary>
       * 
       * </summary>
       * <param name="hCanvas"></param>
       * <param name="alpha"></param>
       **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_brush_createfromcanvas2")]
        public static extern int _brush_createfromcanvas2(IntPtr hCanvas, int alpha);

        /** <summary>
         * 设置组件圆角度
         * </summary>
         * <param name="hObj"></param>
         * <param name="topleft">左上角</param>
         * <param name="topright">右上角</param>
         * <param name="bottomright">右下角</param>
         * <param name="bottomleft">左下角</param>
         * <param name="fUpdate"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetRadius")]
        public static extern bool Ex_ObjSetRadius(IntPtr hObj, float topleft, float topright, float bottomright, float bottomleft, bool fUpdate);

        /** <summary>
         * 重置路径
         * </summary>
         * <param name="hPath"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_reset")]
        public static extern int _path_reset(IntPtr hPath);

        /** <summary>
         * 取路径边界矩形
         * </summary>
         * <param name="hPath"></param>
         * <param name="lpBounds">RECTF</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_getbounds")]
        public static extern int _path_getbounds(IntPtr hPath, ref ExRectF lpBounds);

        /** <summary>
         * 关闭路径
         * </summary>
         * <param name="hPath"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_close")]
        public static extern int _path_close(IntPtr hPath);

        /** <summary>
         * 打开路径
         * </summary>
         * <param name="hPath"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_open")]
        public static extern int _path_open(IntPtr hPath);

        /** <summary>
         * 添加弧
         * </summary>
         * <param name="hPath"></param>
         * <param name="x1">起始坐标X</param>
         * <param name="y1">起始坐标Y</param>
         * <param name="x2">终点坐标X</param>
         * <param name="y2">终点坐标Y</param>
         * <param name="radiusX">半径X</param>
         * <param name="radiusY">半径Y</param>
         * <param name="fClockwise">是否顺时针</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_addarc")]
        public static extern int _path_addarc(IntPtr hPath, float x1, float y1, float x2, float y2, float radiusX, float radiusY, bool fClockwise);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hPath"></param>
         * <param name="hBrush"></param>
         * <param name="strokeWidth"></param>
         * <param name="strokeStyle"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawpath")]
        public static extern int _canvas_drawpath(IntPtr hCanvas, IntPtr hPath, IntPtr hBrush, float strokeWidth, int strokeStyle);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="hPath"></param>
         * <param name="hBrush"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_fillpath")]
        public static extern int _canvas_fillpath(IntPtr hCanvas, IntPtr hPath, IntPtr hBrush);

        /** <summary>
         * 添加矩形
         * </summary>
         * <param name="hPath"></param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_addrect")]
        public static extern int _path_addrect(IntPtr hPath, float left, float top, float right, float bottom);

        /** <summary>
         * 添加圆角矩形
         * </summary>
         * <param name="hPath"></param>
         * <param name="left"></param>
         * <param name="top"></param>
         * <param name="right"></param>
         * <param name="bottom"></param>
         * <param name="radiusTopLeft"></param>
         * <param name="radiusTopRight"></param>
         * <param name="radiusBottomLeft"></param>
         * <param name="radiusBottomRight"></param>
         * <param name="unit"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_addroundedrect")]
        public static extern int _path_addroundedrect(IntPtr hPath, float left, float top, float right, float bottom, float radiusTopLeft, float radiusTopRight, float radiusBottomLeft, float radiusBottomRight, int unit);

        /** <summary>
         * 测试坐标是否在可见路径内
         * </summary>
         * <param name="hPath"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_hittest")]
        public static extern bool _path_hittest(IntPtr hPath, float x, float y);

        /** <summary>
         * 
         * </summary>
         * <param name="hBrush"></param>
         * <param name="matrix"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_brush_settransform")]
        public static extern int _brush_settransform(IntPtr hBrush, IntPtr matrix);

        /** <summary>
         * 显示/隐藏滚动条
         * </summary>
         * <param name="hObj"></param>
         * <param name="wBar">支持SB_BOTH</param>
         * <param name="fShow"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollShow")]
        public static extern bool Ex_ObjScrollShow(IntPtr hObj, int wBar, bool fShow);

        /** <summary>
         * 禁用/启用滚动条
         * </summary>
         * <param name="hObj"></param>
         * <param name="wSB">支持SB_BOTH</param>
         * <param name="wArrows">相关常量 ESB_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjScrollEnable")]
        public static extern bool Ex_ObjScrollEnable(IntPtr hObj, int wSB, int wArrows);

        /** <summary>
         * 
         * </summary>
         * <param name="hFont"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_font_copy")]
        public static extern int _font_copy(IntPtr hFont);

        /** <summary>
         * 加载JS常量
         * </summary>
         * <param name="szConst"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_JSLoadConst")]
        public static extern void Ex_JSLoadConst(string szConst);

        /** <summary>
         * 设置组件文本字体
         * </summary>
         * <param name="hObj"></param>
         * <param name="hFont">_font_createxxx</param>
         * <param name="fRedraw"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetFont")]
        public static extern bool Ex_ObjSetFont(IntPtr hObj, IntPtr hFont, bool fRedraw);

        /** <summary>
         * 创建图片组
         * </summary>
         * <param name="nWidth">宽度</param>
         * <param name="nHeight">高度</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_create")]
        public static extern IntPtr _imglist_create(int nWidth, int nHeight);

        /** <summary>
         * 销毁图片组
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_destroy")]
        public static extern void _imglist_destroy(IntPtr hImageList);

        /** <summary>
         * 添加图片
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         * <param name="lpImage">图像数据指针</param>
         * <param name="cbImage">图像数据长度</param>
         * <param name="nIndexInsert">插入位置(0为最后)</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_add")]
        public static extern int _imglist_add(IntPtr hImageList, byte[] lpImage, int cbImage, int nIndexInsert);

        /** <summary>
         * 添加图片
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         * <param name="hImage">图像对象句柄</param>
         * <param name="nIndexInsert">插入位置(0为最后)</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_addimage")]
        public static extern int _imglist_addimage(IntPtr hImageList, IntPtr hImage, int nIndexInsert);

        /** <summary>
         * 删除图片
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         * <param name="nIndex">图片索引</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_del")]
        public static extern int _imglist_del(IntPtr hImageList, int nIndex);

        /** <summary>
         * 获取图片句柄
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         * <param name="nIndex">图片索引</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_get")]
        public static extern IntPtr _imglist_get(IntPtr hImageList, int nIndex);

        /** <summary>
         * 设置图片
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         * <param name="nIndex">图片索引</param>
         * <param name="lpImage">图片数据指针</param>
         * <param name="cbImage">图片数据长度</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_set")]
        public static extern int _imglist_set(IntPtr hImageList, int nIndex, byte[] lpImage, int cbImage);

        /** <summary>
         * 设置图片
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         * <param name="nIndex">图片索引</param>
         * <param name="hImage">图像对象句柄</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_setimage")]
        public static extern int _imglist_setimage(IntPtr hImageList, int nIndex, IntPtr hImage);

        /** <summary>
         * 获取图片组图片数量
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_count")]
        public static extern int _imglist_count(IntPtr hImageList);

        /** <summary>
         * 获取图片组图片尺寸
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         * <param name="pWidth">图片宽度</param>
         * <param name="pHeight">图片高度</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_count")]
        public static extern void _imglist_size(IntPtr hImageList, ref int pWidth, ref int pHeight);

        /** <summary>
         * 绘制图片(图片将被居中绘制到提供的矩形中)
         * </summary>
         * <param name="hImageList">图片组句柄</param>
         * <param name="nIndex">图片索引</param>
         * <param name="hCanvas">画布句柄</param>
         * <param name="nLeft">左边</param>
         * <param name="nTop">顶边</param>
         * <param name="nRight">右边</param>
         * <param name="nBottom">底边</param>
         * <param name="nAlpha">透明度0-255</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_imglist_draw")]
        public static extern bool _imglist_draw(IntPtr hImageList, int nIndex, IntPtr hCanvas, int nLeft, int nTop, int nRight, int nBottom, int nAlpha);

        /** <summary>
         * 是否允许启用输入法
         * </summary>
         * <param name="hObj"></param>
         * <param name="fEnable"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjEnableIME")]
        public static extern bool Ex_ObjEnableIME(IntPtr hObj, bool fEnable);

        /** <summary>
         * 设置窗口的输入法状态
         * </summary>
         * <param name="hObjOrExDui"></param>
         * <param name="fOpen"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetIMEState")]
        public static extern bool Ex_ObjSetIMEState(IntPtr hObjOrExDui, bool fOpen);

        /** <summary>
         * 设置控件是否禁止转换空格和回车为单击事件
         * </summary>
         * <param name="hObj"></param>
         * <param name="fDisable"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjDisableTranslateSpaceAndEnterToClick")]
        public static extern bool Ex_ObjDisableTranslateSpaceAndEnterToClick(IntPtr hObj, bool fDisable);

        /** <summary>
         * 设置画布文本抗锯齿模式
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="textAntialiasMode">0.不抗锯齿 1.抗锯齿 2.ClearType</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_settextantialiasmode")]
        public static extern bool _canvas_settextantialiasmode(IntPtr hCanvas, int textAntialiasMode);

        /** <summary>
         * 设置画布图形抗锯齿
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="antialias">是否抗锯齿</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_setantialias")]
        public static extern bool _canvas_setantialias(IntPtr hCanvas, bool antialias);

        /** <summary>
         * 设置画布图像抗锯齿
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="antialias">是否抗锯齿</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_setimageantialias")]
        public static extern bool _canvas_setimageantialias(IntPtr hCanvas, bool antialias);

        /** <summary>
         * 置父
         * </summary>
         * <param name="hObj">被置父的子控件</param>
         * <param name="hParent">新的父控件/皮肤/窗口 句柄</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjSetParent")]
        public static extern int Ex_ObjSetParent(IntPtr hObj, IntPtr hParent);

        /**
         * <param name="hPath">hPath</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_rgn_createfrompath")]
        public static extern int _rgn_createfrompath(IntPtr hPath);

        /** <summary>
         * _res_pack
         * </summary>
         * <param name="root"></param>
         * <param name="file"></param>
         * <param name="fSubDir"></param>
         * <param name="byteHeader"></param>
         * <param name="bPntBits"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_res_pack")]
        public static extern void _res_pack(string root, string file, bool fSubDir, char byteHeader, bool bPntBits);

        /** <summary>
         * gdi
         * </summary>
         * <param name="lpData"></param>
         * <param name="dwLen"></param>
         * <param name="uType">IMAGE_</param>
         * <param name="nIndex"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_LoadImageFromMemory")]
        public static extern void Ex_LoadImageFromMemory(IntPtr lpData, int dwLen, int uType, int nIndex);

        /** <summary>
         * 
         * </summary>
         * <param name="hImg"></param>
         * <param name="lpwzFile"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_savetofile")]
        public static extern void _img_savetofile(IntPtr hImg, string lpwzFile);

        /** <summary>
         * 
         * </summary>
         * <param name="hImg"></param>
         * <param name="lpBuffer"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_img_savetomemory")]
        public static extern void _img_savetomemory(IntPtr hImg, out byte[] lpBuffer);

        /** <summary>
         * 
         * </summary>
         * <param name="hCanvas"></param>
         * <param name="sCanvas"></param>
         * <param name="dstLeft"></param>
         * <param name="dstTop"></param>
         * <param name="dstRight"></param>
         * <param name="dstBottom"></param>
         * <param name="srcLeft"></param>
         * <param name="srcTop"></param>
         * <param name="dwAlpha"></param>
         * <param name="dwCompositeMode">CV_COMPOSITE_MODE_</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_canvas_drawcanvas")]
        public static extern bool _canvas_drawcanvas(IntPtr hCanvas, IntPtr sCanvas, int dstLeft, int dstTop, int dstRight, int dstBottom, int srcLeft, int srcTop, int dwAlpha, int dwCompositeMode);

        /** <summary>
         * 添加弧 v2
         * </summary>
         * <param name="hPath"></param>
         * <param name="x"></param>
         * <param name="y"></param>
         * <param name="width">宽度</param>
         * <param name="height">高度</param>
         * <param name="startAngle">开始角度</param>
         * <param name="sweepAngle">扫描角度</param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "_path_addarc2")]
        public static extern int _path_addarc2(IntPtr hPath, float x, float y, float width, float height, float startAngle, float sweepAngle);

        /** <summary>
         * 返回是否适用
         * </summary>
         * <param name="hObj"></param>
         * <param name="pDataObject"></param>
         * <param name="dwFormat"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjCheckDropFormat")]
        public static extern bool Ex_ObjCheckDropFormat(IntPtr hObj, int pDataObject, int dwFormat);

        /** <summary>
         * 返回数据指针,注意自行释放,0表示失败
         * </summary>
         * <param name="hObj"></param>
         * <param name="pDataObject"></param>
         * <param name="dwFormat"></param>
         * <param name="pcbData"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetDropData")]
        public static extern IntPtr Ex_ObjGetDropData(IntPtr hObj, int pDataObject, int dwFormat, out int pcbData);


        /** <summary>
         * 返回字符数,0表示失败
         * </summary>
         * <param name="hObj"></param>
         * <param name="pDataObject"></param>
         * <param name="lpwzBuffer"></param>
         * <param name="cchMaxLength"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjGetDropString")]
        public static extern int Ex_ObjGetDropString(IntPtr hObj, int pDataObject, out string lpwzBuffer, int cchMaxLength);


        /** <summary>
         * 设置控件是否启用绘画中消息
         * </summary>
         * <param name="hObj"></param>
         * <param name="fEnable"></param>
         **/
        [DllImport("libexdui.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, EntryPoint = "Ex_ObjEnablePaintingMsg")]
        public static extern bool Ex_ObjEnablePaintingMsg(IntPtr hObj, bool fEnable);
    }
}
