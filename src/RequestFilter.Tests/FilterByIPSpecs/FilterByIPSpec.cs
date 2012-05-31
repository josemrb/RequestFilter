using System.Net;
using System.Web;
using Machine.Specifications;
using RequestFilter.Filters;

namespace RequestFilter.Tests.FilterByIPSpecs
{
    [Subject(typeof(FilterByIP))]
    public class FilterByIPSpec : BaseContext
    {
        protected static FilterByIP _filter;
        protected static IPAddress _ipBottomRange;
        protected static IPAddress _ipTopRange;
        protected static bool _result;
        protected static HttpRequestBase _request;
    }
}
