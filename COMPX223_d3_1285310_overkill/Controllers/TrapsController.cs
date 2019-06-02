using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMPX223_d3_1285310_overkill.Models;

namespace COMPX223_d3_1285310_overkill.Controllers
{
    public class TrapsController : Controller
    {
        private readonly MyTrapAppContext _context;

        public TrapsController(MyTrapAppContext context)
        {
            _context = context;
        }

        // GET: Traps
        public async Task<IActionResult> Index()
        {
            var myTrapAppContext = _context.Trap.Include(t => t.TrapType).Include(t => t.TrapUser);
            return View(await myTrapAppContext.ToListAsync());
        }

        // GET: Traps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trap = await _context.Trap
                .Include(t => t.TrapType)
                .Include(t => t.TrapUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trap == null)
            {
                return NotFound();
            }

            return View(trap);
        }

        // GET: Traps/Create
        public IActionResult Create()
        {
            ViewData["TrapTypeId"] = new SelectList(_context.TrapType, "Id", "Id");
            ViewData["TrapUserId"] = new SelectList(_context.TrapUser, "Id", "Id");
            return View();
        }

        // POST: Traps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RegistrationNumber,TrapTypeId,TrapUserId")] Trap trap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrapTypeId"] = new SelectList(_context.TrapType, "Id", "Id", trap.TrapTypeId);
            ViewData["TrapUserId"] = new SelectList(_context.TrapUser, "Id", "Id", trap.TrapUserId);
            return View(trap);
        }

        // GET: Traps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trap = await _context.Trap.FindAsync(id);
            if (trap == null)
            {
                return NotFound();
            }
            ViewData["TrapTypeId"] = new SelectList(_context.TrapType, "Id", "Id", trap.TrapTypeId);
            ViewData["TrapUserId"] = new SelectList(_context.TrapUser, "Id", "Id", trap.TrapUserId);
            return View(trap);
        }

        // POST: Traps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RegistrationNumber,TrapTypeId,TrapUserId")] Trap trap)
        {
            if (id != trap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrapExists(trap.Id))
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
            ViewData["TrapTypeId"] = new SelectList(_context.TrapType, "Id", "Id", trap.TrapTypeId);
            ViewData["TrapUserId"] = new SelectList(_context.TrapUser, "Id", "Id", trap.TrapUserId);
            return View(trap);
        }

        // GET: Traps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trap = await _context.Trap
                .Include(t => t.TrapType)
                .Include(t => t.TrapUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trap == null)
            {
                return NotFound();
            }

            return View(trap);
        }

        // POST: Traps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trap = await _context.Trap.FindAsync(id);
            _context.Trap.Remove(trap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrapExists(int id)
        {
            return _context.Trap.Any(e => e.Id == id);
        }
    }
}
