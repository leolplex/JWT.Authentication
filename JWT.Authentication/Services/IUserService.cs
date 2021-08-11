using System.Threading.Tasks;
using JWTAuthentication.Models;

namespace JWTAuthentication
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
    }
}