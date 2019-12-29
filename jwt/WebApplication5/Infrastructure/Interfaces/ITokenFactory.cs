
namespace WebApplication5.Infrastructure.Interfaces
{
    public interface ITokenFactory
    {
        string GenerateToken(int size= 32);
    }
}
