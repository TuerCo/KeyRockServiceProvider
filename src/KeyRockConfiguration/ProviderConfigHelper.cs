using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockConfiguration
{
    public static class ProviderConfigHelper
    {
        public static Configuration UseConfig(string sectionName = "keyRock")
        {
            if (string.IsNullOrEmpty(sectionName))
            {
                throw new ArgumentNullException(sectionName);
            }

            var configSection = ConfigurationManager.GetSection(sectionName) as KeyRockConfiguration;
            Configuration config = null;

            if (configSection.Credentials == null)
                throw new Exception("Section credentials under keyRock section are required");

            if (string.IsNullOrEmpty(configSection.Credentials.UserName) || string.IsNullOrEmpty(configSection.Credentials.Password))
            {
                if (string.IsNullOrEmpty(configSection.Credentials.File))
                    throw new Exception("Credentias must have user/password or file attribute");

                if (!File.Exists(configSection.Credentials.File))
                    throw new Exception("Credentials file does not exists");

                try
                {
                    var text = File.ReadAllText(configSection.Credentials.File);
                    config = JsonConvert.DeserializeObject<Configuration>(text);
                }
                catch (Exception)
                {
                    throw new Exception("Could not parse file");
                }
            }
            else
            {
                config = new Configuration { UserName = configSection.Credentials.UserName, Password = configSection.Credentials.Password };
            }

            config.BaseUrl = configSection.Urls.BaseUrl;
            config.AuthenticateRedirectionUrl = configSection.Urls.AuthenticationRedirectionUrl;
            config.AppSlug = configSection.Application.Slug;

            return config;
        }
    }
}
