
using System.ComponentModel.DataAnnotations;

namespace EnviarEmailSmtp.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Senha atual")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirme a nova senha")]
        [Compare("NewPassword", ErrorMessage = "A senha e a confirmação de senha não correspondem")]
        public string ConfirmNewPassword { get; set; }
    }
}
