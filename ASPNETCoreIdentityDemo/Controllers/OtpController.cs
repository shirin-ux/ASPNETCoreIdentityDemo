using ASPNETCoreIdentityDemo_Application.Dto;
using ASPNETCoreIdentityDemo_Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreIdentityDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly ILogger<OtpController> _logger;
        private readonly IUserService _identityService;

        public OtpController(IUserService identityService, ILogger<OtpController> logger)
        {
            _logger = logger;
            _identityService = identityService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterRequestDto request)
        {
            var result = await _identityService.CreateUserAsync(request);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(new { message = "User registered successfully. OTP has been sent to your phone.", Success = result.Success });
        }
    }
}

