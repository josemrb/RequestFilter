using FluentAssertions;
using Machine.Specifications;
using RequestFilter.Filters;
using RequestFilter.Tests.Fakes;

namespace RequestFilter.Tests.FilterByUserAgentSpecs
{
    public class When_request_does_not_contains_user_agent : FilterByUserAgentSpec
    {
        private Establish context = () =>
                                        {
                                            // default user-agent is Firefox 12
                                            _request = new FakeRequestBuilder(_moqer)
                                                .Build();
                                            _userAgentFilter = "Googlebot";
                                            _filter = new FilterByUserAgent(_userAgentFilter);
                                        };

        private Because of = () => _result = _filter.CanProceed(_request);

        private It should_be_false = () => _result.Should().BeFalse();
    }
}
