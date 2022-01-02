using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineMedicineStore.Database;
using OnlineMedicineStore.Interfaces;
using OnlineMedicineStore.Models;

namespace OnlineMedicineStore
{
    public class StoreOwnerController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        private readonly IAdminRepository _admin;

        public StoreOwnerController(IAdminRepository admin, ApplicationDbContext context)
        {
            _context = context;
            _admin = admin;
          
        }

        // GET: StoreOwner
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var query = _admin.GetAllStores();
          
            return View(query);
           
            //return View(await _context.StoreOwnerDetails.ToListAsync());
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            ApplicationUser user = _admin.GetUserbypass(id);
           ApplicationUser editDrug = new ApplicationUser
            {
               FirstName = user.FirstName,
            lastName = user.lastName,
            Address = user.Address,
            Email = user.Email,
            UserName = user.UserName,
        };
            return View(editDrug);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser done = _admin.GetUserbypass(user.Id);
                done.FirstName = user.FirstName;
                done.lastName = user.lastName;
                done.Address = user.Address;
                done.Email = user.Email;
                done.UserName = user.UserName;
                _admin.Update(done);
                return RedirectToAction("Index");

                //return RedirectToAction("CreateByStore");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            ApplicationUser user = _admin.GetUserbypass(id);
            _admin.Delete(id);
            
            return RedirectToAction("Index");
        }
        // GET: StoreOwner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeOwnerDetails = await _context.StoreOwnerDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeOwnerDetails == null)
            {
                return NotFound();
            }

            return View(storeOwnerDetails);
        }

        // GET: StoreOwner/Create
        //public IActionResult AddorEdit(int Id = 0)
        //{
        //    if (Id == 0)

        //        return View();
        //    else
        //        return View(_context.StoreOwnerDetails.Find(Id));
                    
        //}

        // POST: StoreOwner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddorEdit([Bind("Id,FirstName,LastName,Email,PhoneNumber,DateOfBirth,ImageUrl")] StoreOwnerDetails storeOwnerDetails)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if(storeOwnerDetails.Id ==0)
        //        _context.Add(storeOwnerDetails); 
        //        else
        //            _context.Update(storeOwnerDetails); // is used for the edit 
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(storeOwnerDetails);
        //}

        // GET: StoreOwner/Edit/5
       

        // GET: StoreOwner/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var storeOwnerDetails = await _context.StoreOwnerDetails
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (storeOwnerDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(storeOwnerDetails);
        //}

        // POST: StoreOwner/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var storeOwnerDetails = await _context.StoreOwnerDetails.FindAsync(id);
        //    _context.StoreOwnerDetails.Remove(storeOwnerDetails);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool StoreOwnerDetailsExists(int id)
        {
            return _context.StoreOwnerDetails.Any(e => e.Id == id);
        }
       
    }
}
