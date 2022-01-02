using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicineStore.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="UserName is Required")]
        [MaxLength(15)]
        [Display(Name = "UserName")]
        public string UserName{ get; set; }
        [Required (ErrorMessage = "Password is Required")]
        [DataType(DataType.Password), MaxLength(15)]
        [Display(Name = "Password")]
        public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }

    }
}

