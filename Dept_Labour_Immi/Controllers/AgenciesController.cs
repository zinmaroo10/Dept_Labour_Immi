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
    public class AgenciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Agencies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.agencies.Include(a => a.bOD).Include(a => a.thaiCompany);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Agencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.agencies == null)
            {
                return NotFound();
            }

            var agency = await _context.agencies
                .Include(a => a.bOD)
                .Include(a => a.thaiCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        // GET: Agencies/Create
        public IActionResult Create()
        {
            ViewData["BODID"] = new SelectList(_context.bODs, "ID", "ID");
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "ID");
            return View();
        }

        // POST: Agencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AgencyName,Address,RegNo,Phone,BODID,ThaiCompanyID")] Agency agency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BODID"] = new SelectList(_context.bODs, "ID", "ID", agency.BODID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "ID", agency.ThaiCompanyID);
            return View(agency);
        }

        // GET: Agencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.agencies == null)
            {
                return NotFound();
            }

            var agency = await _context.agencies.FindAsync(id);
            if (agency == null)
            {
                return NotFound();
            }
            ViewData["BODID"] = new SelectList(_context.bODs, "ID", "ID", agency.BODID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "ID", agency.ThaiCompanyID);
            return View(agency);
        }

        // POST: Agencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AgencyName,Address,RegNo,Phone,BODID,ThaiCompanyID")] Agency agency)
        {
            if (id != agency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgencyExists(agency.Id))
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
            ViewData["BODID"] = new SelectList(_context.bODs, "ID", "ID", agency.BODID);
            ViewData["ThaiCompanyID"] = new SelectList(_context.thaiCompanies, "ID", "ID", agency.ThaiCompanyID);
            return View(agency);
        }

        // GET: Agencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.agencies == null)
            {
                return NotFound();
            }

            var agency = await _context.agencies
                .Include(a => a.bOD)
                .Include(a => a.thaiCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        // POST: Agencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.agencies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.agencies'  is null.");
            }
            var agency = await _context.agencies.FindAsync(id);
            if (agency != null)
            {
                _context.agencies.Remove(agency);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgencyExists(int id)
        {
          return _context.agencies.Any(e => e.Id == id);
        }
    }
}
