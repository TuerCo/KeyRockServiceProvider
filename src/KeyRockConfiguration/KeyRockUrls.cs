using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockConfiguration
{
    public class KeyRockUrls : ConfigurationElement
    {
        [ConfigurationProperty("baseUrl", IsRequired=true)]
        public string BaseUrl
        {
            get { return (string)this["baseUrl"]; }
        }

        [ConfigurationProperty("authenticationRedirectionUrl", IsRequired = true)]
        public string AuthenticationRedirectionUrl
        {
            get { return (string)this["authenticationRedirectionUrl"]; }
        }
    }
}
