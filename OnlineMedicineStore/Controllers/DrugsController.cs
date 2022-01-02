using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineMedicineStore.Interfaces;
using OnlineMedicineStore.Models;
using System.IO;
using OnlineMedicineStore.ViewModel;

namespace OnlineMedicineStore.Controllers
{
    public class DrugsController : Controller
    {
		private readonly IDrugRepository _drugRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStoreRepository storeRepository;
		public DrugsController(IDrugRepository drugRepository,IHostingEnvironment hostingEnvironment, IStoreRepository storeRepository)
		{
			_drugRepository = drugRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.storeRepository = storeRepository;
		}

        [HttpGet]
        public IActionResult update(Stores store)
        {
            return View();
        }

        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		

        private StoreDrugViewModel GetStoreDrugView(Stores store)
        {
            StoreDrugViewModel viewModel = new StoreDrugViewModel();
            viewModel.Store = store;
            viewModel.Drugs = _drugRepository.GetDrugsByStore(store);
            return viewModel;
        }
        public IActionResult CreateByStore(int id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Stores storeChoice = storeRepository.GetStorebyId(id);
            if (storeChoice==null)
            {
                return NotFound();
            }
            StoreDrugViewModel viewModel = GetStoreDrugView(storeChoice);
            viewModel.Store = storeChoice;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CreateByStore( StoreDrugViewModel viewModel,Drugs config)
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
                Drugs drugs = new Drugs
                {
					Stores = storeRepository.GetStorebyId(viewModel.StoreId),
					Name = viewModel.Name,
                    Description = viewModel.Description,
                    Photopath = uniqueFileName
                };
                Stores storeschoice = storeRepository.GetStoresByViewModel(viewModel);
                if (storeschoice==null)
                {
                    return NotFound();
                }
                viewModel.Store = storeschoice;
                drugs.Stores = viewModel.Store;
                _drugRepository.Add(drugs);
                viewModel = GetStoreDrugView(storeschoice);
                return View(viewModel);

            }
            return View();
        }
        [HttpGet]
		public IActionResult Edit(int id)
		{
			Drugs drugs = _drugRepository.GetDrugsbyId(id);
			EditDrug editDrug = new EditDrug
			{
				Id = drugs.Id,
				Name = drugs.Name,
				Description = drugs.Description
			};
			return View(editDrug);
		}
		[HttpPost]
		public IActionResult Edit(EditDrug drugs)
		{
			if (ModelState.IsValid)
			{
				Drugs drug = _drugRepository.GetDrugsbyId(drugs.Id);
				drug.Name = drugs.Name;
				drug.Description = drugs.Description;


				_drugRepository.Update(drug);
                return RedirectToAction("CreateByStore", "Drugs", new
                {
                    Id = drug.StoresId
                });
                //return RedirectToAction("CreateByStore");
			}
			return View();
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			Drugs doctor = _drugRepository.GetDrugsbyId(id);
			_drugRepository.Delete(doctor);
            return RedirectToAction("CreateByStore", "Drugs", new
            {
                Id = doctor.StoresId
            });
            //return RedirectToAction("CreateByStore");
		}

       
    }
}