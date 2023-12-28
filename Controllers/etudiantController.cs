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
    public class etudiantController : Controller
    {
        private readonly SoutenaceContext _context;

        public etudiantController(SoutenaceContext context)
        {
            _context = context;
        }

        // GET: etudiant
        public async Task<IActionResult> Index()
        {
            return View(await _context.ETUDIANT.ToListAsync());
        }

        // GET: etudiant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eTUDIANT = await _context.ETUDIANT
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eTUDIANT == null)
            {
                return NotFound();
            }

            return View(eTUDIANT);
        }

        // GET: etudiant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: etudiant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom,Prenom,DateNaiss")] ETUDIANT eTUDIANT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eTUDIANT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eTUDIANT);
        }

        // GET: etudiant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eTUDIANT = await _context.ETUDIANT.FindAsync(id);
            if (eTUDIANT == null)
            {
                return NotFound();
            }
            return View(eTUDIANT);
        }

        // POST: etudiant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nom,Prenom,DateNaiss")] ETUDIANT eTUDIANT)
        {
            if (id != eTUDIANT.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eTUDIANT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ETUDIANTExists(eTUDIANT.ID))
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
            return View(eTUDIANT);
        }

        // GET: etudiant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eTUDIANT = await _context.ETUDIANT
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eTUDIANT == null)
            {
                return NotFound();
            }

            return View(eTUDIANT);
        }

        // POST: etudiant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eTUDIANT = await _context.ETUDIANT.FindAsync(id);
            if (eTUDIANT != null)
            {
                _context.ETUDIANT.Remove(eTUDIANT);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ETUDIANTExists(int id)
        {
            return _context.ETUDIANT.Any(e => e.ID == id);
        }
    }
}
