using System.Diagnostics.Contracts;
using System.Web;

namespace RequestFilter.Filters
{
    public class FilterByUserAgent : IFilter
    {
        private readonly string _userAgent;

        public FilterByUserAgent(string userAgent)
        {
            Contract.Requires(!string.IsNullOrEmpty(userAgent));
            _userAgent = userAgent;
        }

        bool Contains(string value)
        {
            Contract.Requires(!string.IsNullOrEmpty(value));
            return value.ToLowerInvariant().Contains(_userAgent.ToLowerInvariant());
        }

        public bool CanProceed(HttpRequestBase request)
        {
            Contract.Requires(request!=null);
            return Contains(request.UserAgent);
        }
    }
}
