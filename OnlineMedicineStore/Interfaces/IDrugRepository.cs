using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMedicineStore.Models;

namespace OnlineMedicineStore.Interfaces
{
	 public interface IDrugRepository
	{

		void Add(Drugs drugs);
		void Edit(Drugs drugs);
		void Delete(Drugs drugs);
		Drugs GetDrugsbyId(int Id);
        IEnumerable<Drugs> GetDrugsByStore(Stores store);
		List<Drugs> GetAllDrugs();
		//List<Drugs> GetAllDrugsByStore(int Id);
		List<Drugs> GetDrugsByCode(string code);
		Drugs Update(Drugs changedValues);
		void AddDrugsToTheStore(int storeId, int drugId);
        void DeleteBy(Drugs changedValues);
        
    }
}

