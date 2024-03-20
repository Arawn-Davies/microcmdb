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
    public class NetworkUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NetworkUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NetworkUsers
        public async Task<IActionResult> Index()
        {
              return _context.NetworkUsers != null ? 
                          View(await _context.NetworkUsers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NetworkUsers'  is null.");
        }

        // GET: NetworkUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NetworkUsers == null)
            {
                return NotFound();
            }

            var networkUser = await _context.NetworkUsers
                .FirstOrDefaultAsync(m => m.NetworkUserID == id);
            if (networkUser == null)
            {
                return NotFound();
            }

            return View(networkUser);
        }

        // GET: NetworkUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NetworkUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NetworkUserID,Username,Email,Firstname,Lastname")] NetworkUser networkUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(networkUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(networkUser);
        }

        // GET: NetworkUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NetworkUsers == null)
            {
                return NotFound();
            }

            var networkUser = await _context.NetworkUsers.FindAsync(id);
            if (networkUser == null)
            {
                return NotFound();
            }
            return View(networkUser);
        }

        // POST: NetworkUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NetworkUserID,Username,Email,Firstname,Lastname")] NetworkUser networkUser)
        {
            if (id != networkUser.NetworkUserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(networkUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetworkUserExists(networkUser.NetworkUserID))
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
            return View(networkUser);
        }

        // GET: NetworkUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NetworkUsers == null)
            {
                return NotFound();
            }

            var networkUser = await _context.NetworkUsers
                .FirstOrDefaultAsync(m => m.NetworkUserID == id);
            if (networkUser == null)
            {
                return NotFound();
            }

            return View(networkUser);
        }

        // POST: NetworkUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NetworkUsers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NetworkUsers'  is null.");
            }
            var networkUser = await _context.NetworkUsers.FindAsync(id);
            if (networkUser != null)
            {
                _context.NetworkUsers.Remove(networkUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NetworkUserExists(int id)
        {
          return (_context.NetworkUsers?.Any(e => e.NetworkUserID == id)).GetValueOrDefault();
        }
    }
}
