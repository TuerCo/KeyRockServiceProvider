using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockServiceProvider.Models.Response
{
    public class CreateUserResponse
    {
        [JsonProperty("schemas")]
        public string[] Schemas { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("name")]
        public NameClass Name { get; set; }

        [JsonProperty("displayedName")]
        public string DisplayedName { get; set; }

        [JsonProperty("meta")]
        public MetaClass Meta { get; set; }

        [JsonProperty("profileUrl")]
        public string ProfileUrl { get; set; }

        [JsonProperty("emails")]
        public Email[] Emails { get; set; }

        [JsonProperty("groups")]
        public object[] Groups { get; set; }

        public class Email
        {

            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("primary")]
            public string Primary { get; set; }
        }

        public class NameClass
        {

            [JsonProperty("formatted")]
            public string Formatted { get; set; }
        }

        public class MetaClass
        {

            [JsonProperty("resourceType")]
            public string ResourceType { get; set; }

            [JsonProperty("created")]
            public string Created { get; set; }

            [JsonProperty("lastModified")]
            public string LastModified { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }
        }
    }
}
