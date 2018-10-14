using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            this._context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name= "Hard to Die" };
            var customerList = new List<Customer>() {
                new Customer(){ Name="fulano" },
                new Customer(){ Name="perengano" }
            };
            var viewModel = new ViewModel.RandomMovieViewModel(){
                Movie = movie,
                Customer = customerList
            };
            return View(viewModel);
        }

        private ViewModel.MoviesViewModel GetMovies() {
            return new ViewModel.MoviesViewModel() {
                Movies = this._context.Movies.ToList()
            };
        }

        public ActionResult Index(/*int? pageIndex, string sortBy*/) {          

            return View(GetMovies());
            //if (!pageIndex.HasValue)
            //{
            //    pageIndex = 1;
            //}
            //if (string.IsNullOrWhiteSpace(sortBy)) {
            //    sortBy = "Name";
            //}
            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month) {

            return Content(year + "/" + month);
        }

        public ActionResult New() {
            var viewModel = new MovieFormViewModel() {
                Genre = this._context.Genre.ToList()
            };
            return View("MovieForm",viewModel);          
        }
        public ActionResult Edit(int id)
        {
            var movie = this._context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = this._context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMovie(Movie movie)
        {
            if (!ModelState.IsValid) {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = this._context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                this._context.Movies.Add(movie);
            } else {
                var movieInDb = this._context.Movies.FirstOrDefault(m => m.Id == movie.Id);
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            try{
                this._context.SaveChanges();
            } catch(SqlException e) {
                Console.Write(e);
            }

            
            return RedirectToAction("Index", "Movies");
        }
    }

}