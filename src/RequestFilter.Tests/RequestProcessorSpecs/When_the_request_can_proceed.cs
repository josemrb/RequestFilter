using System.Collections.Generic;
using System.Net;
using System.Web;
using Machine.Specifications;
using RequestFilter.Tests.Fakes;

namespace RequestFilter.Tests.RequestProcessorSpecs
{
    public class When_the_request_can_proceed : RequestProcessorSpec
    {
        Establish context = () =>
                                {
                                    _request = new FakeRequestBuilder(_moqer).Build();
                                    _response = new FakeResponseBuilder(_moqer).Build();
                                    _contextBaseMock = _moqer.GetMock<HttpContextBase>();
                                    _contextBaseMock.Setup(x => x.Request).Returns(_request);
                                    _contextBaseMock.Setup(x => x.Response).Returns(_response);
                                    _contextBase = _contextBaseMock.Object;

                                    _filterMock = _moqer.GetMock<IFilter>();
                                    _filterMock.Setup(x => x.CanProceed(Moq.It.IsAny<HttpRequestBase>())).Returns(true);
                                    _filters = new List<IFilter> { _filterMock.Object };
                                    _requestProcessor = new RequestProcessor(_filters);
                                };

        Because of = () => _requestProcessor.Process(_contextBase);

        It should_have_status_code_ok =
            () => _contextBase.Response.StatusCode.ShouldEqual((int)HttpStatusCode.OK);

        It should_verify_call_to_filter = () => _filterMock.VerifyAll();
    }
}