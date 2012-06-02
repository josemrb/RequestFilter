using System;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Web;
using AutoMoq;
using Moq;

namespace RequestFilter.Tests.Fakes
{
    public class FakeRequestBuilder
    {
        private readonly AutoMoqer _moqer;
        private readonly Mock<HttpRequestBase> _request;

        private string _applicationPath;
        private Uri _url;
        private NameValueCollection _serverVariables;
        private NameValueCollection _headers;
        private string _userAgent;
        private string _ipAddress;

        public FakeRequestBuilder(AutoMoqer moqer)
        {
            Contract.Requires(moqer!=null);
            _moqer = moqer;
            _request = _moqer.GetMock<HttpRequestBase>();
            _applicationPath = "/";
            // late binding is used to return the modified value
            _request.SetupGet(x => x.ApplicationPath).Returns(() => _applicationPath);
            _url = new Uri("http://localhost:8080");
            _request.SetupGet(x => x.Url).Returns(() => _url);
            _serverVariables = new NameValueCollection
                                   {
                                       {"SERVER_NAME", "localhost"},
                                       {"SCRIPT_NAME", "localhost"},
                                       {"SERVER_PORT", "8080"},
                                       {"REMOTE_ADDR", "127.0.0.1"},
                                       {"REMOTE_HOST", "127.0.0.1"}
                                   };
            _request.SetupGet(x => x.ServerVariables).Returns(() => _serverVariables);
            _headers = null;
            _request.SetupGet(x => x.Headers).Returns(() => _headers);
            _userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
            _request.SetupGet(x => x.UserAgent).Returns(() => _userAgent);
            _ipAddress = "192.168.1.1";
            _request.SetupGet(x => x.UserHostAddress).Returns(() => _ipAddress);
        }

        public HttpRequestBase Build()
        {
            return _request.Object;
        }

        public FakeRequestBuilder WithApplicationPath(string applicationPath)
        {
            _applicationPath = applicationPath;
            return this;
        }

        public FakeRequestBuilder WithURI(string uri)
        {
            _url = new Uri(uri);
            return this;
        }

        public FakeRequestBuilder WithURI(Uri uri)
        {
            _url = uri;
            return this;
        }

        public FakeRequestBuilder WithServerVariables(NameValueCollection serverVariables)
        {
            _serverVariables = serverVariables;
            return this;
        }

        public FakeRequestBuilder WithHeaders(NameValueCollection headers)
        {
            _headers = headers;
            return this;
        }

        public FakeRequestBuilder WithAjaxRequest()
        {
            if (_serverVariables["X-Requested-With"] != "XMLHttpRequest")
                _serverVariables.Set("X-Requested-With", "XMLHttpRequest");
            if (_headers != null)
            {
                if (_headers["X-Requested-With"] != "XMLHttpRequest")
                    _headers.Set("X-Requested-With", "XMLHttpRequest");
            }
            else
            {
                _headers = new NameValueCollection();
                _headers.Set("X-Requested-With", "XMLHttpRequest");
            }
            return this;
        }

        public FakeRequestBuilder WithAjaxGetRequest()
        {
            _serverVariables.Add("X-Requested-With", "XMLHttpRequest");
            return this;
        }

        public FakeRequestBuilder WithAjaxPostRequest()
        {
            _headers.Add("X-Requested-With", "XMLHttpRequest");
            return this;
        }       

        public FakeRequestBuilder WithUserAgent(string userAgent)
        {
            _userAgent = userAgent;
            return this;
        }

        public FakeRequestBuilder WithIP(string ipAddress)
        {
            _ipAddress = ipAddress;
            return this;
        }
    }
}
