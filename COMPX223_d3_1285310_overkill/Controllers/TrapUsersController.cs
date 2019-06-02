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
    public class TrapUsersController : Controller
    {
        private readonly MyTrapAppContext _context;

        public TrapUsersController(MyTrapAppContext context)
        {
            _context = context;
        }

        // GET: TrapUsers
        public async Task<IActionResult> Index()
        {
            var myTrapAppContext = _context.TrapUser.Include(t => t.Landowner);
            return View(await myTrapAppContext.ToListAsync());
        }

        // GET: TrapUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapUser = await _context.TrapUser
                .Include(t => t.Landowner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trapUser == null)
            {
                return NotFound();
            }

            return View(trapUser);
        }

        // GET: TrapUsers/Create
        public IActionResult Create()
        {
            ViewData["LandownerId"] = new SelectList(_context.Landowner, "Id", "Id");
            return View();
        }

        // POST: TrapUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateRegistered,LandownerId")] TrapUser trapUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trapUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LandownerId"] = new SelectList(_context.Landowner, "Id", "Id", trapUser.LandownerId);
            return View(trapUser);
        }

        // GET: TrapUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapUser = await _context.TrapUser.FindAsync(id);
            if (trapUser == null)
            {
                return NotFound();
            }
            ViewData["LandownerId"] = new SelectList(_context.Landowner, "Id", "Id", trapUser.LandownerId);
            return View(trapUser);
        }

        // POST: TrapUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateRegistered,LandownerId")] TrapUser trapUser)
        {
            if (id != trapUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trapUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrapUserExists(trapUser.Id))
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
            ViewData["LandownerId"] = new SelectList(_context.Landowner, "Id", "Id", trapUser.LandownerId);
            return View(trapUser);
        }

        // GET: TrapUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapUser = await _context.TrapUser
                .Include(t => t.Landowner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trapUser == null)
            {
                return NotFound();
            }

            return View(trapUser);
        }

        // POST: TrapUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trapUser = await _context.TrapUser.FindAsync(id);
            _context.TrapUser.Remove(trapUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrapUserExists(int id)
        {
            return _context.TrapUser.Any(e => e.Id == id);
        }
    }
}
