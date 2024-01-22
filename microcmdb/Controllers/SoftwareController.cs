using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using microcmdb.Data;
using microcmdb.Models;

namespace microcmdb.Controllers
{
    public class SoftwareController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoftwareController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Software
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Software.Include(s => s.Host);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Software/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Software == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .Include(s => s.Host)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // GET: Software/Create
        public IActionResult Create()
        {
            ViewData["HostId"] = new SelectList(_context.Hosts, "Id", "Name");
            return View();
        }

        // POST: Software/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Developer,LicenceType,InstallExecPath,HostId")] Software software)
        {
            if (ModelState.IsValid)
            {
                _context.Add(software);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HostId"] = new SelectList(_context.Hosts, "Id", "Name", software.HostId);
            return View(software);
        }

        // GET: Software/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Software == null)
            {
                return NotFound();
            }

            var software = await _context.Software.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }
            ViewData["HostId"] = new SelectList(_context.Hosts, "Id", "Name", software.HostId);
            return View(software);
        }

        // POST: Software/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Developer,LicenceType,InstallExecPath,HostId")] Software software)
        {
            if (id != software.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(software);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareExists(software.Id))
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
            ViewData["HostId"] = new SelectList(_context.Hosts, "Id", "Name", software.HostId);
            return View(software);
        }

        // GET: Software/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Software == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .Include(s => s.Host)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // POST: Software/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Software == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Software'  is null.");
            }
            var software = await _context.Software.FindAsync(id);
            if (software != null)
            {
                _context.Software.Remove(software);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareExists(int id)
        {
          return (_context.Software?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
