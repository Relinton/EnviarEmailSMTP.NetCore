
using EnviarEmailSmtp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnviarEmailSmtp.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }
        //public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
