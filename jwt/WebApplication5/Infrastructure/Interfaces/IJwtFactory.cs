using System.Threading.Tasks;
using WebApplication5.Infrastructure.Models.Dto;

namespace WebApplication5.Infrastructure.Interfaces
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName);
    }
}
