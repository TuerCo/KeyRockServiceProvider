using KeyRockServiceProvider.Models.Request;
using KeyRockServiceProvider.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeyRockServiceProvider
{
    public interface IKeyRockService
    {
        Models.Response.CreateUserResponse CreateUser(UserCreateRequest user);

        List<GetUserRolesResponse.Role> GetUserRoles(string username);

        Models.Response.GetUserResponse GetUser(string username);

        Task<Models.Response.CreateUserResponse> CreateUserAsync(UserCreateRequest user);

        Task CreatePublicRoleAsync(string userSlug, string role);
    }
}