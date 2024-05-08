using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Fonts{
    public static class ConsoleUtils
{
    private const int STD_OUTPUT_HANDLE = -11;
    private const int TMPF_TRUETYPE = 4;

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetStdHandle(int handle);

    [DllImport("kernel32.dll")]
    private static extern bool GetCurrentConsoleFontEx(IntPtr consoleOutput, bool maximumWindow, ref CONSOLE_FONT_INFO_EX consoleFontInfo);

    [DllImport("kernel32.dll")]
    private static extern bool SetCurrentConsoleFontEx(IntPtr consoleOutput, bool maximumWindow, ref CONSOLE_FONT_INFO_EX consoleFontInfo);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct CONSOLE_FONT_INFO_EX
    {
        public int cbSize;
        public int nFont;
        public COORD dwFontSize;
        public int FontFamily;
        public int FontWeight;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FaceName;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct COORD
    {
        public short X;
        public short Y;
    }

    public static void MasFontSize()
    {
        IntPtr consoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);
        CONSOLE_FONT_INFO_EX consoleFontInfo = new CONSOLE_FONT_INFO_EX();
        consoleFontInfo.cbSize = Marshal.SizeOf(consoleFontInfo);

        if (GetCurrentConsoleFontEx(consoleOutput, false, ref consoleFontInfo))
        {
            consoleFontInfo.dwFontSize.Y += 20; // Increase the font size by 2
            SetCurrentConsoleFontEx(consoleOutput, false, ref consoleFontInfo);
        }
    }

    public static void ResetFontSize()
    {
        IntPtr consoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);
        CONSOLE_FONT_INFO_EX consoleFontInfo = new CONSOLE_FONT_INFO_EX();
        consoleFontInfo.cbSize = Marshal.SizeOf(consoleFontInfo);

        if (GetCurrentConsoleFontEx(consoleOutput, false, ref consoleFontInfo))
        {
            consoleFontInfo.dwFontSize.Y -= 2; // Decrease the font size by 2 to restore it to the original size
            SetCurrentConsoleFontEx(consoleOutput, false, ref consoleFontInfo);
        }
    }

    public static void Escribir(int vel,string texto)
    {
        for(int i = 0; i < texto.Length; i++)
        {
            Console.Write(texto[i]);
            Thread.Sleep(vel);
        }
    }
}

}
