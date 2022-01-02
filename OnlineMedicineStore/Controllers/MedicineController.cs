using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMedicineStore.Database;

using OnlineMedicineStore.Interfaces;
using OnlineMedicineStore.Models;
using OnlineMedicineStore.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace OnlineMedicineStore.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        //private readonly ApplicationDbContext _context;
        private readonly IStoreRepository _store;
        public MedicineController(IStoreRepository store, IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
          
            _store = store;
            this.hostingEnvironment = hostingEnvironment;
         //   _context = context;
        }
        
        [HttpGet]
        public IActionResult Store()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                     var query = _store.GetAllStores();
                    return View(query);
                }
                else
                {
                    var code = User.Claims.ToList()
                     .Where(u => u.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))
                     .FirstOrDefault().Value;
                    //var code = _context.Users.Select(x => x.Id).FirstOrDefault();
                    var query = _store.GetStoresByMemberId(code);
                    //var query = _store.GetStoresbyId(Id);s
                    return View(query);
                }
                
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(StorePhotoViewModel viewModel, Stores stores, ApplicationUser app)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (viewModel.Photo != null)
                {

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    viewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                var test = User.Claims.ToList()
             .Where(u => u.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))
             .FirstOrDefault().Value;
                //var test = _context.Users.Select(x => x.Id).FirstOrDefault();
                var newStore = new Stores
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    Address = viewModel.Address,
                    states = viewModel.states,
                    Photopath = uniqueFileName,
                    AspNetUsersId = test
                   
                };
                ////Stores storeschoice = storeRepository.GetStoresByViewModel(viewModel);
                ////if (storeschoice == null)
                ////{
                ////    return NotFound();
                ////}
                ////viewModel.Store = storeschoice;
                ////drugs.Stores = viewModel.Store;
                ////_drugRepository.Add(drugs);
                ////viewModel = GetStoreDrugView(storeschoice);
                ////return View(viewModel);
                //ApplicationUser applicationUser = _store.GetUserByStore(app);
                //if(applicationUser==null)
                //{
                //    return NotFound();
                //}
                //app.stores = applicationUser.stores;

                _store.Add(newStore);
                return RedirectToAction("Store");
                //return RedirectToAction("Store", "Medicine", new
                //{
                //    Id = stores.Id
                //});
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var query = _store.GetStorebyId(Id);
            return View(query);
        }
        [HttpPost]
        
        public IActionResult Edit(Stores stores)
        {
            if (ModelState.IsValid)
            {
                _store.Edit(stores);
                
            }
            return RedirectToAction("Store");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var query = _store.GetStorebyId(id);
            _store.Delete(query);
            return RedirectToAction("Store");
        }
        //[HttpPost]
        //public IActionResult Delete(Stores stores)
        //{
        //    _store.Delete(stores);
        //    return RedirectToAction("Store");
        //}
    }
}