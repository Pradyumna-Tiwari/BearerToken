using BererTokenPartTwo.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BererTokenPartTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepo _serviceRepo;

        public ServiceController(IServiceRepo serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        [HttpGet]
        [Route("Getusers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _serviceRepo.GetUsers();
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result.Value);
        }
    }
}
