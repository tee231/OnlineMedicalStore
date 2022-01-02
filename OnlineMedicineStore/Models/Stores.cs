using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicineStore.Models
{
    public class Stores
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public string ImageUrl { get; set; }
        public string Description { get; set; }
        //public Drugs Drugs { get; set; }
		public States? states { get; set; }
		public ICollection<Drugs> Drugs { get; set; }
        public string Photopath { get; set; }
        public string AspNetUsersId { get; set; }
    }
}
 