using System;
using System.Text;
using System.Runtime.InteropServices;
using MTApiService;
using RGiesecke.DllExport;
using log4net;

namespace MT5ConnectorCS
{
    public class MT5Connector
    {
        //private static readonly ILog Log = LogManager.GetLogger(typeof(MT5Connector));

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

        //private static string ConvertSystemString(string src)
        //{
        //    if (src != null)
        //    {
        //        return src.Substring(0, Math.Min(1000, src.Length));
        //    }
        //    else
        //    {
        //        return string.Empty;
        //    }
        //}

        private static bool Execute(Action func, StringBuilder err)
        {
            try
            {                
                func();
                return true;
            }
            catch (Exception e)
            {
                string message = $"\nInner:\n{e.InnerException}\nStackTrace:\n{e.StackTrace}\nToString:\n{e}";
                err.Append(message);
                MtAdapter.GetInstance().LogError(message);
                return false;
            }
        }

        private static bool Execute<T>(Func<T> func, StringBuilder err, T defaultValue, out T result)
        {
            result = defaultValue;

            try
            {
                result = func();
                return true;
            }
            catch (Exception e)
            {
                string message = $"\nInner:\n{e.InnerException}\nStackTrace:\n{e.StackTrace}\nToString:\n{e}";
                err.Append(message);
                MtAdapter.GetInstance().LogError(message);
                return false;
            }
        }

        [DllExport]
        public static bool initExpert(int expertHandle, int port, string symbol, double bid, double ask, int isTestMode, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            //Log.Info("initExpert: begin");

            return Execute(() =>
            {
                MtAdapter.GetInstance().LogError("NOERROR: initExpert()");
                bool isTesting = (isTestMode != 0) ? true : false;
                var expert = new Mt5Expert(expertHandle, symbol, bid, ask, new MT5Handler(), isTesting);
                MtAdapter.GetInstance().AddExpert(port, expert);
            }, err);
        }

        [DllExport]
        public static bool deinitExpert(int expertHandle, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                MtAdapter.GetInstance().RemoveExpert(expertHandle);
            }, err);
        }

        [DllExport]
        public static bool updateQuote(int expertHandle, string symbol, double bid, double ask, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                MtAdapter.GetInstance().SendQuote(expertHandle, symbol, bid, ask);
            }, err);
        }

        [DllExport]
        public static bool sendEvent(int expertHandle, int eventType, string payload, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                MtAdapter.GetInstance().SendEvent(expertHandle, eventType, payload);
            }, err);
        }

        [DllExport]
        public static bool sendIntResponse(int expertHandle, int response, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseInt(response));
            }, err);
        }

        [DllExport]
        public static bool sendLongResponse(int expertHandle, long response, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseLong(response));
            }, err);
        }

        [DllExport]
        public static bool sendULongResponse(int expertHandle, ulong response, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseULong(response));
            }, err);
        }

        [DllExport]
        public static bool sendBooleanResponse(int expertHandle, int response, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                bool value = (response != 0) ? true : false;
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseBool(value));
            }, err);
        }

        [DllExport]
        public static bool sendDoubleResponse(int expertHandle, double response, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseDouble(response));
            }, err);
        }

        [DllExport]
        public static bool sendStringResponse(int expertHandle, string response, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseString(response));
            }, err);
        }

        [DllExport]
        public static bool sendVoidResponse(int expertHandle, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseObject(null));
            }, err);
        }

        [DllExport]
        public static bool sendDoubleArrayResponse(int expertHandle, double[] values, int size, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                var list = new double[size];
                Array.Copy(values, list, size);
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseDoubleArray(list));
            }, err);
        }

        [DllExport]
        public static bool sendIntArrayResponse(int expertHandle, int[] values, int size, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                var list = new int[size];
                Array.Copy(values, list, size);
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseIntArray(list));
            }, err);
        }

        [DllExport]
        public static bool sendLongArrayResponse(int expertHandle, long[] values, int size, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                var list = new long[size];
                Array.Copy(values, list, size);
                MtAdapter.GetInstance().SendResponse(expertHandle, new MtResponseLongArray(list));
            }, err);
        }

        [DllExport]
        public static bool sendErrorResponse(int expertHandle, int code, string message, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                var res = new MtResponseString(message) { ErrorCode = code };
                MtAdapter.GetInstance().SendResponse(expertHandle, res);
            }, err);
        }

        [DllExport]
        public static bool getCommandType(int expertHandle, out int res, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                return MtAdapter.GetInstance().GetCommandType(expertHandle);
            }, err, 0, out res);
        }

        [DllExport]
        public static bool getIntValue(int expertHandle, int paramIndex, out int res, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                return MtAdapter.GetInstance().GetCommandParameter<int>(expertHandle, paramIndex);
            }, err, 0, out res);
        }

        [DllExport]
        public static bool getDoubleValue(int expertHandle, int paramIndex, out double res, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                return MtAdapter.GetInstance().GetCommandParameter<double>(expertHandle, paramIndex);
            }, err, 0, out res);
        }

        [DllExport]
        public static bool getStringValue(int expertHandle, int paramIndex, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder res, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            string result;

            var retval = Execute(() =>
            {
                return MtAdapter.GetInstance().GetCommandParameter<string>(expertHandle, paramIndex);
            }, err, "", out result);

            if (retval)
                res.Append(result);
            
            return retval;
        }

        [DllExport]
        public static bool getULongValue(int expertHandle, int paramIndex, out ulong res, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                return MtAdapter.GetInstance().GetCommandParameter<ulong>(expertHandle, paramIndex);
            }, err, (ulong)0, out res);
        }

        [DllExport]
        public static bool getLongValue(int expertHandle, int paramIndex, out long res, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                return MtAdapter.GetInstance().GetCommandParameter<long>(expertHandle, paramIndex);
            }, err, 0, out res);
        }

        [DllExport]
        public static bool getBooleanValue(int expertHandle, int paramIndex, out int res, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                return MtAdapter.GetInstance().GetCommandParameter<bool>(expertHandle, paramIndex)? 1 : 0;
            }, err, 0, out res);
        }

        [DllExport]
        public static bool getUIntValue(int expertHandle, int paramIndex, out uint res, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder err)
        {
            return Execute(() =>
            {
                return MtAdapter.GetInstance().GetCommandParameter<uint>(expertHandle, paramIndex);
            }, err, (uint)0, out res);
        }

    }
}
