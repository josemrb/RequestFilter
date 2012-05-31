using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Net;

namespace RequestFilter.Extensions
{
    public static class IPAddressExtensions
    {
        public static uint ToUInt(this IPAddress ipAddress)
        {
            Contract.Requires(ipAddress != null);

            ByteConverter bConvert = new ByteConverter();
            uint ipUint = 0;
            int shift = 24;
            byte[] ipBytes = ipAddress.GetAddressBytes();
            foreach (byte b in ipBytes)
            {
                object convertTo;
                if (ipUint == 0)
                {
                    convertTo = bConvert.ConvertTo(b, typeof (uint));
                    if (convertTo != null)
                        ipUint = (uint)convertTo << shift;
                    shift -= 8;
                    continue;
                }
                
                if (shift >= 8)
                {
                    convertTo = bConvert.ConvertTo(b, typeof(uint));
                    if (convertTo != null)
                        ipUint += (uint)convertTo << shift;
                }
                else
                {
                    convertTo = bConvert.ConvertTo(b, typeof(uint));
                    if (convertTo != null)
                        ipUint += (uint)convertTo;
                }
                shift -= 8;
            }
            return ipUint;
        }
    }
}
