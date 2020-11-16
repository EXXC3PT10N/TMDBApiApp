using System;
using System.Collections.Generic;

namespace TMDBMovieApp.Models
{
    public partial class MoviesInLists
    {
        public int Id { get; set; }
        public int IdMovie { get; set; }
        public int? IdListNavigationId { get; set; }

        public virtual Lists IdListNavigation { get; set; }
    }
}
