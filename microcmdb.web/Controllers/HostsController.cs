using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using microcmdb.Web.Data;
using microcmdb.Web.Models;

namespace microcmdb.Web.Controllers
{
    public class HostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hosts.Include(h => h.Node);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hosts == null)
            {
                return NotFound();
            }

            var host = await _context.Hosts
                .Include(h => h.Node)
                .FirstOrDefaultAsync(m => m.HostID == id);
            if (host == null)
            {
                return NotFound();
            }

            return View(host);
        }

        // GET: Hosts/Create
        public IActionResult Create()
        {
            ViewData["NodeId"] = new SelectList(_context.Nodes, "NodeID", "CPU_Arch");
            return View();
        }

        // POST: Hosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HostID,Name,NodeId")] Web.Models.Host host)
        {
            if (ModelState.IsValid)
            {
                _context.Add(host);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NodeId"] = new SelectList(_context.Nodes, "NodeID", "CPU_Arch", host.NodeId);
            return View(host);
        }

        // GET: Hosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hosts == null)
            {
                return NotFound();
            }

            var host = await _context.Hosts.FindAsync(id);
            if (host == null)
            {
                return NotFound();
            }
            ViewData["NodeId"] = new SelectList(_context.Nodes, "NodeID", "CPU_Arch", host.NodeId);
            return View(host);
        }

        // POST: Hosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HostID,Name,NodeId")] Host host)
        {
            if (id != host.HostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(host);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostExists(host.HostID))
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
            ViewData["NodeId"] = new SelectList(_context.Nodes, "NodeID", "CPU_Arch", host.NodeId);
            return View(host);
        }

        // GET: Hosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hosts == null)
            {
                return NotFound();
            }

            var host = await _context.Hosts
                .Include(h => h.Node)
                .FirstOrDefaultAsync(m => m.HostID == id);
            if (host == null)
            {
                return NotFound();
            }

            return View(host);
        }

        // POST: Hosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hosts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Hosts'  is null.");
            }
            var host = await _context.Hosts.FindAsync(id);
            if (host != null)
            {
                _context.Hosts.Remove(host);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostExists(int id)
        {
          return (_context.Hosts?.Any(e => e.HostID == id)).GetValueOrDefault();
        }
    }
}
