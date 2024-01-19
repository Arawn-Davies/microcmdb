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
    public class Service_NodeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Service_NodeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Service_Node
        public async Task<IActionResult> Index()
        {
            return View(await _context.NetworkNodes.ToListAsync());
        }

        // GET: Service_Node/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service_Node = await _context.NetworkNodes
                .FirstOrDefaultAsync(m => m.Node_Id == id);
            if (service_Node == null)
            {
                return NotFound();
            }

            return View(service_Node);
        }

        // GET: Service_Node/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service_Node/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Node_Id,Node_Name,Node_CPU_Arch,Node_RAM,Node_Storage,Node_OS_Ver")] Service_Node service_Node)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service_Node);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service_Node);
        }

        // GET: Service_Node/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service_Node = await _context.NetworkNodes.FindAsync(id);
            if (service_Node == null)
            {
                return NotFound();
            }
            return View(service_Node);
        }

        // POST: Service_Node/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Node_Id,Node_Name,Node_CPU_Arch,Node_RAM,Node_Storage,Node_OS_Ver")] Service_Node service_Node)
        {
            if (id != service_Node.Node_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service_Node);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Service_NodeExists(service_Node.Node_Id))
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
            return View(service_Node);
        }

        // GET: Service_Node/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service_Node = await _context.NetworkNodes
                .FirstOrDefaultAsync(m => m.Node_Id == id);
            if (service_Node == null)
            {
                return NotFound();
            }

            return View(service_Node);
        }

        // POST: Service_Node/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service_Node = await _context.NetworkNodes.FindAsync(id);
            if (service_Node != null)
            {
                _context.NetworkNodes.Remove(service_Node);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Service_NodeExists(int id)
        {
            return _context.NetworkNodes.Any(e => e.Node_Id == id);
        }
    }
}
