using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriculturalResourceManagement.DataAccess;
using AgriculturalResourceManagement.Models;

namespace AgriculturalResourceManagement.Controllers
{
    public class Report1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Report1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Report1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Report1.ToListAsync());
        }

        // GET: Report1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report1 = await _context.Report1
                .FirstOrDefaultAsync(m => m.id == id);
            if (report1 == null)
            {
                return NotFound();
            }

            return View(report1);
        }

        // GET: Report1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Report1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,desc")] Report1 report1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(report1);
        }

        // GET: Report1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report1 = await _context.Report1.FindAsync(id);
            if (report1 == null)
            {
                return NotFound();
            }
            return View(report1);
        }

        // POST: Report1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,desc")] Report1 report1)
        {
            if (id != report1.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Report1Exists(report1.id))
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
            return View(report1);
        }

        // GET: Report1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report1 = await _context.Report1
                .FirstOrDefaultAsync(m => m.id == id);
            if (report1 == null)
            {
                return NotFound();
            }

            return View(report1);
        }

        // POST: Report1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report1 = await _context.Report1.FindAsync(id);
            _context.Report1.Remove(report1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Report1Exists(int id)
        {
            return _context.Report1.Any(e => e.id == id);
        }
    }
}
