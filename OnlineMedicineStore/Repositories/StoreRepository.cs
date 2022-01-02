using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineMedicineStore.Database;
using OnlineMedicineStore.Interfaces;
using OnlineMedicineStore.Models;
using OnlineMedicineStore.ViewModel;

namespace OnlineMedicineStore.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ApplicationDbContext _application;
        public StoreRepository(ApplicationDbContext application)
        {
            _application = application;
        }
        public void Add(Stores stores)
        {
             _application.Set<Stores>().AddAsync(stores);
            _application.SaveChanges();
        }

        public void Delete(Stores stores)
        {

             _application.Set<Stores>().Remove(stores);
            _application.SaveChanges();
        }

        public void Edit(Stores stores)
        {
            var query =  _application.Set<Stores>().Find(stores.Id);
            query.Address = stores.Address;
            query.Description = stores.Description;
            //query.Drugs = stores.Drugs;
            query.Name = stores.Name;
            _application.SaveChanges();

        }

        public List<Stores> GetAllStores()
        {
            var query = _application.Set<Stores>().ToList();
            return query;
        }

        public Stores GetStorebyId(int Id)
        {
            var query = _application.Set<Stores>().FirstOrDefault(x => x.Id == Id);
            return query;

        }

        public List<Stores> GetStoresByMemberId(string code)
        {
            var query = _application.Set<Stores>()
                .Where(x => x.AspNetUsersId == code);
            return query.ToList();
        }

        public Stores GetStoresByViewModel(StoreDrugViewModel viewModel)
        {
            return _application.Set<Stores>().SingleOrDefault(x => x.Id == viewModel.StoreId);
        }

        //public List<Stores> GetStoresbyId(int Id)
        //{
        //    var query = _application.Set<Stores>()
        //        .Where(x => x.Id == Id);
        //    return query.ToList();
        //}



        //public ApplicationUser GetUserByStore(ApplicationUser app)
        //{
        //    return _application.Set<ApplicationUser>().SingleOrDefault(x => x.Id == app.Id);
        //}
    }
}
