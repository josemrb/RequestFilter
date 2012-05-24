using System.Net;
using FluentAssertions;
using Machine.Specifications;
using RequestFilter.Tests.Fakes;

namespace RequestFilter.Tests.FilterByIPSpecs
{
    public class When_request_ip_is_in_range : FilterByIPSpec
    {
        Establish context = () =>
                                {
                                    _ipTopRange = IPAddress.Parse("10.0.0.1");
                                    _ipBottomRange = IPAddress.Parse("10.10.0.255");
                                    _filter = new FilterByIP(_ipTopRange, _ipBottomRange);
                                    _request = new FakeRequestBuilder(_moqer)
                                        .WithIP("10.0.0.10")
                                        .Build();
                                };

        private Because of = () => _result = _filter.CanProceed(_request);

        It should_be_true = () => _result.Should().BeTrue();
    }
}
