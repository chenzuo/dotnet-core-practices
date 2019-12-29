using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication5.Infrastructure.Interfaces;
using WebApplication5.Infrastructure.Models.Vo;
using WebApplication5.Infrastructure.Shared;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        public DefaultController(ILogger<DefaultController> logger, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _logger = logger;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
        }
        
        [HttpPost("jwt")]
        public async Task<ActionResult> Jwt([FromBody] LoginRequestVo loginRequest)
        {
            // generate refresh token
            var refreshToken = _tokenFactory.GenerateToken();

            // generate access token
            var accessToken = await _jwtFactory.GenerateEncodedToken(loginRequest.IdentityId, loginRequest.UserName);

            return Ok(JsonSerializer.SerializeObject(new LoginResponseVo(accessToken, refreshToken)));
        }
    }
}