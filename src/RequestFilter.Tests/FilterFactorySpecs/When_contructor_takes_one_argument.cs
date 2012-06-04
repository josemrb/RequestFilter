using System;
using Machine.Specifications;
using RequestFilter.Filters;

namespace RequestFilter.Tests.FilterFactorySpecs
{
    public class When_contructor_takes_one_argument : FilterFactorySpec
    {
        Establish context = () =>
                                {
                                    _type = typeof(FilterByUserAgent);
                                    _arg1 = "Google";
                                };

        private Because of =
            () => _ex = Catch.Exception(() => _filter = _filterFactory.BuildFilter(_type, new object[] { _arg1 }));

        It should_return_an_instance = () => _filter.ShouldBeOfType<FilterByUserAgent>();

        It should_finalize_without_exception = () => _ex.ShouldBeNull();

        protected static Type _type;
        protected static string _arg1;
        private static IFilter _filter;
        private static Exception _ex;
    }
}