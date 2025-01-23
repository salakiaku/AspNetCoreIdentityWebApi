using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityWebApi.DTO
{
    public class CreateUserRequestDTO
    {
        [Required(ErrorMessage ="O email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Password { get; set; }
    }
}
