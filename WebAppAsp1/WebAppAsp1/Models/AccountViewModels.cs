using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAppAsp1.Models.Entities;

namespace WebAppAsp1.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
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
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запомнить браузер?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Name length must be between {0} and {2} ", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Patronymicname { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Type { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }
    }

    public class ProfileViewModel
    {
        public static ProfileViewModel Init(Trainer profile)
        {
            return new ProfileViewModel()
            {
                Address = profile.Address,
                Age = profile.Age,
                City = profile.City,
                Gender = profile.Gender,
                Name = profile.Name,
                Patronymicname = profile.Patronymicname,
                Phone = profile.Phone,
                Surname = profile.Surname
            };
        }

        public static ProfileViewModel Init(Client profile)
        {
            return new ProfileViewModel()
            {
                Address = profile.Address,
                Age = profile.Age,
                City = profile.City,
                Gender = profile.Gender,
                Name = profile.Name,
                Patronymicname = profile.Patronymicname,
                Phone = profile.Phone,
                Surname = profile.Surname
            };
        }

        public static Client InitFromModel(ProfileViewModel model, Client profile)
        {
            profile.Name = model.Name;
            profile.Surname = model.Surname;
            profile.Patronymicname = model.Patronymicname;
            profile.Age = model.Age;
            profile.Address = model.Address;
            profile.City = model.City;
            profile.Gender = model.Gender;
            profile.Phone = model.Phone;

            return profile;
        }

        public static Trainer InitFromModel(ProfileViewModel model, Trainer profile)
        {
            profile.Name = model.Name;
            profile.Surname = model.Surname;
            profile.Patronymicname = model.Patronymicname;
            profile.Age = model.Age;
            profile.Address = model.Address;
            profile.City = model.City;
            profile.Gender = model.Gender;
            profile.Phone = model.Phone;

            return profile;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Patronymicname { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
