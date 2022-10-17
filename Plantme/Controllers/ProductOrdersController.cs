using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plantme.Data;
using Plantme.Models;

namespace Plantme.Controllers
{
    public class ProductOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductOrder.Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductOrder == null)
            {
                return NotFound();
            }

            var productOrder = await _context.ProductOrder
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductOrderID == id);
            if (productOrder == null)
            {
                return NotFound();
            }

            return View(productOrder);
        }

        // GET: ProductOrders/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ProductOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductOrderID,OrderDateTime,OrderQuantity,OrderSubtotal,Id")] ProductOrder productOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", productOrder.Id);
            return View(productOrder);
        }

        // GET: ProductOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductOrder == null)
            {
                return NotFound();
            }

            var productOrder = await _context.ProductOrder.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", productOrder.Id);
            return View(productOrder);
        }

        // POST: ProductOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductOrderID,OrderDateTime,OrderQuantity,OrderSubtotal,Id")] ProductOrder productOrder)
        {
            if (id != productOrder.ProductOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductOrderExists(productOrder.ProductOrderID))
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
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", productOrder.Id);
            return View(productOrder);
        }

        // GET: ProductOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductOrder == null)
            {
                return NotFound();
            }

            var productOrder = await _context.ProductOrder
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductOrderID == id);
            if (productOrder == null)
            {
                return NotFound();
            }

            return View(productOrder);
        }

        // POST: ProductOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductOrder == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductOrder'  is null.");
            }
            var productOrder = await _context.ProductOrder.FindAsync(id);
            if (productOrder != null)
            {
                _context.ProductOrder.Remove(productOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductOrderExists(int id)
        {
          return _context.ProductOrder.Any(e => e.ProductOrderID == id);
        }
    }
}
