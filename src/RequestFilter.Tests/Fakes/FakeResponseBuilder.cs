using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Web;
using AutoMoq;
using Moq;

namespace RequestFilter.Tests.Fakes
{
    public class FakeResponseBuilder
    {
        private readonly AutoMoqer _moqer;
        private readonly Mock<HttpResponseBase> _request;

        private NameValueCollection _headers;
        private int _statusCode;

        public FakeResponseBuilder(AutoMoqer moqer)
        {
            Contract.Assert(moqer != null);
            _moqer = moqer;
            _request = _moqer.GetMock<HttpResponseBase>();
            _headers = null;
            _request.SetupGet(x => x.Headers).Returns(() => _headers);
            _statusCode = 200;
            _request.SetupGet(x => x.StatusCode).Returns(() => _statusCode);
        }

        public HttpResponseBase Build()
        {
            return _request.Object;
        }

        public FakeResponseBuilder WithHeaders(NameValueCollection headers)
        {
            _headers = headers;
            return this;
        }

        public FakeResponseBuilder WithStatusCode(int statusCode)
        {
            _statusCode = statusCode;
            return this;
        }
    }
}
