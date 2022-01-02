using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMedicineStore.Models;
using OnlineMedicineStore.ViewModel;

namespace OnlineMedicineStore.Interfaces
{
    public interface IStoreRepository
    {
        void Add(Stores stores);
        void Edit(Stores stores);
        void Delete(Stores stores);
        Stores GetStorebyId(int Id);
        Stores GetStoresByViewModel(StoreDrugViewModel viewModel);
        //ApplicationUser GetUserByStore(ApplicationUser app);
        List<Stores> GetAllStores();
       
        List<Stores> GetStoresByMemberId(string code);
    }
}
