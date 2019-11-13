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
    //Game plays controller with authentication.

    [Authorize]
    public class GamePlaysController : Controller
    {
        private readonly VideoGamesShop_MVCDataContext _context;

        public GamePlaysController(VideoGamesShop_MVCDataContext context)
        {
            _context = context;
        }

        // GET: GamePlays
        //Gets all the game plays using a lamda query.
        public IActionResult Index()
        {
            var videoGamesShop_MVCDataContext = _context.GamePlay.Include(g => g.Player).Include(g => g.VideoGame);
            return View(videoGamesShop_MVCDataContext.ToList());
        }

        // GET: GamePlays/Details/5
        //Gets the details of a game play using  a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlay =  _context.GamePlay
                .Include(g => g.Player)
                .Include(g => g.VideoGame)
                .FirstOrDefault(m => m.Id == id);
            if (gamePlay == null)
            {
                return NotFound();
            }

            return View(gamePlay);
        }

        // GET: GamePlays/Create
        //Gets the game play create form.
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Set<Player>(), "Id", "Name");
            ViewData["VideoGameId"] = new SelectList(_context.Set<VideoGame>(), "Id", "Name");
            return View();
        }

        // POST: GamePlays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds  a game play record.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,PlayerId,VideoGameId,StartTime")] GamePlay gamePlay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamePlay);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Set<Player>(), "Id", "Id", gamePlay.PlayerId);
            ViewData["VideoGameId"] = new SelectList(_context.Set<VideoGame>(), "Id", "Id", gamePlay.VideoGameId);
            return View(gamePlay);
        }

        // GET: GamePlays/Edit/5
        //Gets the game play record for edit using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlay = (from gamePlays in _context.GamePlay
                            where gamePlays.Id == id
                            select gamePlays).FirstOrDefault();
            if (gamePlay == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Set<Player>(), "Id", "Name", gamePlay.PlayerId);
            ViewData["VideoGameId"] = new SelectList(_context.Set<VideoGame>(), "Id", "Name", gamePlay.VideoGameId);
            return View(gamePlay);
        }

        // POST: GamePlays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the game play record 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,PlayerId,VideoGameId,StartTime")] GamePlay gamePlay)
        {
            if (id != gamePlay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamePlay);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamePlayExists(gamePlay.Id))
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
            ViewData["PlayerId"] = new SelectList(_context.Set<Player>(), "Id", "Id", gamePlay.PlayerId);
            ViewData["VideoGameId"] = new SelectList(_context.Set<VideoGame>(), "Id", "Id", gamePlay.VideoGameId);
            return View(gamePlay);
        }

        // GET: GamePlays/Delete/5
        //Gets the game play record for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlay = _context.GamePlay
                .Include(g => g.Player)
                .Include(g => g.VideoGame)
                .FirstOrDefault(m => m.Id == id);
            if (gamePlay == null)
            {
                return NotFound();
            }

            return View(gamePlay);
        }

        // POST: GamePlays/Delete/5
        //Deletes the game play record uses a linq query to select.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var gamePlay = (from gamePlays in _context.GamePlay
                            where gamePlays.Id == id
                            select gamePlays).FirstOrDefault();
            _context.GamePlay.Remove(gamePlay);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the game play record exists using a lamda query.
        private bool GamePlayExists(int id)
        {
            return _context.GamePlay.Any(e => e.Id == id);
        }
    }
}
