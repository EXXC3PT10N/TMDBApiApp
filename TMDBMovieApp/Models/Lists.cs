using System;
using System.Collections.Generic;

namespace TMDBMovieApp.Models
{
    public partial class Lists
    {
        public Lists()
        {
            MoviesInLists = new HashSet<MoviesInLists>();
        }

        public int Id { get; set; }
        public string OwnerId { get; set; }

        public virtual AspNetUsers Owner { get; set; }
        public virtual ICollection<MoviesInLists> MoviesInLists { get; set; }
    }
}
