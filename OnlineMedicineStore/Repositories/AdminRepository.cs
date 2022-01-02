using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMedicineStore.Database;
using OnlineMedicineStore.Interfaces;
using OnlineMedicineStore.Models;

namespace OnlineMedicineStore.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _application;
        public AdminRepository(ApplicationDbContext application)
        {
            _application = application;
        }
        public void Edit(ApplicationUser user)
        {
            var query = _application.Set<ApplicationUser>().Find(user.Id);
            query.FirstName = user.FirstName;
            query.lastName = user.lastName;
            //query.Drugs = stores.Drugs;
            query.Address = user.Address;
            query.UserName = user.UserName;
            query.Email = user.Email;
            _application.SaveChanges();

        }
        public List<ApplicationUser> GetAllStores()
        {
            var query = _application.Set<ApplicationUser>().ToList();
            return query;
        }

        public ApplicationUser GetUserbypass(string Id)
        {
            var query = _application.Set<ApplicationUser>()
                .Where(x => x.Id == Id).FirstOrDefault();
            return query;
        }
        public ApplicationUser Update(ApplicationUser changedValues)
        {
            var valu = _application.Users.Attach(changedValues);
            valu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _application.SaveChanges();
            return changedValues;

        }
        public ApplicationUser Delete(string id)
        {
            ApplicationUser user = _application.Users.Find(id);
            if (user != null)
            {
                _application.Users.Remove(user);
                _application.SaveChanges();
            }
            return user;
        }
    }
}
