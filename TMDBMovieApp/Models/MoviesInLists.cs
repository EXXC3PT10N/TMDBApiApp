using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDBMovieApp.Models
{
    public class MoviesInLists
    {
        public int Id { get; set; }
        public int IdMovie { get; set; }
        public int? IdListNavigationId { get; set; }

        public virtual Lists IdListNavigation { get; set; }
    }
}
