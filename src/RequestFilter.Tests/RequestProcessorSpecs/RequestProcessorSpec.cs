using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using Moq;

namespace RequestFilter.Tests.RequestProcessorSpecs
{
    [Subject(typeof(RequestProcessor))]
    public class RequestProcessorSpec : BaseContext
    {
        protected static RequestProcessor _requestProcessor;
        protected static IList<IFilter> _filters;

        protected static HttpRequestBase _request;
        protected static HttpResponseBase _response;
        protected static HttpContextBase _contextBase;
        protected static Mock<HttpContextBase> _contextBaseMock;
        protected static Mock<IFilter> _filterMock;
    }
}
