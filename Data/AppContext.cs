using BererTokenPartTwo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BererTokenPartTwo.Data
{
    public class AppContext:IdentityDbContext<AppUser>
    {
        public AppContext(DbContextOptions<AppContext>options):base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
                
        
    }
}
