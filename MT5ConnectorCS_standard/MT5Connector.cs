using System;
using System.Text;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;
using MTApiService;

namespace MT5ConnectorCS
{
    public class MT5Connector
    {
        //private const string LogProfileName = "MT5Connector";
        //private static readonly MtLog Log = LogConfigurator.GetLogger(typeof(MT5Connector));

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct CMqlRates
        {
            public long time;         // Period start time
            public double open;       // Open price
            public double high;       // The highest price of the period
            public double low;        // The lowest price of the period
            public double close;      // Close price
            public long tick_volume;  // Tick volume
            public int spread;        // Spread
            public long real_volume;  // Trade volume
        }

        private static string ConvertSystemString(string src)
        {
            if (src != null)
            {
                return src.Substring(0, Math.Min(1000, src.Length));
            }
            else
            {
                return string.Empty;
            }
        }

        //private static T Execute<T>(Func<T> func, StringBuilder err, T default_value)
        //{
        //    T result = default_value;
        //    try
        //    {
        //        result = func();
        //    }
        //    catch (Exception e)
        //    {
        //        err.Append(ConvertSystemString(e.Message));
        //        MtAdapter.GetInstance().LogError(e.Message);
        //    }
        //    return result;
        //}

        private static T Execute<T>(Func<T> func, out string err, T defaultValue)
        {
            T result = defaultValue;
            err = null;
            try
            {
                result = func();
            }
            catch (Exception e)
            {
                err = ConvertSystemString(e.Message);
                MtAdapter.GetInstance().LogError(e.Message);
            }
            return result;
        }
        
        [DllExport]
        public static bool initExpert(int expertHandle, int port, string symbol, double bid, double ask, int isTestMode, out string err)
        {
            MtAdapter.GetInstance().LogError("No error");

            bool result = false;
            err = "";

            try
            {
                result = Execute(() =>
                {

                    bool isTesting = (isTestMode != 0) ? true : false;
                    var expert = new Mt5Expert(expertHandle, symbol, bid, ask, new MT5Handler(), isTesting);
                    MtAdapter.GetInstance().AddExpert(port, expert);
                    return true;
                }, out err, false);
            }
            catch (Exception e)
            {
                err = ConvertSystemString(e.Message);
            }

            return result;
        }

        //[DllExport]
        //public static bool DeinitExpert(int expertHandle, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        MtAdapter.GetInstance().RemoveExpert(expertHandle);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool UpdateQuote(int expertHandle, string symbol, double bid, double ask, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        MtAdapter.GetInstance().SendQuote(expertHandle, symbol, bid, ask);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendEvent(int expertHandle, int eventType, string payload, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        MtAdapter.GetInstance().SendEvent(expertHandle, eventType, payload);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendIntResponse(int expertHandle, int response, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseInt(response));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendLongResponse(int expertHandle, long response, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseLong(response));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendULongResponse(int expertHandle, ulong response, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseULong(response));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendBooleanResponse(int expertHandle, int response, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        bool value = (response != 0) ? true : false;
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseBool(value));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendDoubleResponse(int expertHandle, double response, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseDouble(response));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendStringResponse(int expertHandle, string response, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseString(response));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendVoidResponse(int expertHandle, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseObject(null));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendDoubleArrayResponse(int expertHandle, double[] values, int size, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        var list = new double[size];
        //        Array.Copy(values, list, size);
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseDoubleArray(list));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendIntArrayResponse(int expertHandle, int[] values, int size, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        var list = new int[size];
        //        Array.Copy(values, list, size);
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseIntArray(list));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendLongArrayResponse(int expertHandle, long[] values, int size, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        var list = new long[size];
        //        Array.Copy(values, list, size);
        //        MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseLongArray(list));
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool SendErrorResponse(int expertHandle, int code, string message, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        var res = new MtResponseString(message) { ErrorCode = code };
        //        MtAdapter.GetInstance().SendResponse(expertHandle, res);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool GetCommandType(int expertHandle, out int res, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        res = MtAdapter.GetInstance().GetCommandType(expertHandle);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool GetIntValue(int expertHandle, int paramIndex, out int res, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        res = MtAdapter.GetInstance().GetCommandParameter<int>(expertHandle, paramIndex);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool GetDoubleValue(int expertHandle, int paramIndex, out double res, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        res = MtAdapter.GetInstance().GetCommandParameter<double>(expertHandle, paramIndex);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool GetStringValue(int expertHandle, int paramIndex, out string res, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        res = MtAdapter.GetInstance().GetCommandParameter<string>(expertHandle, paramIndex);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool GetULongValue(int expertHandle, int paramIndex, out ulong res, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        res = MtAdapter.GetInstance().GetCommandParameter<ulong>(expertHandle, paramIndex);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool GetLongValue(int expertHandle, int paramIndex, out long res, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        res = MtAdapter.GetInstance().GetCommandParameter<long>(expertHandle, paramIndex);
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool GetBooleanValue(int expertHandle, int paramIndex, out int res, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        bool val = MtAdapter.GetInstance().GetCommandParameter<bool>(expertHandle, paramIndex);
        //        res = val ? 1 : 0;
        //        return true;
        //    }, out err, false);
        //}

        //[DllExport]
        //public static bool GetUIntValue(int expertHandle, int paramIndex, out uint res, out string err)
        //{
        //    return Execute(() =>
        //    {
        //        res = MtAdapter.GetInstance().GetCommandParameter<uint>(expertHandle, paramIndex);
        //        return true;
        //    }, out err, false);
        //}

    }
}
