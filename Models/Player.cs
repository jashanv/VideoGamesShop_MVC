using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesShop_MVC.Models
{
    //A player 
    public class Player
    {
        //player id
        public int Id { get; set; }

        //Name of the player.
        public string Name { get; set; }

        //player contact  number
        public string ContactNumber { get; set; }

    }
}
