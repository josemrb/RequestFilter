using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace RequestFilter.Extensions
{
    public static class CommaDelimitedStringCollectionExtensions
    {
        public static object[] ToObjectArray(this CommaDelimitedStringCollection collection)
        {
            Contract.Requires(collection!=null);
            List<object> objects = new List<object>();
            foreach (string val in collection)
            {
                objects.Add(val);
            }
            return objects.ToArray();
        }
    }
}
