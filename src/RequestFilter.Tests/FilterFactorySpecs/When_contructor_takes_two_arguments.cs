using System;
using System.Net;
using Machine.Specifications;
using RequestFilter.Filters;

namespace RequestFilter.Tests.FilterFactorySpecs
{
    public class When_contructor_takes_two_arguments : FilterFactorySpec
    {
        private Establish context = () =>
                                        {
                                            _type = typeof(FilterByIP);
                                            _arg1 = IPAddress.Parse( "192.168.10.1");
                                            _arg2 = IPAddress.Parse("192.168.10.255");
                                        };

        private Because of =
            () => _ex = Catch.Exception(() => _filter = _filterFactory.BuildFilter(_type, new object[] { _arg1, _arg2 }));

        It should_return_an_instance = () => _filter.ShouldBeOfType<FilterByIP>();

        It should_finalize_without_exception = () => _ex.ShouldBeNull();

        protected static Type _type;
        protected static IPAddress _arg1;
        private static IPAddress _arg2;
        private static IFilter _filter;
        private static Exception _ex;
    }
}