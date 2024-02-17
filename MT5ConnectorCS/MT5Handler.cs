using System;
using System.Runtime.InteropServices;
using MTApiService;


public class MT5Handler : IMetaTraderHandler
{
    private const int WM_TIMER = 0x0113; // WM_TIMER message identifier

    private uint msgId;

    public MT5Handler()
    {
        msgId = WM_TIMER;
    }

    public void SendTickToMetaTrader(int handle)
    {
        PostMessage(new IntPtr(handle), msgId, IntPtr.Zero, IntPtr.Zero);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
}