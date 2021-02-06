
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OTOMOTO.CORE.Entities;
using OTOMOTO.CORE.Interfaces;
using OTOMOTO.WEB.Dtos;
using OTOMOTO.WEB.Dtos.Account;

namespace OTOMOTO.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signManager;
        private readonly IUserRepository _userRepo;
        private readonly ApplicationSettings _appSettings;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signManager, 
            IUserRepository userRepo, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signManager = signManager;
            _userRepo = userRepo;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userRepo.getAllUsers();
            return Ok(users);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<userManagerResponse>> Login(LoginDto LoginModel)
        {
            var user = await _userManager.FindByEmailAsync(LoginModel.email);
            if (user==null)
                return NotFound();
            var pass = await _userManager.CheckPasswordAsync(user,LoginModel.password);
            if (!pass)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)
                }),
                Expires = System.DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);
            return new userManagerResponse
            {
                jwtToken = encryptedToken
            };

           
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto RegisterModel)
        {
            var user = new AppUser {
             UserName=RegisterModel.username,
             Email=RegisterModel.email,
             Address=RegisterModel.Address,
             PhoneNumber=RegisterModel.mobile
            };

            var rez = await _userManager.CreateAsync(user,RegisterModel.password);
            if(rez.Succeeded)
            {
                await _signManager.PasswordSignInAsync(user,RegisterModel.password,false,false);
                return Ok();
            }

            return BadRequest(rez.Errors);
        }
    }
}
