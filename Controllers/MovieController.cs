using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;

namespace Movie.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movie
        public ActionResult Index()
        {
            //var movie = _context.Movies.Include(m => m.GenresType).ToList();
            return View();
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        public ActionResult NewMovie()
        {
            var movie = _context.Movies.ToList();

            return View(movie);
        }
    }
}