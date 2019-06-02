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
    public class TrapTypesController : Controller
    {
        private readonly MyTrapAppContext _context;

        public TrapTypesController(MyTrapAppContext context)
        {
            _context = context;
        }

        // GET: TrapTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrapType.ToListAsync());
        }

        // GET: TrapTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapType = await _context.TrapType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trapType == null)
            {
                return NotFound();
            }

            return View(trapType);
        }

        // GET: TrapTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrapTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] TrapType trapType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trapType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trapType);
        }

        // GET: TrapTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapType = await _context.TrapType.FindAsync(id);
            if (trapType == null)
            {
                return NotFound();
            }
            return View(trapType);
        }

        // POST: TrapTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] TrapType trapType)
        {
            if (id != trapType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trapType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrapTypeExists(trapType.Id))
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
            return View(trapType);
        }

        // GET: TrapTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapType = await _context.TrapType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trapType == null)
            {
                return NotFound();
            }

            return View(trapType);
        }

        // POST: TrapTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trapType = await _context.TrapType.FindAsync(id);
            _context.TrapType.Remove(trapType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrapTypeExists(int id)
        {
            return _context.TrapType.Any(e => e.Id == id);
        }
    }
}
