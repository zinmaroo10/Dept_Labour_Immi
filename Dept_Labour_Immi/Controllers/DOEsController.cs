using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dept_Labour_Immi.Controllers
{
    [Authorize]
    public class DOEsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DOEsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DOEs
        public async Task<IActionResult> Index()
        {
            return View(await _context.dOEs.ToListAsync());
        }

        // GET: DOEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dOEs == null)
            {
                return NotFound();
            }

            var dOE = await _context.dOEs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dOE == null)
            {
                return NotFound();
            }

            return View(dOE);
        }

        // GET: DOEs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DOEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DOENo,Date")] DOE dOE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dOE);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: DOEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dOEs == null)
            {
                return NotFound();
            }

            var dOE = await _context.dOEs.FindAsync(id);
            if (dOE == null)
            {
                return NotFound();
            }
            return View(dOE);
        }

        // POST: DOEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DOENo,Date")] DOE dOE)
        {
            if (id != dOE.ID)
            {
                return NotFound();
            }

            //if (ModelState.IsValid) ***** old_config
            //{
            //    try
            //    {
            //        _context.Update(bOD);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!BODExists(bOD.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            _context.Update(dOE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: DOEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dOEs == null)
            {
                return NotFound();
            }

            var dOE = await _context.dOEs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dOE == null)
            {
                return NotFound();
            }

            return View(dOE);
        }

        // POST: DOEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dOEs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.bODs'  is null.");
            }
            var dOE = await _context.dOEs.FindAsync(id);
            if (dOE != null)
            {
                _context.dOEs.Remove(dOE);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DOEExists(int id)
        {
            return _context.dOEs.Any(e => e.ID == id);
        }
    }
}
