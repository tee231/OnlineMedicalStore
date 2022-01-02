using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineMedicineStore.Models;

namespace OnlineMedicineStore.ViewModel
{
    public class StoreDrugViewModel
    {
        public Stores Store { get; set; }
        public IEnumerable<Drugs> Drugs { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }

    }
}
