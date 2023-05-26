using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marhaba.Models;
using Microsoft.AspNetCore.Http;

namespace Marhaba.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly MyContext _context;

        public ReservationsController(MyContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
           // var myContext = _context.reservations.Include(r => r.aire).Include(r => r.passager);
            var myContext = _context.reservations.Include(r => r.aire).ToList();
            ViewBag.aires = _context.aires.ToList();

            return View(myContext);
        }

        // GET: Reservations/Details/5
       

        // GET: Reservations/Create
        [Route("Reservations/Create/{AireId}")]
        public IActionResult Create()
        {

           
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Reservations/Create/{AireId}")]
        public async Task<IActionResult> Create([Bind("DateReservation")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                
               
                reservation.PassagerId = (int) HttpContext.Session.GetInt32("Id");

                _context.Add(reservation);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }/*
            ViewData["AireId"] = new SelectList(_context.aires, "Id", "Id", reservation.AireId);
            ViewData["PassagerId"] = new SelectList(_context.Passagers, "Id", "Id", reservation.PassagerId);*/
            return View(reservation);
        }

       /* // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["AireId"] = new SelectList(_context.aires, "Id", "Id", reservation.AireId);
            ViewData["PassagerId"] = new SelectList(_context.Passagers, "Id", "Id", reservation.PassagerId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DateReservation,AireId,PassagerId")] Reservation reservation)
        {
            if (id != reservation.AireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.AireId))
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
            ViewData["AireId"] = new SelectList(_context.aires, "Id", "Id", reservation.AireId);
            ViewData["PassagerId"] = new SelectList(_context.Passagers, "Id", "Id", reservation.PassagerId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.reservations
                .Include(r => r.aire)
                .Include(r => r.passager)
                .FirstOrDefaultAsync(m => m.AireId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.reservations.FindAsync(id);
            _context.reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       */

        private bool ReservationExists(int id)
        {
            return _context.reservations.Any(e => e.AireId == id);
        }
    }
}
