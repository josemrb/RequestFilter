using System.Collections.Generic;
using System.Web;
using FluentAssertions;
using Machine.Specifications;
using RequestFilter.Tests.Fakes;

namespace RequestFilter.Tests.RequestProcessorSpecs
{
    public class When_the_filter_list_is_empty : RequestProcessorSpec
    {
        Establish context = () =>
                                {
                                    _request = new FakeRequestBuilder(_moqer).Build();
                                    _response = new FakeResponseBuilder(_moqer).Build();
                                    _contextBaseMock = _moqer.GetMock<HttpContextBase>();
                                    _contextBaseMock.Setup(x => x.Request).Returns(_request);
                                    _contextBaseMock.Setup(x => x.Response).Returns(_response);
                                    _contextBase = _contextBaseMock.Object;

                                    _filters = new List<IFilter>();
                                    _requestProcessor = new RequestProcessor(_filters);
                                };

        Because of = () => _requestProcessor.Process(_contextBase);

        It should_not_modify_the_response = () => _response.Should().BeSameAs(_contextBase.Response);
    }
}