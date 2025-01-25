using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentityWebApi.SeedConfiguration
{
    public static class RoleConfiguration
    {
        public static async Task SeedRole(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole( "User"));
        }
    }
}
