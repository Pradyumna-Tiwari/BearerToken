

using BererTokenPartTwo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BererTokenPartTwo.Repo
{
    public class AuthRepo : IAuthRepo
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;

        public AuthRepo(UserManager<AppUser> usermanger, SignInManager<AppUser> signinmanager,
            IConfiguration configurartion)
        {
            _userManager = usermanger;
            _signInManager = signinmanager;
            _config = configurartion;
        }

        public async Task<IdentityResult> SignupAsync(Signup signup)
        {
            var userdata = new AppUser
            {
                FirstName = signup.FirstName,
                LastName = signup.LastName,
                Email = signup.Email,
                UserName = signup.UserName,
            };

            return await _userManager.CreateAsync(userdata, signup.Password);
        }

        public async Task<string> SigninAsync(Signin signin)
        {
            var result = await _signInManager.PasswordSignInAsync(signin.Username, signin.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var SigninClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,signin.Username),

                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
          
            var authKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWT:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                expires: DateTime.Now.AddDays(1),
                claims: SigninClaim,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)

                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
