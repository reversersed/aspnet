using aspnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspnet.Controllers
{
    public class HomeController : Controller
    {
        dbModel Context;
        ReviewRepository ReviewRepository;
        MovieRepository MovieRepository;
        public List<Movie> Movies;
        public Movie MovieModel { get; set; } = new Movie();
        public HomeController(dbModel dbContext)
        {
            Context = dbContext;
            ReviewRepository = new ReviewRepository();
            MovieRepository = new MovieRepository();
            Movies = MovieRepository.GetMany();
        }

        public IActionResult Index(int? movie)
        {
            ViewData["Movies"] = Movies;
            ViewData["SelectedMovie"] = MovieModel;
            return View(ReviewRepository.GetReviews(0,10, movie ?? 0));
        }

        public IActionResult Create()
        {
            ViewData["Movies"] = Movies;
            return View();
        }
        public IActionResult Reading(int? id)
        {
            ViewData["Movies"] = Movies;
            if (id == null)
                return View();
            else
                return View(ReviewRepository.LoadReviews(id ?? 1));
        }
        [HttpPost]
        public IActionResult Sorting(int? id)
        {
            return RedirectToAction("Reading", new { @id = id });
        }
        public IActionResult Edit(int id)
        {
            ViewData["Movies"] = Movies;
            if (id > 0)
                return View(ReviewRepository.GetReview(id));
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Review rev)
        {
            ReviewRepository.SetReview(rev);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            ReviewRepository.CreateReview(review);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                ReviewRepository.DeleteReview(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult ChangeMovie(int id)
        {
            var a = Request.Form["currentMovie"].ToString();
            if (id != null && id > 0)
            {
                MovieModel = MovieRepository.Get(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
