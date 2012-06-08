using System;
using System.Collections.Generic;
using System.Web;
using RequestFilter.Configurations;

namespace RequestFilter
{
    public class HttpModule : IHttpModule
    {
        private HttpApplication _app;
        private RequestProcessor _processor;
        private FilterFactory _filterFactory;
        private IList<IFilter> _filters;

        public void Init(HttpApplication application)
        {
            Init();
            _app = application;
            if (_filters.Count > 0)
                _app.BeginRequest += AppOnBeginRequest;
        }

        private void Init()
        {
            _filterFactory = new FilterFactory(RequestFilterSection.Instance);
            _filters = _filterFactory.BuildFiltersFromConfig();
            _processor = new RequestProcessor(_filters);
        }

        private void AppOnBeginRequest(object sender, EventArgs eventArgs)
        {
            _processor.Process(new HttpContextWrapper(_app.Context));
        }

        public void Dispose()
        {
            if (_filters.Count > 0)
                _app.BeginRequest -= AppOnBeginRequest;
        }
    }
}
