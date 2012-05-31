using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace RequestFilter
{
    public class RequestFilterSection : ConfigurationSection
    {
        private static RequestFilterSection _config =
            ConfigurationManager.GetSection("RequestFilter") as RequestFilterSection;


    }
}
