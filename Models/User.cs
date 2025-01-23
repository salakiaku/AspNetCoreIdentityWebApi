using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentityWebApi.Models
{
    public class User : IdentityUser
    {
        public string Password {  get; set; }
    }
}
