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
    public class pfeController : Controller
    {
        private readonly SoutenaceContext _context;

        public pfeController(SoutenaceContext context)
        {
            _context = context;
        }

        // GET: pfe
        public async Task<IActionResult> Index()
        {
            var soutenaceContext = _context.PFE.Include(p => p.Encadrant).Include(p => p.Societe);
            return View(await soutenaceContext.ToListAsync());
        }

        // GET: pfe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pFE = await _context.PFE
                .Include(p => p.Encadrant)
                .Include(p => p.Societe)
                .FirstOrDefaultAsync(m => m.PFEID == id);
            if (pFE == null)
            {
                return NotFound();
            }

            return View(pFE);
        }

        // GET: pfe/Create
        public IActionResult Create()
        {
            ViewData["EncadrantID"] = new SelectList(_context.ENSEIGNANT, "ID", "Nom");
            ViewData["SocieteID"] = new SelectList(_context.Set<SOCIETE>(), "ID", "Adresse");
            return View();
        }

        // POST: pfe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PFEID,Titre,Desc,DateD,DateF,EncadrantID,SocieteID")] PFE pFE)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(pFE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EncadrantID"] = new SelectList(_context.ENSEIGNANT, "ID", "Nom", pFE.EncadrantID);
            ViewData["SocieteID"] = new SelectList(_context.Set<SOCIETE>(), "ID", "Adresse", pFE.SocieteID);
            return View(pFE);
        }

        // GET: pfe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pFE = await _context.PFE.FindAsync(id);
            if (pFE == null)
            {
                return NotFound();
            }
            ViewData["EncadrantID"] = new SelectList(_context.ENSEIGNANT, "ID", "Nom", pFE.EncadrantID);
            ViewData["SocieteID"] = new SelectList(_context.Set<SOCIETE>(), "ID", "Adresse", pFE.SocieteID);
            return View(pFE);
        }

        // POST: pfe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PFEID,Titre,Desc,DateD,DateF,EncadrantID,SocieteID")] PFE pFE)
        {
            if (id != pFE.PFEID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(pFE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PFEExists(pFE.PFEID))
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
            ViewData["EncadrantID"] = new SelectList(_context.ENSEIGNANT, "ID", "Nom", pFE.EncadrantID);
            ViewData["SocieteID"] = new SelectList(_context.Set<SOCIETE>(), "ID", "Adresse", pFE.SocieteID);
            return View(pFE);
        }

        // GET: pfe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pFE = await _context.PFE
                .Include(p => p.Encadrant)
                .Include(p => p.Societe)
                .FirstOrDefaultAsync(m => m.PFEID == id);
            if (pFE == null)
            {
                return NotFound();
            }

            return View(pFE);
        }

        // POST: pfe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pFE = await _context.PFE.FindAsync(id);
            if (pFE != null)
            {
                _context.PFE.Remove(pFE);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PFEExists(int id)
        {
            return _context.PFE.Any(e => e.PFEID == id);
        }
    }
}
