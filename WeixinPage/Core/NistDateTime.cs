using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WeixinPage.Core
{
    class NistDateTime
    {
        private static char[] SeparatorArray = new char[] { ' ' };
        public static DateTime GetNistTime()
        {
            //string whost = "time.nist.gov";//这个地址响应不如下面IP  132.163.4.101
            //IPHostEntry iphostinfo = Dns.GetHostEntry(whost);
            var ipe = new IPEndPoint(IPAddress.Parse("132.163.4.101"), 13);
            var c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) { ReceiveTimeout = 10 * 1000 }; //创建Socket
            c.Connect(ipe);
            var recvBuffer = new byte[1024];
            int nBytes;
            var sb = new StringBuilder();
            while ((nBytes = c.Receive(recvBuffer, 0, 1024, SocketFlags.None)) > 0)
            {
                sb.Append(Encoding.UTF8.GetString(recvBuffer, 0, nBytes));
            }
            var dt = ParseDateTimeFromString(sb.ToString());
            c.Close();
            return dt;
        }
        private static DateTime ParseDateTimeFromString(string daytimeString)
        {
            daytimeString = daytimeString.Replace("\n", string.Empty)
                .Replace("\0", string.Empty);
            // 54708 08-08-30 18:53:02 50 0 0 770.8 UTC(NIST) *
            //   0       1        2     3 4 5   6      7      8
            // http://tf.nist.gov/service/its.htm
            // See "Daytime Protocol (RFC-867)"

            string[] resultTokens = daytimeString.Split(SeparatorArray, StringSplitOptions.RemoveEmptyEntries);
            if (resultTokens[7] != "UTC(NIST)" || resultTokens[8] != "*")
            {
                throw new Exception(string.Format("Invalid RFC-867 daytime protocol string: '{0}'", daytimeString));
            }

            var mjd = int.Parse(resultTokens[0]);  // "JJJJ is the Modified Julian Date (MJD). The MJD has a starting point of midnight on November 17, 1858."
            var now = new DateTime(1858, 11, 17);
            now = now.AddDays(mjd);

            var timeTokens = resultTokens[2].Split(':');
            var hours = int.Parse(timeTokens[0]);
            var minutes = int.Parse(timeTokens[1]);
            var seconds = int.Parse(timeTokens[2]);
            var millis = double.Parse(resultTokens[6], new System.Globalization.CultureInfo("en-US"));     // this is speculative: official documentation seems out of date!

            now = now.AddHours(hours);
            now = now.AddMinutes(minutes);
            now = now.AddSeconds(seconds);
            now = now.AddMilliseconds(-millis);

            return now;
        }
    }
}
