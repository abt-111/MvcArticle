using System.ComponentModel.DataAnnotations;

namespace MvcArticle.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^([A-Z]|[a-z])[A-Za-z ,.]{2,}$", ErrorMessage = "The title must contain only letters.")]
        public string Title { get; set; }
        [Required]
        [RegularExpression(@"^([A-Z]|[a-z])[A-Za-z ,.]{2,}$", ErrorMessage = "The content must contain only letters.")]
        public string Content { get; set; }
    }
}
