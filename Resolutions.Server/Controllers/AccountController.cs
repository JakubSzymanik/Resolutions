using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resolutions.Server.Model;
using Resolutions.Server.Model.DTOs;
using Resolutions.Server.Services;

namespace Resolutions.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        readonly IJWTService _jwtService;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public AccountController(IJWTService jwtService, 
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> Register(RegisterRequestDTO requestDTO)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState); 
            if(await UserExists(requestDTO.Email)) return BadRequest("User with this email already exists");


            var appUser = new AppUser() { Email = requestDTO.Email.ToLower(), UserName = requestDTO.Username };
            var result = await _userManager.CreateAsync(appUser, requestDTO.Password);
            if(result.Succeeded)
            {
                 var token = _jwtService.CreateToken(appUser);
                 return new LoginResponseDTO() { Email = requestDTO.Email, Token = token };
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO requestDTO)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var appUser = await _userManager.FindByEmailAsync(requestDTO.Email.ToLower());
            if (appUser == null) return BadRequest("User with this email doesn't exist");

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, requestDTO.Password, false);
            if (result.Succeeded)
            {
                var token = _jwtService.CreateToken(appUser);
                return new LoginResponseDTO { Username = appUser.UserName, Email = appUser.Email, Token = token };
            }
            else return BadRequest("Wrong password");
        }

        private async Task<bool> UserExists(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}
