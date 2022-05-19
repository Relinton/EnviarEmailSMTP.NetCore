
using EnviarEmailSmtp.Models;
using EnviarEmailSmtp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EnviarEmailSmtp.Repository
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AutenticacaoRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IUserService _userService;
        //private readonly IEmailService _emailService;
        //private readonly IConfiguration _configuration;

        //public AutenticacaoRepository(UserManager<ApplicationUser> userManager,
        //    SignInManager<ApplicationUser> signInManager,
        //    RoleManager<IdentityRole> roleManager,
        //    IUserService userService,
        //    IEmailService emailService,
        //    IConfiguration configuration)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _roleManager = roleManager;
        //    _userService = userService;
        //    _emailService = emailService;
        //    _configuration = configuration;
        //}

        //public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        //{
        //    return await _userManager.FindByEmailAsync(email);
        //}

        //public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        //{
        //    var user = new ApplicationUser()
        //    {
        //        FirstName = userModel.FirstName,
        //        LastName = userModel.LastName,
        //        Email = userModel.Email,
        //        UserName = userModel.Email

        //    };
        //    var result = await _userManager.CreateAsync(user, userModel.Password);
        //    if (result.Succeeded)
        //    {
        //        await GenerateEmailConfirmationTokenAsync(user);
        //    }
        //    return result;
        //}

        //public async Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        //{
        //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        await SendEmailConfirmationEmail(user, token);
        //    }
        //}

        //public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
        //{
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        await SendForgotPasswordEmail(user, token);
        //    }
        //}

        //public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        //{
        //    return await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, true);
        //}

        //public async Task SignOutAsync()
        //{
        //    await _signInManager.SignOutAsync();
        //}

        //public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        //{
        //    var userId = _userService.GetUserId();
        //    var user = await _userManager.FindByIdAsync(userId);
        //    return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        //}


        //public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        //{
        //    return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        //}

        //private async Task SendEmailConfirmationEmail(ApplicationUser user, string token)
        //{
        //    string appDomain = _configuration.GetSection("Application:AppDomain").Value;
        //    string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

        //    UserEmailOptions options = new UserEmailOptions
        //    {
        //        ToEmails = new List<string>() { user.Email },
        //        PlaceHolders = new List<KeyValuePair<string, string>>()
        //        {
        //            new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
        //            new KeyValuePair<string, string>("{{Link}}",
        //                string.Format(appDomain + confirmationLink, user.Id, token))
        //        }
        //    };

        //    await _emailService.SendEmailForEmailConfirmation(options);
        //}

        //private async Task SendForgotPasswordEmail(ApplicationUser user, string token)
        //{
        //    string appDomain = _configuration.GetSection("Application:AppDomain").Value;
        //    string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

        //    UserEmailOptions options = new UserEmailOptions
        //    {
        //        ToEmails = new List<string>() { user.Email },
        //        PlaceHolders = new List<KeyValuePair<string, string>>()
        //        {
        //            new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
        //            new KeyValuePair<string, string>("{{Link}}",
        //                string.Format(appDomain + confirmationLink, user.Id, token))
        //        }
        //    };

        //    await _emailService.SendEmailForForgotPassword(options);
        //}

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<string> GenerateForgotPasswordTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            ForgotPasswordModel model = new ForgotPasswordModel();
            if (!string.IsNullOrEmpty(token))
            {
                string appdomain = "https://localhost:5001/";
                string confirmationlink = "Autenticacao/RedefinirSenha?uid={0}&token={1}";
                var sucesso = string.Format(appdomain + confirmationlink, user.Id, token);
                model.Mensagem = sucesso;
            }
            return model.Mensagem.ToString();
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
        }
    }
}
