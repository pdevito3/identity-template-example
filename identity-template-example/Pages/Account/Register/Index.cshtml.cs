using Microsoft.AspNetCore.Mvc.RazorPages;

namespace identity_template_example.Pages.Account.Register;

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using IdentityModel;
using Models;
using Services;

[AllowAnonymous]
public class Index : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IPasswordValidator<ApplicationUser> _passwordValidator;
    private readonly ILogger<Index> _logger;
    private readonly IEmailService _emailService;

    public Index(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ILogger<Index> logger, 
        IPasswordValidator<ApplicationUser> passwordValidator, 
        IEmailService emailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
        _passwordValidator = passwordValidator;
        _emailService = emailService;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public string ReturnUrl { get; set; }

    public string Role { get; set; }

    public IList<AuthenticationScheme> ExternalLogins { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public async Task OnGetAsync(string returnUrl = null, string role = "User")
    {
        ReturnUrl = returnUrl;
        Role = role;
        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null, string role = "User")
    {
        returnUrl ??= Url.Content("~/");
        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
        var user = new ApplicationUser() { UserName = Input.Email, Email = Input.Email };
        var passwordValidationResult = await _passwordValidator.ValidateAsync(_userManager, user, Input.Password);
        if (!passwordValidationResult.Succeeded)
        {
            foreach (var identityError in passwordValidationResult.Errors)
            {
                ModelState.AddModelError(identityError.Code, identityError.Description);
            }
        }

        if (ModelState.IsValid)
        {
            var result = await _userManager.CreateAsync(user, Input.Password);
            IdentityResult claimResult = null;
            if (result.Succeeded)
            {
                claimResult = await _userManager.AddToRoleAsync(user, role);

                if (claimResult != null && claimResult.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailService.SendEmail(
                        Input.Email, 
                        "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            
            if (claimResult != null)
            {
                foreach (var error in claimResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }

        // If we got this far, something failed, redisplay form
        return Page();
    }
}