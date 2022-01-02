using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineMedicineStore.Database;
using OnlineMedicineStore.Interfaces;
using OnlineMedicineStore.Models;

namespace OnlineMedicineStore.Repositories
{
	public class DrugRepository:IDrugRepository
	{

		private readonly ApplicationDbContext _application;
		public DrugRepository(ApplicationDbContext application)
		{
			_application = application;
		}
		public void Add(Drugs drugs)
		{
			_application.Set<Drugs>().AddAsync(drugs);
			_application.SaveChanges();
		}

		public void Delete(Drugs drugs)
		{
			_application.Set<Drugs>().Remove(drugs);
			_application.SaveChanges();
		}

		public void Edit(Drugs drugs)
		{
			var query = _application.Set<Drugs>().Find(drugs.Id);
			query.Description = drugs.Description;
			query.Description = drugs.Description;
			//query.Drugs = stores.Drugs;
			query.Name = drugs.Name;
			_application.SaveChanges();

		}

		public List<Drugs> GetAllDrugs()
		{
			var query = _application.Set<Drugs>().Include(x => x.Stores)
				.ToList();
			return query;
		}

		public Drugs GetDrugsbyId(int Id)
		{
			var query = _application.Set<Drugs>()
				.Where(x => x.Id == Id).FirstOrDefault();
			return query;
		}

		public List<Drugs> GetDrugsByCode(string code)
		{
			var query = _application.Set<Drugs>()
				.Where(x => x.Name == code);
			return query.ToList();
		}

		public Drugs Update(Drugs changedValues)
		{ 
				var valu = _application.Drugs.Attach(changedValues);
			valu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				_application.SaveChanges();
				return changedValues;
			
		}
      

        public List<Drugs> GetAllDrugsByStore(int Id)
		{
			var query = _application.Set<DrugStore>()
				.Where(x => x.StoresId == Id).Include(x => x.Drugs).Select(x => new Drugs
				{
					Id = x.Drugs.Id,
					Name = x.Drugs.Name,
					Description = x.Drugs.Description
				}).ToList();
			return query;
		}

		public void AddDrugsToTheStore(int storeId, int drugId)
		{
			var entity = new DrugStore
			{
				StoresId = storeId,
				DrugsId = drugId
			};
			_application.Set<DrugStore>().Add(entity);
		}

        public IEnumerable<Drugs> GetDrugsByStore(Stores store)
        {
            var entity = _application.Set<Drugs>().Where(x => x.Stores == store);
            return entity;
        }

        public void DeleteBy(Drugs changedValues)
        {
            var valu = _application.Drugs.Attach(changedValues);
            valu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _application.Remove(valu);
            _application.SaveChanges();
            
        }
    }
}
