using KeyRockConfiguration;
using KeyRockServiceProvider;
using KeyRockServiceProvider.Models;
using KeyRockServiceProvider.Models.Request;
using KeyRockServiceProvider.Models.Response;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRockServiceProvider
{
    public class KeyRockService : IKeyRockService
    {
        KeyRockAuthToken _keyRockAuthToken;
        private string _baseUrl;
        private string _appSlug;

        public KeyRockService()
        {
            var configuration = Configuration.GetConfiguration();

            var username = configuration.UserName;
            var password = configuration.Password;
            _baseUrl = configuration.BaseUrl;
            _appSlug = configuration.AppSlug;


            var client = new RestClient(_baseUrl);

            //get token to create user
            var requestToken = new RestRequest("/api/v1/tokens.json", Method.POST);
            requestToken.AddParameter("email", username);
            requestToken.AddParameter("password", password);

            var responseToken = client.Execute<KeyRockAuthToken>(requestToken);
            _keyRockAuthToken = responseToken.Data;
        }

        public Models.Response.CreateUserResponse CreateUser(UserCreateRequest user)
        {
            var client = new RestClient(_baseUrl);

            var requestCreateUser = new RestRequest("/v2/users?auth_token=" + _keyRockAuthToken.Token, Method.POST);
            requestCreateUser.Method = Method.POST;
            requestCreateUser.AddHeader("Accept", "application/json");
            requestCreateUser.Parameters.Clear();
            requestCreateUser.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);

            var responseCreateUser = client.Execute(requestCreateUser);
            var usercreated = JsonConvert.DeserializeObject<Models.Response.CreateUserResponse>(responseCreateUser.Content);

            //CreatePublicRole(usercreated.Name.Formatted);

            return usercreated;
        }

        public GetUserResponse GetUser(string username)
        {
            var client = new RestClient(_baseUrl);

            var requestToken = new RestRequest("users/{userSlug}", Method.GET);
            requestToken.AddQueryParameter("auth_token", _keyRockAuthToken.Token);
            requestToken.AddUrlSegment("userSlug", username + ".json");

            var responseToken = client.Execute(requestToken);
            var user = JsonConvert.DeserializeObject<GetUserResponse>(responseToken.Content);

            return user;
        }

        public List<GetUserRolesResponse.Role> GetUserRoles(string username)
        {
            var client = new RestClient(_baseUrl);

            var requestToken = new RestRequest("applications/{appSlug}/actors/{userSlug}", Method.GET);
            requestToken.AddUrlSegment("appSlug", _appSlug);
            requestToken.AddQueryParameter("auth_token", _keyRockAuthToken.Token);
            requestToken.AddUrlSegment("userSlug", username + ".json");

            var responseToken = client.Execute(requestToken);
            var userRole = JsonConvert.DeserializeObject<GetUserRolesResponse>(responseToken.Content);

            return userRole.Roles.ToList();
        }

        public async Task<Models.Response.CreateUserResponse> CreateUserAsync(UserCreateRequest user)
        {
            var client = new RestClient(_baseUrl);

            var requestCreateUser = new RestRequest("/v2/users?auth_token=" + _keyRockAuthToken.Token, Method.POST);
            requestCreateUser.Method = Method.POST;
            requestCreateUser.AddHeader("Accept", "application/json");
            requestCreateUser.Parameters.Clear();
            requestCreateUser.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);

            var responseCreateUser = await client.ExecuteTaskAsync(requestCreateUser).ConfigureAwait(false);
            var usercreated = JsonConvert.DeserializeObject<Models.Response.CreateUserResponse>(responseCreateUser.Content);

            return usercreated;
        }

        public async Task CreatePublicRoleAsync(string userSlug, string role)
        {
            var client = new RestClient(_baseUrl);

            var requestApplication = new RestRequest("/applications/{appSlug}.json", Method.GET);
            requestApplication.AddUrlSegment("appSlug", _appSlug);
            requestApplication.AddQueryParameter("auth_token", _keyRockAuthToken.Token);

            var responseApplication = await client.ExecuteTaskAsync(requestApplication);
            var response = JsonConvert.DeserializeObject<GetApplicationResponse>(responseApplication.Content);

            var roleResponse = response.Roles.FirstOrDefault(x => x.Name == role);

            var requestAddToTanTan = new RestRequest("applications/{appSlug}/actors.json?auth_token=" + _keyRockAuthToken.Token, Method.POST);
            requestAddToTanTan.AddUrlSegment("appSlug", _appSlug);
            requestAddToTanTan.AddParameter("actor_slug", userSlug);
            requestAddToTanTan.AddParameter("role_ids", roleResponse.Id.ToString());

            await client.ExecuteTaskAsync(requestAddToTanTan);
        }
    }
}
