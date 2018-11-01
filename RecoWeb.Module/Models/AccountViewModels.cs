using RecoWeb.Domain.LocalResource;
using System.ComponentModel.DataAnnotations;

namespace RecoWeb.Module.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resource))]
        public bool RememberMe { get; set; }

        [Display(Name = "Msg_Login_ForgetPw", ResourceType = typeof(Resource))]
        public string Msg_Login_ForgetPw { get; set; }

        [Display(Name = "Msg_Login_WelcomeSub", ResourceType = typeof(Resource))]
        public string Msg_Login_WelcomeSub { get; set; }

        [Display(Name = "Msg_Login_WelcomeTitle", ResourceType = typeof(Resource))]
        public string Msg_Login_WelcomeTitle { get; set; }

        [Display(Name = "InitialPassword", ResourceType = typeof(Resource))]
        public string InitialPassword { get; set; }

        [Display(Name = "LogIn", ResourceType = typeof(Resource))]
        public string LogIn { get; set; }

    }
    public class ManageUserInfo
    {
        [Required]
        public string UserName { get; set; }
    }
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
