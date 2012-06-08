using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using RequestFilter.Configurations;
using RequestFilter.Extensions;

namespace RequestFilter
{
    public class FilterFactory
    {
        private readonly RequestFilterSection _configurationSection;

        public FilterFactory(RequestFilterSection requestFilterSection)
        {
            _configurationSection = requestFilterSection;
        }

        public IList<IFilter> BuildFiltersFromConfig()
        {
            List<IFilter> filters = new List<IFilter>();
            foreach (Filter filterConfig in _configurationSection.Filters)
            {
                IFilter filter = BuildFilter(filterConfig.Type, filterConfig.Params.ToObjectArray());
                if (filterConfig.Index != 0)
                    filters.Insert(filterConfig.Index, filter);
                else
                    filters.Add(filter);
            }
            return filters;
        }

        public IFilter BuildFilter(Type type, params object[] options)
        {
            Contract.Requires(type != null);
            Contract.Requires(options != null);
            return (IFilter)Activator.CreateInstance(type, options);
        }
    }
}
