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
    public class LandownersController : Controller
    {
        private readonly MyTrapAppContext _context;

        public LandownersController(MyTrapAppContext context)
        {
            _context = context;
        }

        // GET: Landowners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Landowner.ToListAsync());
        }

        // GET: Landowners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landowner = await _context.Landowner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landowner == null)
            {
                return NotFound();
            }

            return View(landowner);
        }

        // GET: Landowners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Landowners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,City,StreetName,StreetNumber")] Landowner landowner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landowner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(landowner);
        }

        // GET: Landowners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landowner = await _context.Landowner.FindAsync(id);
            if (landowner == null)
            {
                return NotFound();
            }
            return View(landowner);
        }

        // POST: Landowners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,City,StreetName,StreetNumber")] Landowner landowner)
        {
            if (id != landowner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landowner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandownerExists(landowner.Id))
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
            return View(landowner);
        }

        // GET: Landowners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landowner = await _context.Landowner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landowner == null)
            {
                return NotFound();
            }

            return View(landowner);
        }

        // POST: Landowners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landowner = await _context.Landowner.FindAsync(id);
            _context.Landowner.Remove(landowner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandownerExists(int id)
        {
            return _context.Landowner.Any(e => e.Id == id);
        }
    }
}
