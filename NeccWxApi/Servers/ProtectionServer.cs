using System;
using System.Linq;
using System.Net;

namespace NeccWxApi
{
    public class ProtectionServer
    {
        public static string CheckIP()
        {

            return "";
        }

        public static string IPToStr(IPAddress ip)
        {
            if (ip == null) return "";
            var bs = ip.GetAddressBytes();
            return bs.Aggregate("", (current, c) => current + (char)c);
        }
    }
}