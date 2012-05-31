using FluentAssertions;
using Machine.Specifications;
using RequestFilter.Filters;
using RequestFilter.Tests.Fakes;

namespace RequestFilter.Tests.FilterByUserAgentSpecs
{
    public class When_request_contains_user_agent : FilterByUserAgentSpec
    {
        Establish context = () =>
                                {
                                    _request = new FakeRequestBuilder(_moqer)
                                        .WithUserAgent("Googlebot/2.1 (+http://www.google.com/bot.html)")
                                        .Build();
                                    _userAgentFilter = "Googlebot";
                                    _filter = new FilterByUserAgent(_userAgentFilter);
                                };

        private Because of = () => _result = _filter.CanProceed(_request);

        private It should_be_true = () => _result.Should().BeTrue();
    }
}
