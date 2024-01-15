using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.AccountManager;
using Entities.DTOs;
using Services.AccountManager.AccountManagerContracts;

namespace Commerce_API.Controllers.AccountController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginManager _logger;
        private readonly ISigninManager _signinManager;
        private readonly IUpdateAccountManager _updateAccountManager;
        private readonly IDeleteAccountManager _deleteAccountManager;

        public AccountController(ILoginManager logger, ISigninManager signinManager,
            IUpdateAccountManager updateAccountManager, IDeleteAccountManager deleteAccountManager)
        {
            _logger = logger;
            _signinManager = signinManager;
            _updateAccountManager = updateAccountManager;
            _deleteAccountManager = deleteAccountManager;
        }


        [Route("login/{Email}/{Password}")]
        [HttpPost]
        public async Task<ActionResult<bool>> Login(LoginDTO loginDTO)
        {
            if (!(await _logger.Login(loginDTO.ToLoginEntity())))
            {
                return false;
            }
            
            return true;
        }


        [HttpPost("signin/{First_Name}/{Last_Name}/{Email}/{Password}/{PhoneNumber}/{Remain_SignedIn}")]
        public async Task<IActionResult> SignIn(SignInDTO signin)
        {
            if (signin == null)
            {
                return BadRequest("Empty Request");
            }
            signin.Id = new Guid();
            try
            {
                await _signinManager.SignIn(signin);
            }
            catch(Exception ex)
            {
                if (ex.Message == "Email already exists")
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok();

        }
    }
}
