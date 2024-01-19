using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using uCMDB.API.Data;
using uCMDB.API.Models;

namespace uCMDB.API.Controllers
{
    public class Service_HostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Service_HostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Service_Host
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hosts.ToListAsync());
        }

        // GET: Service_Host/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service_Host = await _context.Hosts
                .FirstOrDefaultAsync(m => m.Host_ID == id);
            if (service_Host == null)
            {
                return NotFound();
            }

            return View(service_Host);
        }

        // GET: Service_Host/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service_Host/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Host_ID,Host_Name,Host_IP")] Service_Host service_Host)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service_Host);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service_Host);
        }

        // GET: Service_Host/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service_Host = await _context.Hosts.FindAsync(id);
            if (service_Host == null)
            {
                return NotFound();
            }
            return View(service_Host);
        }

        // POST: Service_Host/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Host_ID,Host_Name,Host_IP")] Service_Host service_Host)
        {
            if (id != service_Host.Host_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service_Host);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Service_HostExists(service_Host.Host_ID))
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
            return View(service_Host);
        }

        // GET: Service_Host/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service_Host = await _context.Hosts
                .FirstOrDefaultAsync(m => m.Host_ID == id);
            if (service_Host == null)
            {
                return NotFound();
            }

            return View(service_Host);
        }

        // POST: Service_Host/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service_Host = await _context.Hosts.FindAsync(id);
            if (service_Host != null)
            {
                _context.Hosts.Remove(service_Host);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Service_HostExists(int id)
        {
            return _context.Hosts.Any(e => e.Host_ID == id);
        }
    }
}
