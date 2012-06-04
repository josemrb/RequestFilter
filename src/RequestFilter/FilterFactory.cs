using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using RequestFilter.Configurations;
using RequestFilter.Extensions;

namespace RequestFilter
{
    public class FilterFactory
    {
        public IList<IFilter> BuildFiltersFromConfig()
        {
            List<IFilter> filters = new List<IFilter>();
            try
            {
                var configSection = RequestFilterSection.Instance;
                foreach (Filter filterConfig in configSection.Filters)
                {
                    IFilter filter = (IFilter)Activator.CreateInstance(filterConfig.Type, filterConfig.Params.ToObjectArray());
                    if (filterConfig.Index != 0)
                        filters.Insert(filterConfig.Index, filter);
                    else
                        filters.Add(filter);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return filters;
        }

        public IFilter BuildFilter(Type type, params object[] options)
        {
            Contract.Requires(type != null);
            Contract.Requires(options != null);
            IFilter filter;
            try
            {
                filter = (IFilter)Activator.CreateInstance(type, options);
            }
            catch (Exception)
            {
                throw;
            }
            return filter;
        }
    }
}
