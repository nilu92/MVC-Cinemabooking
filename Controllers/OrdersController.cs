using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1ASP.NetCore.BerrasData;
using Lab1ASP.NetCore.Models;
using Lab1ASP.NetCore.Services;

namespace Lab1ASP.NetCore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BerrasDBContext _context;
        private readonly IMovie movie ;
       

        public OrdersController(BerrasDBContext context, IMovie _movie)
        {
            _context = context;
            movie = _movie;
            
        }

        // GET: Orders
        public ActionResult Error()
        {
            return View();
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ordertemp = _context.Orders.SingleOrDefault(O => O.ID == id);
            var order = await _context.Orders
                .Include(o => o.Movie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ordertemp == null)
            {
                return NotFound();
            }

            return View(ordertemp);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["MovieTitle"] = new SelectList(movie.GetAllMovies(), "Title", "Title");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OrderDate,CustomerName,CustomerEmail,AmmountTickets,MovieTitle,MovieID")] Order order)
        {
            if (ModelState.IsValid)
            {
               
                Movie MovieTemp = _context.Movies.SingleOrDefault(M => M.Title == order.MovieTitle);
                int ammount = MovieTemp.SeatsLeft - order.AmmountTickets;
                if(ammount<0)
                {
                      return RedirectToAction(nameof(Error)); 
                        
                }
                MovieTemp.SeatsLeft -= order.AmmountTickets;
                order.MovieID = MovieTemp.ID;
                Order order1 = new Order()
                {
                    //ID = order.ID,
                    OrderDate = DateTime.Now,
                    AmmountTickets = order.AmmountTickets,
                    CustomerName = order.CustomerName,
                    CustomerEmail = order.CustomerEmail,
                    MovieTitle = order.MovieTitle,
                    MovieID = order.MovieID

                };
                    
                _context.Add(order1);
                //_context.Movies.Update(MovieTemp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details),new { id = order1.ID } );
                //return RedirectToAction(nameof(Details), new { id = _order.OrderID });
            }
            return View();
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["MovieID"] = new SelectList(_context.Movies, "ID", "ID", order.MovieID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OrderDate,CustomerName,CustomerEmail,AmmountTickets,MovieTitle,MovieID")] Order order)
        {
            if (id != order.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.ID))
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
            ViewData["MovieID"] = new SelectList(_context.Movies, "ID", "ID", order.MovieID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Movie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
