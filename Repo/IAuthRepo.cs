using BererTokenPartTwo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BererTokenPartTwo.Repo
{
    public interface IAuthRepo
    {
        Task<IdentityResult> SignupAsync(Signup signup);
        Task<string> SigninAsync(Signin signin);
    }
}
