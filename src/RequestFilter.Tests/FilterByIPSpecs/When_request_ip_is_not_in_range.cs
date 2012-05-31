using System.Net;
using FluentAssertions;
using Machine.Specifications;
using RequestFilter.Filters;
using RequestFilter.Tests.Fakes;

namespace RequestFilter.Tests.FilterByIPSpecs
{
    public class When_request_ip_is_not_in_range : FilterByIPSpec
    {
        private Establish context = () =>
                                        {
                                            _ipTopRange = IPAddress.Parse("10.0.0.1");
                                            _ipBottomRange = IPAddress.Parse("10.10.0.255");
                                            _filter = new FilterByIP(_ipTopRange, _ipBottomRange);
                                            // default ip is 192.168.1.1
                                            _request = new FakeRequestBuilder(_moqer)
                                                .Build();
                                        };

        private Because of = () => _result = _filter.CanProceed(_request);

        private It should_be_false = () => _result.Should().BeFalse();
    }
}
