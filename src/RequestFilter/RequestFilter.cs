using System.Collections.Generic;
using System.Net;
using System.Web;

namespace RequestFilter
{
    public class RequestFilter
    {
        private readonly IList<IFilter> _filters;

        public RequestFilter(IList<IFilter> filters)
        {
            _filters = filters;
        }

        public void Process(HttpContextWrapper context)
        {
            // iterate through the list of filters
            foreach (IFilter filter in _filters)
            {
                if (!filter.CanProceed(context.Request)) // find if the request can not proceed
                {
                    // deny request and return
                    Deny(context.Response);
                    return;
                }
            }
        }

        public void Deny(HttpResponseBase response)
        {
            response.StatusCode = (int)HttpStatusCode.Forbidden;
            response.StatusDescription = "403 Forbidden";
            response.Close();
        }
    }
}
