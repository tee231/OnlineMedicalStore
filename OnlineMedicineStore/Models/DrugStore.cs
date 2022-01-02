using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicineStore.Models
{
	public class DrugStore
	{
		public int DrugsId { get; set; }
		
		public Drugs Drugs { get; set; }
		public Stores Stores { get; set; }

		public int StoresId{ get; set; }
	}
}
