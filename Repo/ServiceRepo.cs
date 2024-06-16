using BererTokenPartTwo.DTO;
using BererTokenPartTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using AppContext = BererTokenPartTwo.Data.AppContext;

namespace BererTokenPartTwo.Repo
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly AppContext _appContext;
        public ServiceRepo(AppContext appContext)
        {
            _appContext = appContext;
        }


        public async Task<ActionResult<IEnumerable<UsersDTO>>> GetUsers()
        {
            //var result = await _appContext.AppUsers.ToListAsync();
            var result = await _appContext.AppUsers
                                      .Select(b => new UsersDTO
                                      {
                                          FirstName = b.FirstName,
                                          LastName = b.LastName,
                                          Username = b.UserName,
                                          Email = b.Email
                                      })
                                      .ToListAsync();
            if (result==null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        
    }
}
