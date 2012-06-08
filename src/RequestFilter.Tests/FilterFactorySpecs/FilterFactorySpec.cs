using Machine.Specifications;

namespace RequestFilter.Tests.FilterFactorySpecs
{
    [Subject(typeof(FilterFactory))]
    public class FilterFactorySpec : BaseContext
    {
        protected static FilterFactory _filterFactory;

        Establish context = () =>
                                {
                                    _filterFactory = new FilterFactory(null);
                                };
    }
}
