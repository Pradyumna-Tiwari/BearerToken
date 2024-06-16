using BererTokenPartTwo.Models;
using BererTokenPartTwo.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BererTokenPartTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> SignupAsync(Signup signup)
        {
            var result = await _authRepo.SignupAsync(signup);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("Signin")]
        public async Task<ActionResult> Signin(Signin signin)
        {
            var result = await _authRepo.SigninAsync(signin);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<string>> GetUsers()
        {
            var list = new List<string>
            {
                "Harry",
                "Sonu",
                "Raghav"
            };

            return await Task.FromResult(list);
        }
    }
}
