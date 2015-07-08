using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockConfiguration
{
    public class KeyRockApp : ConfigurationElement
    {
        [ConfigurationProperty("slug", IsRequired=true)]
        public string Slug
        {
            get { return (string)this["slug"]; }
        }
    }
}
