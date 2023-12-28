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
    public class pfeetudiantController : Controller
    {
        private readonly SoutenaceContext _context;

        public pfeetudiantController(SoutenaceContext context)
        {
            _context = context;
        }

        // GET: pfeetudiant
        public async Task<IActionResult> Index()
        {
            var soutenaceContext = _context.PFE_ETUDIANT.Include(p => p.Etudiant).Include(p => p.PFE);
            return View(await soutenaceContext.ToListAsync());
        }

        // GET: pfeetudiant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pFE_ETUDIANT = await _context.PFE_ETUDIANT
                .Include(p => p.Etudiant)
                .Include(p => p.PFE)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pFE_ETUDIANT == null)
            {
                return NotFound();
            }

            return View(pFE_ETUDIANT);
        }

        // GET: pfeetudiant/Create
        public IActionResult Create()
        {
            ViewData["EtudiantID"] = new SelectList(_context.ETUDIANT, "ID", "Nom");
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "Desc");
            return View();
        }

        // POST: pfeetudiant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PFEID,EtudiantID")] PFE_ETUDIANT pFE_ETUDIANT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pFE_ETUDIANT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantID"] = new SelectList(_context.ETUDIANT, "ID", "Nom", pFE_ETUDIANT.EtudiantID);
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "Desc", pFE_ETUDIANT.PFEID);
            return View(pFE_ETUDIANT);
        }

        // GET: pfeetudiant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pFE_ETUDIANT = await _context.PFE_ETUDIANT.FindAsync(id);
            if (pFE_ETUDIANT == null)
            {
                return NotFound();
            }
            ViewData["EtudiantID"] = new SelectList(_context.ETUDIANT, "ID", "Nom", pFE_ETUDIANT.EtudiantID);
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "Desc", pFE_ETUDIANT.PFEID);
            return View(pFE_ETUDIANT);
        }

        // POST: pfeetudiant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PFEID,EtudiantID")] PFE_ETUDIANT pFE_ETUDIANT)
        {
            if (id != pFE_ETUDIANT.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pFE_ETUDIANT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PFE_ETUDIANTExists(pFE_ETUDIANT.ID))
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
            ViewData["EtudiantID"] = new SelectList(_context.ETUDIANT, "ID", "Nom", pFE_ETUDIANT.EtudiantID);
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "Desc", pFE_ETUDIANT.PFEID);
            return View(pFE_ETUDIANT);
        }

        // GET: pfeetudiant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pFE_ETUDIANT = await _context.PFE_ETUDIANT
                .Include(p => p.Etudiant)
                .Include(p => p.PFE)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pFE_ETUDIANT == null)
            {
                return NotFound();
            }

            return View(pFE_ETUDIANT);
        }

        // POST: pfeetudiant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pFE_ETUDIANT = await _context.PFE_ETUDIANT.FindAsync(id);
            if (pFE_ETUDIANT != null)
            {
                _context.PFE_ETUDIANT.Remove(pFE_ETUDIANT);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PFE_ETUDIANTExists(int id)
        {
            return _context.PFE_ETUDIANT.Any(e => e.ID == id);
        }
    }
}
