using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShop.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genres Genre { get; set; }
        public int GenresId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int InStock { get; set; }
    }


}