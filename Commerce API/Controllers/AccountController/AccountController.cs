using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.AccountManager;
using Entities.DTOs;
using Services.AccountManager.AccountManagerContracts;
using Entities.ApplicationUser;
using Services.Peripherals.Services;
using Services.Peripherals.Contracts;
using Entities.Other;
using System.Linq;

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
        private readonly IPeripherals _getterService;

        public AccountController(ILoginManager logger, ISigninManager signinManager,
            IUpdateAccountManager updateAccountManager, IDeleteAccountManager deleteAccountManager,
            IPeripherals getterService)
        {
            _logger = logger;
            _signinManager = signinManager;
            _updateAccountManager = updateAccountManager;
            _deleteAccountManager = deleteAccountManager;
            _getterService = getterService;
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


        [HttpPost("signIn")]
        public async Task<ActionResult<PrimaryUser>> SignIn(SignInDTO signin)
        {
            if (signin == null)
            {
                return BadRequest("Empty Request");
            }
            signin.ModelId = new Guid();
            try
            {
                await _signinManager.SignIn(signin);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Email already exists")
                {
                    return BadRequest(ex.Message);
                }
            }
            return signin.ToPrimaryUser();

        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<List<UserToString>?>> GetPrimaryUsers()
        {
            return await _getterService.GetUsers();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<string>> AccountUpdate(string id, SignInDTO user)
        {
            if (user == null)
            {
                return BadRequest("User is null");
            }
            await _updateAccountManager.UpdateUser(Guid.Parse(id), user);
            return id;

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> DeleteAccount(Guid Id)
        {
            if (Id == null)
            {
                return BadRequest("Id cant be null...");
            }
            await _deleteAccountManager.DeleteAccount(Id);
            return true;
        }
        
    }
}
