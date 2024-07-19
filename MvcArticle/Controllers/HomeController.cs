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
            Article article = ArticleRepository.GetArticleById(id);

            return View(article);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Title,Content")] Article article)
        {
            ArticleRepository.AddArticle(article);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Article article = ArticleRepository.GetArticleById(id);

            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Title,Content")] Article article)
        {
            ArticleRepository.UpdateArticle(article);

            return RedirectToAction("Index");
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
