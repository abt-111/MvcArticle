using Microsoft.AspNetCore.Mvc;
using MvcArticle.Models;
using MvcArticle.Repository;
using System.Diagnostics;

namespace MvcArticle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Article> students = ArticleRepository.GetArticles();

            return View(students);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return View("ErrorTest", "Invalid article ID.");
            }

            Article article = ArticleRepository.GetArticleById(id);

            if (article == null)
            {
                return View("ErrorTest", "Article not found.");
            }

            return View(article);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Title,Content")] Article article)
        {
            if (ModelState.IsValid)
            {
                ArticleRepository.AddArticle(article);
                return RedirectToAction("Index");
            }

            return View(article);
        }

        public IActionResult Edit(int id)
        {
            Article article = ArticleRepository.GetArticleById(id);

            return View(article);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id,Title,Content")] Article article)
        {
            if (ModelState.IsValid)
            {
                ArticleRepository.UpdateArticle(article);
                return RedirectToAction("Index");
            }

            return View(article);
        }

        public IActionResult Delete(int id)
        {
            Article article = ArticleRepository.GetArticleById(id);

            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ArticleRepository.DeleteArticleById(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
