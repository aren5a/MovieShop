using MovieShop.Models;
using MovieShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {
        MyDbContext _context;
        public MoviesController()
        {
            _context = new MyDbContext();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (movies != null) return View(movies);
            return HttpNotFound();
        }

        [Route("movies/index/{id}")]
        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(m=> m.Genre).FirstOrDefault(m => m.Id == id);
            if (movie != null) return View(movie);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now.Date;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                if (movieInDb == null) return HttpNotFound();
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.InStock = movie.InStock;
                movieInDb.GenresId = movie.GenresId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.First(m => m.Id == id);
            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}