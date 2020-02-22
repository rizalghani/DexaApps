using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DexaApps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DexaApps.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace DexaApps.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly DexaDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CustomerController(DexaDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            CustomerViewModel _allData = new CustomerViewModel()
            {
                ListCustomer = await _context.Customers.ToListAsync()
            };

            return View(_allData);
        }

        public IActionResult Create()
        {
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.Customers = new Customers();
            cvm.ListOutlets = _context.Outlets.ToList();

            return View(cvm);
        }

        [HttpPost]
        public IActionResult Create(List<Customers> item)
        {
            if (item != null)
            {
                foreach (Customers model in item)
                {
                    model.CreateBy = User.Identity.Name != null ? User.Identity.Name : "System";
                    model.CreateDate = DateTime.Now;

                    _context.Add(model);
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customers customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewBag.OutlateList = _context.Outlets.ToList();

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, Customers customers)
        {
            if (customers != null)
            {

                customers.UpdateBy = User.Identity.Name != null ? User.Identity.Name : "System";
                customers.UpdateDate = DateTime.Now;

                _context.Update(customers);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(long? id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}