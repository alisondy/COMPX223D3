using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMPX223_d3_1285310_overkill.Models;

namespace COMPX223_d3_1285310_overkill.Controllers
{
    public class TrapCatchEventsController : Controller
    {
        private readonly MyTrapAppContext _context;

        public TrapCatchEventsController(MyTrapAppContext context)
        {
            _context = context;
        }

        // GET: TrapCatchEvents
        public async Task<IActionResult> Index()
        {
            var myTrapAppContext = _context.TrapCatchEvent.Include(t => t.Animal).Include(t => t.Manager).Include(t => t.Trap);
            return View(await myTrapAppContext.ToListAsync());
        }

        // GET: TrapCatchEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapCatchEvent = await _context.TrapCatchEvent
                .Include(t => t.Animal)
                .Include(t => t.Manager)
                .Include(t => t.Trap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trapCatchEvent == null)
            {
                return NotFound();
            }

            return View(trapCatchEvent);
        }

        // GET: TrapCatchEvents/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name");
            ViewData["ManagerId"] = new SelectList(_context.Manager, "Id", "Name");
            ViewData["TrapId"] = new SelectList(_context.Trap, "Id", "Name");
            return View();
        }

        // POST: TrapCatchEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrapCatchEventView trapCatchEvent)
        {
            if (ModelState.IsValid)
            {
                IQueryable<Manager> query = _context.Manager.Where(b => b.Name == trapCatchEvent.ManagerName && b.Password == trapCatchEvent.ManagerPassword);
                if (query.Count() == 0)
                {
                    return BadRequest("Bad Username Password Combo");
                }
                var catchEvent = new TrapCatchEvent
                {
                    date = trapCatchEvent.date,
                    AnimalId = trapCatchEvent.AnimalId,
                    ManagerId = query.First().Id,
                    TrapId = trapCatchEvent.TrapId
                };
                _context.Add(catchEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name", trapCatchEvent.AnimalId);
            ViewData["TrapId"] = new SelectList(_context.Trap, "Id", "Name", trapCatchEvent.TrapId);
            return View(trapCatchEvent);
        }

        // GET: TrapCatchEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapCatchEvent = await _context.TrapCatchEvent.FindAsync(id);
            if (trapCatchEvent == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name", trapCatchEvent.AnimalId);
            ViewData["ManagerId"] = new SelectList(_context.Manager, "Id", "Name", trapCatchEvent.ManagerId);
            ViewData["TrapId"] = new SelectList(_context.Trap, "Id", "Name", trapCatchEvent.TrapId);
            return View(trapCatchEvent);
        }

        // POST: TrapCatchEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,date,TrapId,AnimalId,ManagerId")] TrapCatchEvent trapCatchEvent)
        {
            if (id != trapCatchEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trapCatchEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrapCatchEventExists(trapCatchEvent.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name", trapCatchEvent.AnimalId);
            ViewData["ManagerId"] = new SelectList(_context.Manager, "Id", "Name", trapCatchEvent.ManagerId);
            ViewData["TrapId"] = new SelectList(_context.Trap, "Id", "Name", trapCatchEvent.TrapId);
            return View(trapCatchEvent);
        }

        // GET: TrapCatchEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapCatchEvent = await _context.TrapCatchEvent
                .Include(t => t.Animal)
                .Include(t => t.Manager)
                .Include(t => t.Trap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trapCatchEvent == null)
            {
                return NotFound();
            }

            return View(trapCatchEvent);
        }

        // POST: TrapCatchEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trapCatchEvent = await _context.TrapCatchEvent.FindAsync(id);
            _context.TrapCatchEvent.Remove(trapCatchEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrapCatchEventExists(int id)
        {
            return _context.TrapCatchEvent.Any(e => e.Id == id);
        }
    }
}
