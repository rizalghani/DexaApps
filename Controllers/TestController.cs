using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DexaApps.Data;
using DexaApps.Models;

namespace DexaApps.Controllers
{
    public class TestController : Controller
    {
        private readonly DexaDbContext _context;

        public TestController(DexaDbContext context)
        {
            _context = context;
        }

        // GET: Test
        public async Task<IActionResult> Index()
        {
            var data = await _context.Customers.ToListAsync();
            return View(data);
        }

        // GET: Test/Details/5
        public async Task<IActionResult> Details(long? id)
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

        // GET: Test/Create
        public IActionResult Create()
        {
            Customers customer = new Customers()
            {
                OutletList = _context.Outlets.ToList()
            };

            //ViewData["Outlets"] = _context.Outlets.ToList();

            return View(customer);
        }

        // POST: Test/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,CustomerName,Address,Code,OutletID")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                customers.CreateBy = "User";
                customers.CreateDate = DateTime.Now;

                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        // POST: Test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("CustomerID,CustomerName,Address,Code,OutletID")] Customers customers)
        {
            if (id != customers.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    customers.UpdateBy = "User";
                    customers.UpdateDate = DateTime.Now;

                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.CustomerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }

        // GET: Test/Delete/5
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

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(long? id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
