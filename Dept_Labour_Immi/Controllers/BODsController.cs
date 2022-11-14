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
    public class BODsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BODsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BODs
        public async Task<IActionResult> Index()
        {
              return View(await _context.bODs.ToListAsync());
        }

        // GET: BODs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bODs == null)
            {
                return NotFound();
            }

            var bOD = await _context.bODs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bOD == null)
            {
                return NotFound();
            }

            return View(bOD);
        }

        // GET: BODs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BODs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Position,NRC,Phone")] BOD bOD)
        {
            //if (ModelState.IsValid)  ___ old ---
            //{
            //    _context.Add(bOD);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(bOD);


            _context.Add(bOD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: BODs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bODs == null)
            {
                return NotFound();
            }

            var bOD = await _context.bODs.FindAsync(id);
            if (bOD == null)
            {
                return NotFound();
            }
            return View(bOD);
        }

        // POST: BODs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Position,NRC,Phone")] BOD bOD)
        {
            if (id != bOD.ID)
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
            _context.Update(bOD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: BODs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bODs == null)
            {
                return NotFound();
            }

            var bOD = await _context.bODs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bOD == null)
            {
                return NotFound();
            }

            return View(bOD);
        }

        // POST: BODs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bODs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.bODs'  is null.");
            }
            var bOD = await _context.bODs.FindAsync(id);
            if (bOD != null)
            {
                _context.bODs.Remove(bOD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BODExists(int id)
        {
          return _context.bODs.Any(e => e.ID == id);
        }
    }
}
