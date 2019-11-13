using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoGamesShop_MVC.Models;

namespace VideoGamesShop_MVC.Models
{
    //Connects the database and the model classes.
    public class VideoGamesShop_MVCDataContext : DbContext
    {
        public VideoGamesShop_MVCDataContext (DbContextOptions<VideoGamesShop_MVCDataContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGamesShop_MVC.Models.GamePlay> GamePlay { get; set; }

        public DbSet<VideoGamesShop_MVC.Models.Player> Player { get; set; }

        public DbSet<VideoGamesShop_MVC.Models.VideoGame> VideoGame { get; set; }
    }
}
