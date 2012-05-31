using System.Diagnostics.Contracts;
using System.Net;
using System.Web;
using RequestFilter.Extensions;

namespace RequestFilter.Filters
{
    public class FilterByIP : IFilter
    {
        private readonly IPAddress _top;
        private readonly IPAddress _bottom;

        public FilterByIP(IPAddress top, IPAddress bottom)
        {
            Contract.Requires(top != null);
            Contract.Requires(bottom != null);
            Contract.Requires(top.ToUInt() < bottom.ToUInt());
            _top = top;
            _bottom = bottom;
        }

        public bool CanProceed(HttpRequestBase request)
        {
            Contract.Requires(request != null);
            string userHost = request.UserHostAddress;
            IPAddress clientIP;
            if (userHost != null && IPAddress.TryParse(userHost, out clientIP))
            {
                if (clientIP.ToUInt() >= _top.ToUInt() && clientIP.ToUInt() <= _bottom.ToUInt())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
