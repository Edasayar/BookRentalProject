using System.ComponentModel.DataAnnotations;

namespace CSProjeDemo1.UI.Dtos.LoginDto
{
    public class LoginMemberDto
    {
        [Required(ErrorMessage = "Kullanıcı Adınızı Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi Giriniz")]
        public string Password { get; set; }
    }
}
