using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineMedicineStore.Models;

namespace OnlineMedicineStore.ViewModel
{
    public class StorePhotoViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        //public string ImageUrl { get; set; }
        public string Description { get; set; }
        //public Drugs Drugs { get; set; }
        public States? states { get; set; }
        public int loginId { get; set; }
        public ICollection<Drugs> Drugs { get; set; }
        public IFormFile Photo { get; set; }
		
    }
}
