using CC.Passwordless.API.Services.Abstractions;
using CC.Passwordless.Utils.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CC.Passwordless.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService) {
        _authenticationService = authenticationService;
        }
        [HttpGet]
        public Task<bool> Get(string email) => _authenticationService.Login(email);
       
    }
}
