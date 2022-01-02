using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicineStore.Models
{
    public class RegisterViewModel
    {
       
        [Required]
        [Column(TypeName ="nvarchar(250)")]
        [Display(Name = "User Name")]
        public string usernames { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Last Name")]
        public string LastNames { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "First Name")]
        public string FirstNames { get; set; }

        [Required]
        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings =false)]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
