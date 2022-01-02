using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMedicineStore.Database;
using OnlineMedicineStore.Interfaces;
using OnlineMedicineStore.Models;
using OnlineMedicineStore.ViewModel;

namespace OnlineMedicineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDrugRepository _drugRepository;
        private readonly IHostingEnvironment hostingEnvironment;
		private readonly IStoreRepository storeRepository;
		public HomeController(IDrugRepository drugRepository, IHostingEnvironment hostingEnvironment, ApplicationDbContext context, IStoreRepository storeRepository)
        {
            _context = context;
            _drugRepository = drugRepository;
            this.hostingEnvironment = hostingEnvironment;
			this.storeRepository = storeRepository;
		}
        //[HttpGet]
        //public async Task<IActionResult> Index()

        //{
        //    var words = from word in _context.Drugs
        //                select word;
          
        //    //_drugRepository.GetAllDrugs();
        //    return View(await words.ToListAsync());
        //}
        //[HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            var y = _drugRepository.GetAllDrugs();
            var x = y.Select(s =>
            {
                return new Drugs
                {
                    Stores = storeRepository.GetStorebyId(s.StoresId),
                    Name = s.Name,
                    Description = s.Description,
                    Photopath = s.Photopath,
                    StoresId = s.StoresId
                };
            });

            var words = from word in _context.Drugs
                        select word;
			if (!String.IsNullOrEmpty(search))
			{
				words = words.Where(s => s.Name.Contains(search));
			
			}
			if (words == null)
				return View();

			
			
			return View(await words.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
