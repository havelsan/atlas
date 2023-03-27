using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using TTStorageManager.Security;

namespace Core.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl
        {
            get;
            set;
        }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider
        {
            get;
            set;
        }

        public ICollection<SelectListItem> Providers
        {
            get;
            set;
        }

        public string ReturnUrl
        {
            get;
            set;
        }

        public bool RememberMe
        {
            get;
            set;
        }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Code")]
        public string Code
        {
            get;
            set;
        }

        public string ReturnUrl
        {
            get;
            set;
        }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser
        {
            get;
            set;
        }

        public bool RememberMe
        {
            get;
            set;
        }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }
    }

    public class LoginViewModel
    {
        [Required]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }
    }

    public class AuthViewModel
    {
        public string ClientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Realm { get; set; }
        public Guid CaptchaGuid { get; set; }
        public string CaptchaCode { get; set; }
    }

    public class AuthViewResultModel
    {
        public Guid CaptchaGuid { get; set; }
        public string CaptchaImage { get; set; }
        public string ErrorMessage { get; set; }
        public string access_token { get; set; }
        public string id_token { get; set; }
        public TTUser user { get; set; }
        //Süresi dolan şifreyi değiştirmek için
        public AuthenticationResultEnum AuthResultEnum { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword
        {
            get;
            set;
        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }
    }

    public class InputFor_HasRole
    {
        public Guid roleID
        {
            get;
            set;
        }
    }
}