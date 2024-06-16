using BererTokenPartTwo.DTO;
using BererTokenPartTwo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace BererTokenPartTwo.Repo
{
    public interface IServiceRepo
    {
        Task<ActionResult<IEnumerable<UsersDTO>>> GetUsers();
    }
}
