﻿using MvcArticle.Models;

namespace MvcArticle.Repository
{
    public static class ArticleRepository
    {
        private static List<Article> _articles = new List<Article>()
        {
                new Article()
                {
                    Id = 1,
                    Title = "Lorem ipsum",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                    "Mauris vulputate dui eu fringilla tempus." +
                    "Proin ultricies velit felis." +
                    "Nam sit amet ornare ligula, vitae volutpat arcu." +
                    "Vestibulum non mauris nunc." +
                    "Sed ac lectus ut dolor porttitor porta." +
                    "In ac turpis sollicitudin, efficitur lacus non, laoreet ipsum." +
                    "Vestibulum fringilla consequat placerat.",
                },
                new Article()
                {
                    Id = 2,
                    Title = "Lorem ipsum",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                    "Mauris vulputate dui eu fringilla tempus." +
                    "Proin ultricies velit felis." +
                    "Nam sit amet ornare ligula, vitae volutpat arcu." +
                    "Vestibulum non mauris nunc." +
                    "Sed ac lectus ut dolor porttitor porta." +
                    "In ac turpis sollicitudin, efficitur lacus non, laoreet ipsum." +
                    "Vestibulum fringilla consequat placerat.",
                },
                new Article()
                {
                    Id = 3,
                    Title = "Lorem ipsum",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                    "Mauris vulputate dui eu fringilla tempus." +
                    "Proin ultricies velit felis." +
                    "Nam sit amet ornare ligula, vitae volutpat arcu." +
                    "Vestibulum non mauris nunc." +
                    "Sed ac lectus ut dolor porttitor porta." +
                    "In ac turpis sollicitudin, efficitur lacus non, laoreet ipsum." +
                    "Vestibulum fringilla consequat placerat.",
                },
        };

        public static Article GetArticleById(int id)
        {
            return _articles.Find(article => article.Id == id);
        }

        public static List<Article> GetArticles()
        {
            return _articles;
        }

        public static void AddArticle(Article article)
        {
            article.Id = GenerateId();
            _articles.Add(article);
        }

        public static void UpdateArticle(Article article)
        {
            Article articleToUpdate = GetArticleById(article.Id);

            articleToUpdate.Title = article.Title;
            articleToUpdate.Content = article.Content;
        }

        public static void DeleteArticleById(int id)
        {
            Article articleToRemove = GetArticleById(id);

            _articles.Remove(articleToRemove);
        }

        public static int GenerateId()
        {
            return _articles.Max(article => article.Id) + 1;
        }
    }
}
