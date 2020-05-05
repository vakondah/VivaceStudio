using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter new password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please confirm password.")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
