using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NexusWebApp.Models;

namespace NexusWebApp.Controllers
{
    public class InforUsersController : Controller
    {
        private readonly NaxusWebAppContext _context;

        public InforUsersController(NaxusWebAppContext context)
        {
            _context = context;
        }

        // GET: InforUsers
        public async Task<IActionResult> Index()
        {
            var naxusWebAppContext = _context.InforUsers.Include(i => i.User);
            return View(await naxusWebAppContext.ToListAsync());
        }

        // GET: InforUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inforUser = await _context.InforUsers
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inforUser == null)
            {
                return NotFound();
            }

            return View(inforUser);
        }

        // GET: InforUsers/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: InforUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phone,UserId,Image,Note")] InforUser inforUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inforUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inforUser.UserId);
            return View(inforUser);
        }

        // GET: InforUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inforUser = await _context.InforUsers.FindAsync(id);
            if (inforUser == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inforUser.UserId);
            return View(inforUser);
        }

        // POST: InforUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phone,UserId,Image,Note")] InforUser inforUser)
        {
            if (id != inforUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inforUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InforUserExists(inforUser.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inforUser.UserId);
            return View(inforUser);
        }

        // GET: InforUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inforUser = await _context.InforUsers
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inforUser == null)
            {
                return NotFound();
            }

            return View(inforUser);
        }

        // POST: InforUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inforUser = await _context.InforUsers.FindAsync(id);
            if (inforUser != null)
            {
                _context.InforUsers.Remove(inforUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InforUserExists(int id)
        {
            return _context.InforUsers.Any(e => e.Id == id);
        }
    }
}
