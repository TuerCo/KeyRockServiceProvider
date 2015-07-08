using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockConfiguration
{
    public class KeyRockConfiguration : ConfigurationSection
    {
        /// <summary>
        /// Collection of providers to be offered.
        /// </summary>
        [ConfigurationProperty("credentials", IsRequired=true)]
        public KeyRockCredentials Credentials
        {
            get { return (KeyRockCredentials)this["credentials"]; }
        }

        [ConfigurationProperty("urls", IsRequired=true)]
        public KeyRockUrls Urls
        {
            get { return (KeyRockUrls)this["urls"]; }
        }

        [ConfigurationProperty("application", IsRequired = true)]
        public KeyRockApp Application
        {
            get { return (KeyRockApp)this["application"]; }
        }
    }
}
