
using EnviarEmailSmtp.Models;
using EnviarEmailSmtp.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EnviarEmailSmtp.Repository
{
    public interface IAutenticacaoRepository
    {
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<string> GenerateForgotPasswordTokenAsync(ApplicationUser user);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel model);

        //Task SignOutAsync();

        //Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);

        //Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

        //Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);
    }
}
