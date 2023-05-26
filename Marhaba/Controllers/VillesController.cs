using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marhaba.Models;

namespace Marhaba.Controllers
{
    public class VillesController : Controller
    {
        private readonly MyContext _context;

        public VillesController(MyContext context)
        {
            _context = context;
        }

        // GET: Villes
        public async Task<IActionResult> Index()
        {
            List<Ville> villes = _context.villes.Include(a => a.aires).ToList();
            foreach(Ville ville in villes)
            {
                int total = 0;
                foreach(Aire aire in ville.aires)
                {
                    total = total + 1;
                }
                ville.TotalAire = total;
            }
            return View(villes);
        }

        // GET: Villes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ville = await _context.villes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ville == null)
            {
                return NotFound();
            }

            return View(ville);
        }

        // GET: Villes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Villes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Libelle")] Ville ville)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ville);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ville);
        }

        // GET: Villes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ville = await _context.villes.FindAsync(id);
            if (ville == null)
            {
                return NotFound();
            }
            return View(ville);
        }

        // POST: Villes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Libelle")] Ville ville)
        {
            if (id != ville.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ville);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VilleExists(ville.Id))
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
            return View(ville);
        }

        // GET: Villes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ville = await _context.villes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ville == null)
            {
                return NotFound();
            }

            return View(ville);
        }

        // POST: Villes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ville = await _context.villes.FindAsync(id);
            _context.villes.Remove(ville);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VilleExists(int id)
        {
            return _context.villes.Any(e => e.Id == id);
        }
    }
}
