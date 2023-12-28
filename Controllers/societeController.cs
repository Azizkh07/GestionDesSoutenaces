using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionDesSoutenaces.Data;
using GestionDesSoutenaces.Models;

namespace GestionDesSoutenaces.Controllers
{
    public class societeController : Controller
    {
        private readonly SoutenaceContext _context;

        public societeController(SoutenaceContext context)
        {
            _context = context;
        }

        // GET: societe
        public async Task<IActionResult> Index()
        {
            return View(await _context.SOCIETE.ToListAsync());
        }

        // GET: societe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sOCIETE = await _context.SOCIETE
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sOCIETE == null)
            {
                return NotFound();
            }

            return View(sOCIETE);
        }

        // GET: societe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: societe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Lib,Adresse,Tel")] SOCIETE sOCIETE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sOCIETE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sOCIETE);
        }

        // GET: societe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sOCIETE = await _context.SOCIETE.FindAsync(id);
            if (sOCIETE == null)
            {
                return NotFound();
            }
            return View(sOCIETE);
        }

        // POST: societe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Lib,Adresse,Tel")] SOCIETE sOCIETE)
        {
            if (id != sOCIETE.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sOCIETE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SOCIETEExists(sOCIETE.ID))
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
            return View(sOCIETE);
        }

        // GET: societe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sOCIETE = await _context.SOCIETE
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sOCIETE == null)
            {
                return NotFound();
            }

            return View(sOCIETE);
        }

        // POST: societe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sOCIETE = await _context.SOCIETE.FindAsync(id);
            if (sOCIETE != null)
            {
                _context.SOCIETE.Remove(sOCIETE);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SOCIETEExists(int id)
        {
            return _context.SOCIETE.Any(e => e.ID == id);
        }
    }
}
