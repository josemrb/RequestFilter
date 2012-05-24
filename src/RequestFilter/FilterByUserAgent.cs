using System.Diagnostics.Contracts;
using System.Web;

namespace RequestFilter
{
    public class FilterByUserAgent : IFilter
    {
        private readonly string _userAgent;

        public FilterByUserAgent(string userAgent)
        {
            Contract.Assert(!string.IsNullOrEmpty(userAgent));
            _userAgent = userAgent;
        }

        bool Contains(string value)
        {
            Contract.Assert(!string.IsNullOrEmpty(value));
            return value.ToLowerInvariant().Contains(_userAgent.ToLowerInvariant());
        }

        public bool CanProceed(HttpRequestBase request)
        {
            Contract.Assert(request!=null);
            return Contains(request.UserAgent);
        }
    }
}
