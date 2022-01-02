using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineMedicineStore.Models;

namespace OnlineMedicineStore.ViewModel
{
    public class DrugsCreateViewModel
    {
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DrugStore> Stores { get; set; }
        public string Photopath { get; set; }
    }
}
