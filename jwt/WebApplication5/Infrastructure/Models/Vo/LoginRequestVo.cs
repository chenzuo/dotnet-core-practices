using System;

namespace WebApplication5.Infrastructure.Models.Vo
{
    [Serializable]
    public class LoginRequestVo
    {
        public string IdentityId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
