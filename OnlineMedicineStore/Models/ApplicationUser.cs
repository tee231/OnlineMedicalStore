using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicineStore.Models
{
    public class ApplicationUser : IdentityUser
    
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime Dob { get; set; }
       //public int LoginId { get; set; }
       public Stores stores { get; set; }
        
    }
}
