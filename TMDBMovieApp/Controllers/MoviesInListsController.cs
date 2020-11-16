using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMDBMovieApp.Data;
using TMDBMovieApp.Models;

namespace TMDBMovieApp.Controllers
{
    public class MoviesInListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesInListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoviesInLists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MoviesInLists.Include(m => m.IdListNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MoviesInLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesInLists = await _context.MoviesInLists
                .Include(m => m.IdListNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesInLists == null)
            {
                return NotFound();
            }

            return View(moviesInLists);
        }

        // GET: MoviesInLists/Create
        public IActionResult Create()
        {
            ViewData["IdListNavigationId"] = new SelectList(_context.Set<Lists>(), "Id", "Id");
            return View();
        }

        // POST: MoviesInLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMovie,IdListNavigationId")] MoviesInLists moviesInLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesInLists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdListNavigationId"] = new SelectList(_context.Set<Lists>(), "Id", "Id", moviesInLists.IdListNavigationId);
            return View(moviesInLists);
        }

        // GET: MoviesInLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesInLists = await _context.MoviesInLists.FindAsync(id);
            if (moviesInLists == null)
            {
                return NotFound();
            }
            ViewData["IdListNavigationId"] = new SelectList(_context.Set<Lists>(), "Id", "Id", moviesInLists.IdListNavigationId);
            return View(moviesInLists);
        }

        // POST: MoviesInLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdMovie,IdListNavigationId")] MoviesInLists moviesInLists)
        {
            if (id != moviesInLists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviesInLists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesInListsExists(moviesInLists.Id))
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
            ViewData["IdListNavigationId"] = new SelectList(_context.Set<Lists>(), "Id", "Id", moviesInLists.IdListNavigationId);
            return View(moviesInLists);
        }

        // GET: MoviesInLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesInLists = await _context.MoviesInLists
                .Include(m => m.IdListNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesInLists == null)
            {
                return NotFound();
            }

            return View(moviesInLists);
        }

        // POST: MoviesInLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviesInLists = await _context.MoviesInLists.FindAsync(id);
            _context.MoviesInLists.Remove(moviesInLists);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesInListsExists(int id)
        {
            return _context.MoviesInLists.Any(e => e.Id == id);
        }
    }
}
