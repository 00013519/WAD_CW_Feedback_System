using System.ComponentModel.DataAnnotations.Schema;

namespace FeedbackSystem13519.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string? Username { get; set; }
        public string Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }


    }
}
