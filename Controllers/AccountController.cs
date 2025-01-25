using AspNetCoreIdentityWebApi.Data;
using AspNetCoreIdentityWebApi.DTO;
using AspNetCoreIdentityWebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCoreIdentityWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Registro")]
        public async Task<ActionResult> Post(CreateUserRequestDTO createUserRequestDTO)
        {
            try
            {
                
                var mappModel = _mapper.Map<User>(createUserRequestDTO);
                var result = await _userManager.CreateAsync(mappModel, createUserRequestDTO.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(mappModel, "User");
                    return StatusCode(StatusCodes.Status201Created, new RegistrationResponseDTO() { Success = true, Message = "Usuário criado com sucesso!" });
                }
                else
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(errors);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Falha ao salvar o registro no servidor!");
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserLoginRequestDTO userLoginRequestDTO)
        {
            var user = await _userManager.FindByNameAsync(userLoginRequestDTO.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, userLoginRequestDTO.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = GenerateJwtToken(user, roles);
                return Ok(new { token });
            }
            else
                return Unauthorized("Usuário ou Senha incorrecta!");
        }
        private string GenerateJwtToken(User user, IList<string> Roles)
        {
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };
            foreach (var role in Roles) { 
            claims.Add(new Claim(ClaimTypes.Role, role));
            }
            //
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpireTime"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

