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
    public class ThaiCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThaiCompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThaiCompanys
        public async Task<IActionResult> Index()
        {
            List<ThaiCompany> comList = new List<ThaiCompany>();
            comList = await _context.thaiCompanies.ToListAsync();

            //return View(await _context.thaiCompanies.ToListAsync());
            return View(comList);
        }

        // GET: ThaiCompanys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.thaiCompanies == null)
            {
                return NotFound();
            }

            var thaiCompany = await _context.thaiCompanies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thaiCompany == null)
            {
                return NotFound();
            }

            return View(thaiCompany);
        }

        // GET: ThaiCompanys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThaiCompanys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CompanyName")] ThaiCompany thaiCompany)
        {
            try
            {
                _context.Add(thaiCompany);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            //_context.Add(thaiCompany);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ThaiCompanys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.thaiCompanies == null)
            {
                return NotFound();
            }

            var thaiCompany = await _context.thaiCompanies.FindAsync(id);
            if (thaiCompany == null)
            {
                return NotFound();
            }
            return View(thaiCompany);
        }

        // POST: ThaiCompanys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CompanyName")] ThaiCompany thaiCompany)
        {
            if (id != thaiCompany.ID)
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
            _context.Update(thaiCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ThaiCompanys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.thaiCompanies == null)
            {
                return NotFound();
            }

            var thaiCompany = await _context.thaiCompanies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thaiCompany == null)
            {
                return NotFound();
            }

            return View(thaiCompany);
        }

        // POST: ThaiCompanys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.thaiCompanies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.bODs'  is null.");
            }
            var thaiCompany = await _context.thaiCompanies.FindAsync(id);
            if (thaiCompany != null)
            {
                _context.thaiCompanies.Remove(thaiCompany);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThaiCompanyExists(int id)
        {
            return _context.thaiCompanies.Any(e => e.ID == id);
        }
    }
}
