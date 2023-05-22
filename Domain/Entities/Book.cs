using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int StockAmount { get; set; }

        [Required]
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
        public int AuthorId { get; set; }

        [Required]
        [ForeignKey("PublisherId")]
        public Publisher? Publisher { get; set; }
        public int PublisherId { get; set; }

        public string? Description { get; set; }
        public DateTime PublishedDate { get; set; }

        public Book(string title)
        {
            Title = title;
        }
    }
}
