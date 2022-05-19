
using System.ComponentModel.DataAnnotations;

namespace EnviarEmailSmtp.Models
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress, Display(Name = "Endereço de e-mail registrado")]
        public string Email { get; set; }
        public bool EmailSent { get; set; }

        [Display(Name = "Digite o Assunto")]
        public string Assunto { get; set; }
        [Display(Name = "Digite uma Mensagem")]
        public string Mensagem { get; set; }
    }
}
