using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RequestFilter
{
    public class HttpModule : IHttpModule
    {
        private HttpApplication _context;
        private RequestProcessor _processor;

        public void Init(HttpApplication context)
        {
            _context = context;
            _context.BeginRequest += ContextOnBeginRequest;
            InitProcessor();
        }

        private void InitProcessor()
        {

            _processor = new RequestProcessor(null);
        }

        private void ContextOnBeginRequest(object sender, EventArgs eventArgs)
        {
            
        }

        public void Dispose()
        {
            _context.BeginRequest -= ContextOnBeginRequest;
        }
    }
}
