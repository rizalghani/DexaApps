using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DexaApps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DexaApps.Models;

namespace DexaApps.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DexaDbContext _context;
        public CustomerController(DexaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Customers.ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            List<Customers> customers = new List<Customers>();
            customers.Add(new Customers());
            foreach(var item in customers)
            {
                item.OutletList = _context.Outlets.ToList();
            }

            return View(customers);
        }

        [HttpPost]
        public IActionResult Create(List<Customers> item)
        {
            if(item != null)
            {
                foreach(Customers model in item)
                {
                    model.CreateBy = "System";
                    model.CreateDate = DateTime.Now;

                    _context.Add(model);
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}