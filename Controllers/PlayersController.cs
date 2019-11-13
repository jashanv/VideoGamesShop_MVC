using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoGamesShop_MVC.Models;

namespace VideoGamesShop_MVC.Controllers
{
    //Authorised  player controller.
    [Authorize]
    public class PlayersController : Controller
    {
        private readonly VideoGamesShop_MVCDataContext _context;

        public PlayersController(VideoGamesShop_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Players
        //Gets all the players using a linq query.
        public IActionResult Index()
        {
            return View( (from player in _context.Player select player).ToList());
        }

        // GET: Players/Details/5
        //Gets details of a player using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player =  _context.Player
                .FirstOrDefault(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        //Gets the create player form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the player .
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ContactNumber")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Edit/5
        //Gets the player for edit using a linq query
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = (from players in _context.Player
                          where players.Id == id
                          select players).FirstOrDefault();
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates  the player.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ContactNumber")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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
            return View(player);
        }

        // GET: Players/Delete/5
        //Gets the player for delete uses a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = _context.Player
                .FirstOrDefault(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        //Deletes the player uses a linq query to select
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var player = (from players in _context.Player
                          where players.Id == id
                          select players).FirstOrDefault();
            _context.Player.Remove(player);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the player exists using a  lamda query.
        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}
