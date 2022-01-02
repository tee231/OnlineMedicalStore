using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMedicineStore.Models;

namespace OnlineMedicineStore.Interfaces
{
    public interface IAdminRepository
    {
        List<ApplicationUser> GetAllStores();
        ApplicationUser GetUserbypass(string Id);
        ApplicationUser Update(ApplicationUser changedValues);
        ApplicationUser Delete(string id);
    }
}
