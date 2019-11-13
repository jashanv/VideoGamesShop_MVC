using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesShop_MVC.Models
{
    // A Video game
    public class VideoGame
    {
        //Video game id
        public int Id{get; set;}

        //Video game name.
        public string Name { get; set; }

        //video game highest score .
        public int HighestScore { get; set; }

       //Price per play for a game.
        public decimal PricePerPlay { get; set; }

    }
}
