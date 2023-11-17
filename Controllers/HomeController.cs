using aspnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspnet.Controllers
{
    public class HomeController : Controller
    {
        dbModel Context;
        ReviewRepository ReviewRepository;
        public HomeController(dbModel dbContext)
        {
            Context = dbContext;
            ReviewRepository = new ReviewRepository();
        }

        public IActionResult Index()
        {
            return View(ReviewRepository.GetReviews(0,10));
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Reading(int? id)
        {
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
            if (id > 0)
                return View(ReviewRepository.GetReview(id));
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Review rev)
        {
            ReviewRepository.SetReviewText(rev.Id, rev.Text ?? string.Empty);
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
    }
}
