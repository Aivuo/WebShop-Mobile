using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShop_Mobile.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Kom ihåg den här webbläsaren?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Display(Name = "Kom ihåg mig?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Bekräfta email")]
        [Compare("Email", ErrorMessage = "Email matchar inte bekräfta email.")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Det {0} måste minst vara {2} bokstäver långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Password", ErrorMessage = "Lösenordet matchar inte beekräfta lösenord.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Förnamn")]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Efternamn")]
        public string Lastname { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Faktureringsadress")]
        public string BillingAdress { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Fakturerings postnummer")]
        public string BillingZip { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Fakturerings postort")]
        public string BillingCity { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Leveransadress")]
        public string DeliveryAdress { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Postnummer")]
        public string DeliveryZip { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Postort")]
        public string DeliveryCity { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Det {0} måste minst vara {2} bokstäver långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Password", ErrorMessage = "Lösenordet matchar inte beekräfta lösenord.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
