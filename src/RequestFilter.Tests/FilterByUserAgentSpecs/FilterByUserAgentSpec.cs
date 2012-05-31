using System.Web;
using Machine.Specifications;
using RequestFilter.Filters;

namespace RequestFilter.Tests.FilterByUserAgentSpecs
{
    [Subject(typeof(FilterByUserAgent))]
    public class FilterByUserAgentSpec : BaseContext
    {
        protected static FilterByUserAgent _filter;
        protected static bool _result;
        protected static HttpRequestBase _request;
        protected static string _userAgentFilter;
    }
}