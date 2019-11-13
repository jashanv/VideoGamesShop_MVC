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
    //Authorised video game controller.
    [Authorize]
    public class VideoGamesController : Controller
    {
        private readonly VideoGamesShop_MVCDataContext _context;

        public VideoGamesController(VideoGamesShop_MVCDataContext context)
        {
            _context = context;
        }

        // GET: VideoGames
        //Gets the video games using a linq query
        public IActionResult Index()
        {
            return View((from videos in _context.VideoGame select videos).ToList());
        }

        // GET: VideoGames/Details/5
        //Gets the video game details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGame = _context.VideoGame
                .FirstOrDefault(m => m.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // GET: VideoGames/Create
        //Gets the create video game form 
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds the video game to database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,HighestScore,PricePerPlay")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoGame);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(videoGame);
        }

        // GET: VideoGames/Edit/5
        //Gets the video game for update using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGame = (from videoGames in _context.VideoGame
                             where videoGames.Id == id
                             select videoGames).FirstOrDefault();
            if (videoGame == null)
            {
                return NotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the video game.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, [Bind("Id,Name,HighestScore,PricePerPlay")] VideoGame videoGame)
        {
            if (id != videoGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoGame);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoGameExists(videoGame.Id))
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
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        //Gets the video game for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGame = _context.VideoGame
                .FirstOrDefault(m => m.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        //Delete the video game. Uses a linq query to select the game.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var videoGame = (from videoGames in _context.VideoGame
                             where videoGames.Id == id
                             select videoGames).FirstOrDefault();
            _context.VideoGame.Remove(videoGame);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the video game exists using a lamda query.
        private bool VideoGameExists(int id)
        {
            return _context.VideoGame.Any(e => e.Id == id);
        }
    }
}
