using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Web;

namespace RequestFilter
{
    public class RequestProcessor
    {
        private readonly IList<IFilter> _filters;

        public RequestProcessor(IList<IFilter> filters)
        {
            Contract.Requires(filters != null);
            _filters = filters;
        }

        public void Process(HttpContextBase context)
        {
            Contract.Requires(context != null);
            // iterate through the list of filters and apply OR to the result
            bool result = false;
            foreach (IFilter filter in _filters)
                result = result || filter.CanProceed(context.Request);
            if (!result)
                Deny(context.Response);
        }

        public void Deny(HttpResponseBase response)
        {
            Contract.Requires(response != null);
            response.StatusCode = (int)HttpStatusCode.Forbidden;
            response.StatusDescription = "403 Forbidden";
            response.End();
        }
    }
}
