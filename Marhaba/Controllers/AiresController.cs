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
    public class AiresController : Controller
    {
        private readonly MyContext _context;

        public AiresController(MyContext context)
        {
            _context = context;
        }

        // GET: Aires
        public async Task<IActionResult> Index()
        {
            //var myContext = _context.aires.Include(a => a.ville).Include(r=>r.reservations);
            var aires = _context.aires.Include(a => a.ville).Include(r => r.reservations).ToList();
            foreach(Aire aire in aires)
            {
                int total = 0;
                foreach(Reservation reservation in aire.reservations)
                {
                    total = total + 1;
                }
                aire.TotalReservations = total;
            }
                
            return View(aires);
        }

        // GET: Aires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aire = await _context.aires
                .Include(a => a.ville)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aire == null)
            {
                return NotFound();
            }

            return View(aire);
        }

        // GET: Aires/Create
        public IActionResult Create()
        {
            ViewData["VilleLibelle"] = new SelectList(_context.villes, "Libelle", "Libelle");
            return View();
        }

        // POST: Aires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,VilleId")] Aire aire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VilleId"] = new SelectList(_context.villes, "Id", "Id", aire.VilleId);
            return View(aire);
        }

        // GET: Aires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aire = await _context.aires.FindAsync(id);
            if (aire == null)
            {
                return NotFound();
            }
            ViewData["VilleLibelle"] = new SelectList(_context.villes, "Id", "Libelle", aire.VilleId);
            return View(aire);
        }

        // POST: Aires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,VilleId")] Aire aire)
        {
            if (id != aire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AireExists(aire.Id))
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
            ViewData["VilleId"] = new SelectList(_context.villes, "Id", "Id", aire.VilleId);
            return View(aire);
        }

        // GET: Aires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aire = await _context.aires
                .Include(a => a.ville)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aire == null)
            {
                return NotFound();
            }

            return View(aire);
        }

        // POST: Aires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aire = await _context.aires.FindAsync(id);
            _context.aires.Remove(aire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AireExists(int id)
        {
            return _context.aires.Any(e => e.Id == id);
        }
    }
}
