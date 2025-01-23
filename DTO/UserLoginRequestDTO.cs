using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityWebApi.DTO
{
    public class UserLoginRequestDTO
    {
        [Required(ErrorMessage ="O nome do usuário é obrigatório!")]
        public string UserName {  get; set; }

        [Required(ErrorMessage = "A senha é obrigatório!")]
        public string Password { get; set; }
    }
}
