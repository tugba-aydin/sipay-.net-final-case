using AutoMapper;
using BLL.Models;
using BLL.Models.Requests.Auth;
using BLL.Models.Requests.User;
using BLL.Services.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IMailService mailService;
        private readonly IMapper mapper;
        public AuthService(UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager, IConfiguration _configuration, IMailService _mailService,IMapper _mapper)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            configuration = _configuration;
            mailService = _mailService;
            mapper = _mapper;
        }
        public async Task<(int, string)> Register(CreateUserRequest model)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(model.Email);
                Random rnd = new Random();
                var number = rnd.Next(100000, 999999);
                var password = "A" + number + ".a";
                if (userExists != null)
                    return (0, "User already exists");

                User user = mapper.Map<User>(model);
                
                user.Id = Guid.NewGuid().ToString(); 
                var createUserResult = await userManager.CreateAsync(user, password);
                if (!createUserResult.Succeeded)
                    return (0, "User creation failed! Please check user details and try again.");

                if (!await roleManager.RoleExistsAsync(model.Role))
                    await roleManager.CreateAsync(new IdentityRole(model.Role));

                if (await roleManager.RoleExistsAsync(model.Role))
                    await userManager.AddToRoleAsync(user, model.Role);
                MailModel mailModel = new MailModel() {
                    ToEmail=user.Email,
                    Subject="Yeni Üyelik",
                    Body="Apartman Site Yönetim Sistemine hoşgeldiniz. Üyeliğiniz aktif edilmiştir. Şifreniz "+password+". Lütfen kimseyle paylaşmayınız "
                };
                mailService.SendEmailForPassword(mailModel);
                return (1, createUserResult.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return (0, "User creation failed! Please check user details and try again.");

        }

        public async Task<(int, string)> Login(LoginRequest model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
                return (0, "Invalid username");
            if (!await userManager.CheckPasswordAsync(user, model.Password))
                return (0, "Invalid password");

            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            string token = GenerateToken(authClaims);
            return (1, token);
        }


        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = configuration["JWT:ValidIssuer"],
                Audience = configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
