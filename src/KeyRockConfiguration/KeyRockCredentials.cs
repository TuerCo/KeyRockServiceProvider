using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockConfiguration
{
    public class KeyRockCredentials : ConfigurationElement
    {
        [ConfigurationProperty("username")]
        public string UserName
        {
            get { return (string)this["username"]; }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get { return (string)this["password"]; }
        }

        [ConfigurationProperty("file")]
        public string File
        {
            get { return (string)this["file"]; }
        }
    }
}
