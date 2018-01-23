using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HCP_Demo.Data;
using HCP_Demo.Models;

namespace HCP_Demo.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly CustomerContext _context;

        public FavoritesController(CustomerContext context)
        {
            _context = context;
        }

        // GET: Favorites

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerContext = _context.Favorites.Include(f => f.Customer).Include(f => f.Product);

            var customer = customerContext.Where(s => s.CustomerID.Equals(id));
            if (customer == null)
            {
                return NotFound();
            }

            ViewBag.ID = id;
            return View(await customer.ToListAsync());
        }

        // GET: Favorites/Create
        public IActionResult Create(int? id)
        {

            ViewBag.ID = id;
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Title");
            return View();
        }




        // POST: Favorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,CustomerID")] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = favorite.CustomerID });
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", favorite.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Title", favorite.ProductID);
            return View(favorite);
        }

        
        // GET: Favorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorites
                .Include(f => f.Customer)
                .Include(f => f.Product)
                .SingleOrDefaultAsync(m => m.FavoriteID == id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorite = await _context.Favorites.SingleOrDefaultAsync(m => m.FavoriteID == id);
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = favorite.CustomerID } );
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorites.Any(e => e.FavoriteID == id);
        }
    }
}
