﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockServiceProvider.Models.Response
{
    public class GetApplicationResponse
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
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("actors")]
        public object[] Actors { get; set; }

        [JsonProperty("roles")]
        public Role[] Roles { get; set; }

        public class Role
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("actor_id")]
            public int? ActorId { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }
        }
    }
}
