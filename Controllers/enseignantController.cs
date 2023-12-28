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
    public class enseignantController : Controller
    {
        private readonly SoutenaceContext _context;

        public enseignantController(SoutenaceContext context)
        {
            _context = context;
        }

        // GET: enseignant
        public async Task<IActionResult> Index()
        {
            return View(await _context.ENSEIGNANT.ToListAsync());
        }

        // GET: enseignant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eNSEIGNANT = await _context.ENSEIGNANT
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eNSEIGNANT == null)
            {
                return NotFound();
            }

            return View(eNSEIGNANT);
        }

        // GET: enseignant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: enseignant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom,Prenom")] ENSEIGNANT eNSEIGNANT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eNSEIGNANT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eNSEIGNANT);
        }

        // GET: enseignant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eNSEIGNANT = await _context.ENSEIGNANT.FindAsync(id);
            if (eNSEIGNANT == null)
            {
                return NotFound();
            }
            return View(eNSEIGNANT);
        }

        // POST: enseignant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nom,Prenom")] ENSEIGNANT eNSEIGNANT)
        {
            if (id != eNSEIGNANT.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eNSEIGNANT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ENSEIGNANTExists(eNSEIGNANT.ID))
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
            return View(eNSEIGNANT);
        }

        // GET: enseignant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eNSEIGNANT = await _context.ENSEIGNANT
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eNSEIGNANT == null)
            {
                return NotFound();
            }

            return View(eNSEIGNANT);
        }

        // POST: enseignant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eNSEIGNANT = await _context.ENSEIGNANT.FindAsync(id);
            if (eNSEIGNANT != null)
            {
                _context.ENSEIGNANT.Remove(eNSEIGNANT);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ENSEIGNANTExists(int id)
        {
            return _context.ENSEIGNANT.Any(e => e.ID == id);
        }
    }
}
