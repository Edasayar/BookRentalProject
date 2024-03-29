using System.ComponentModel.DataAnnotations;

namespace ProjeDemo1.API.Dtos.LoginDtos
{
    public class LoginDto
    {
        
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
