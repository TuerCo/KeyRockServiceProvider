using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockServiceProvider.Models.Response
{
    public class GetUserResponse
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("actor_type")]
        public string ActorType { get; set; }

        [JsonProperty("actor_id")]
        public int ActorId { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("applications")]
        public Application[] Applications { get; set; }

        [JsonProperty("language")]
        public object Language { get; set; }

        [JsonProperty("organizations")]
        public Organization[] Organizations { get; set; }

        public class Organization
        {

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("actor_type")]
            public string ActorType { get; set; }

            [JsonProperty("actor_id")]
            public int ActorId { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }
        }

        public class Application
        {

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("actor_id")]
            public int ActorId { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public object Description { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("callback")]
            public string Callback { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }
        }
    }
}
