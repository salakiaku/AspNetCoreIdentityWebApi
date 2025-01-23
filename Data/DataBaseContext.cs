using AspNetCoreIdentityWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace AspNetCoreIdentityWebApi.Data
{
    public class DataBaseContext : IdentityDbContext<User>
    {
        public DataBaseContext( DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
