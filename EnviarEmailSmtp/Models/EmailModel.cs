
using System.ComponentModel.DataAnnotations;

namespace EnviarEmailSmtp.Models
{
    public class EmailModel
    {
        [Required, Display(Name = "Digite o Email de destino"), EmailAddress]
        public string Destino { get; set; }
        [Required, Display(Name = "Digite o Assunto")]
        public string Assunto { get; set; }
        [Required, Display(Name = "Digite uma Mensagem")]
        public string Mensagem { get; set; }
    }
}
