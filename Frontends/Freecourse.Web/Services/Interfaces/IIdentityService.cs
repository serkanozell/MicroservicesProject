using Freecourse.Web.Models;
using FreeCourse.Shared.Dtos;
using IdentityModel.Client;

namespace Freecourse.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signInInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
