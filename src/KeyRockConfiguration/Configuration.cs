using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockConfiguration
{
    public class Configuration
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string BaseUrl { get; set; }
        public string AuthenticateRedirectionUrl { get; set; }
        public string AppSlug { get; set; }

        private static Lazy<Configuration> _config = new Lazy<Configuration>(() =>
        {
            return ProviderConfigHelper.UseConfig();
        });

        public static Configuration GetConfiguration()
        {
            return _config.Value;
        }
    }
}
