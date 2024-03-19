using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using microcmdb.Web.Data;
using microcmdb.Web.Models;

namespace microcmdb.web.Controllers
{
    public class ConfigItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConfigItems
        public async Task<IActionResult> Index()
        {
              return _context.ConfigItems != null ? 
                          View(await _context.ConfigItems.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ConfigItems'  is null.");
        }

        // GET: ConfigItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ConfigItems == null)
            {
                return NotFound();
            }

            var configItem = await _context.ConfigItems
                .FirstOrDefaultAsync(m => m.ConfigItemID == id);
            if (configItem == null)
            {
                return NotFound();
            }

            return View(configItem);
        }

        // GET: ConfigItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConfigItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfigItemID,Name,PurchaseDate,LastUpdated,Notes,DeployLoc")] ConfigItem configItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configItem);
        }

        // GET: ConfigItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ConfigItems == null)
            {
                return NotFound();
            }

            var configItem = await _context.ConfigItems.FindAsync(id);
            if (configItem == null)
            {
                return NotFound();
            }
            return View(configItem);
        }

        // POST: ConfigItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfigItemID,Name,PurchaseDate,LastUpdated,Notes,DeployLoc")] ConfigItem configItem)
        {
            if (id != configItem.ConfigItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigItemExists(configItem.ConfigItemID))
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
            return View(configItem);
        }

        // GET: ConfigItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConfigItems == null)
            {
                return NotFound();
            }

            var configItem = await _context.ConfigItems
                .FirstOrDefaultAsync(m => m.ConfigItemID == id);
            if (configItem == null)
            {
                return NotFound();
            }

            return View(configItem);
        }

        // POST: ConfigItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ConfigItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ConfigItems'  is null.");
            }
            var configItem = await _context.ConfigItems.FindAsync(id);
            if (configItem != null)
            {
                _context.ConfigItems.Remove(configItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigItemExists(int id)
        {
          return (_context.ConfigItems?.Any(e => e.ConfigItemID == id)).GetValueOrDefault();
        }
    }
}
