
using Microsoft.AspNetCore.Identity;
using System;

namespace EnviarEmailSmtp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DataAniversario { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
    }
}
