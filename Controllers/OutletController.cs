using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DexaApps.Data;
using DexaApps.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace DexaApps.Controllers
{
    //[Authorize]
    public class OutletController : Controller
    {
        private readonly DexaDbContext _context;

        public OutletController(DexaDbContext context)
        {
            _context = context;
        }

        // GET: Outlet
        public async Task<IActionResult> Index()
        {
            return View(await _context.Outlets.ToListAsync());
        }

        // GET: Outlet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlets = await _context.Outlets
                .FirstOrDefaultAsync(m => m.OutletID == id);
            if (outlets == null)
            {
                return NotFound();
            }

            return View(outlets);
        }

        // GET: Outlet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Outlet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OutletID,OutletName")] Outlets outlets)
        {
            if (ModelState.IsValid)
            {
                outlets.CreateBy = "User";
                outlets.CreateDate = DateTime.Now;

                _context.Add(outlets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(outlets);
        }

        // GET: Outlet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlets = await _context.Outlets.FindAsync(id);
            if (outlets == null)
            {
                return NotFound();
            }
            return View(outlets);
        }

        // POST: Outlet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("OutletID,OutletName")] Outlets outlets)
        {
            if (id != outlets.OutletID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    outlets.UpdateBy = "user";
                    outlets.UpdateDate = DateTime.Now;

                    _context.Update(outlets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutletsExists(outlets.OutletID))
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
            return View(outlets);
        }

        // GET: Outlet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlets = await _context.Outlets
                .FirstOrDefaultAsync(m => m.OutletID == id);
            if (outlets == null)
            {
                return NotFound();
            }

            return View(outlets);
        }

        // POST: Outlet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var outlets = await _context.Outlets.FindAsync(id);
            _context.Outlets.Remove(outlets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutletsExists(int? id)
        {
            return _context.Outlets.Any(e => e.OutletID == id);
        }
    }
}
