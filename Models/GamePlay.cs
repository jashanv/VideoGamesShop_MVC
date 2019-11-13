using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesShop_MVC.Models
{
    //A game play
    public class GamePlay
    {
        //Game play id
        public int Id { get; set; }

        //Player id foriegn key
        public int PlayerId { get; set; }

        //Video game id foriegn key
        public int VideoGameId { get; set; }

        //Player reference 
        public Player Player { get; set; }

        //Video game referene 
        public VideoGame VideoGame { get; set; }

        //Game start time.
        public DateTime StartTime { get; set; }

    }
}
