using System.Collections.Generic;
using System.Net;
using System.Web;
using Machine.Specifications;
using RequestFilter.Tests.Fakes;

namespace RequestFilter.Tests.RequestProcessorSpecs
{
    public class When_the_request_can_not_proceed : RequestProcessorSpec
    {
        Establish context = () =>
                                {
                                    _request = new FakeRequestBuilder(_moqer).Build();
                                    _response = new FakeResponseBuilder(_moqer).Build();
                                    _contextBaseMock = _moqer.GetMock<HttpContextBase>();
                                    _contextBaseMock.SetupGet(x => x.Request).Returns(_request);
                                    _contextBaseMock.SetupGet(x => x.Response).Returns(_response);
                                    _contextBase = _contextBaseMock.Object;

                                    _filterMock = _moqer.GetMock<IFilter>();
                                    _filterMock.Setup(x => x.CanProceed(Moq.It.IsAny<HttpRequestBase>())).Returns(false);
                                    _filters = new List<IFilter> { _filterMock.Object };
                                    _requestProcessor = new RequestProcessor(_filters);
                                };

        Because of = () => _requestProcessor.Process(_contextBase);

        It should_have_status_description_forbidden = () => _contextBase.Response.StatusDescription.ShouldBeEqualIgnoringCase("403 Forbidden");

        It should_have_status_code_forbidden =
            () => _contextBase.Response.StatusCode.ShouldEqual((int)HttpStatusCode.Forbidden);

        It should_verify_call_to_filter = () => _filterMock.VerifyAll();
    }
}