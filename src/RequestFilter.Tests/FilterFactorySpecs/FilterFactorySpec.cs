using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Machine.Specifications;

namespace RequestFilter.Tests.FilterFactorySpecs
{
    [Subject(typeof(FilterFactory))]
    public class FilterFactorySpec : BaseContext
    {
        protected static FilterFactory _filterFactory;

        Establish context = () =>
                                {
                                    _filterFactory = new FilterFactory();
                                };
    }
}
