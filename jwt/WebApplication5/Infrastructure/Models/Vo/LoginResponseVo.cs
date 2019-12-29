using System;
using WebApplication5.Infrastructure.Models.Dto;

namespace WebApplication5.Infrastructure.Models.Vo
{
    [Serializable]
    public class LoginResponseVo
    {
        private LoginResponseVo() { }
        public LoginResponseVo(AccessToken accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }
    }
}
