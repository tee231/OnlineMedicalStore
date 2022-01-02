using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMedicineStore.Models
{
    public class Drugs
    {
        public int Id { get; set; }
		[Required]
        public  string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<DrugStore>Stores { get; set; }
        public Stores Stores { get; set; }
        public int StoresId { get; set; }
        public string Photopath { get; set; }

    }
}
