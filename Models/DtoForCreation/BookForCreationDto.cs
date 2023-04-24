using Library.Entities;
using Library.Models.Enums;

namespace Library.Models.ReturnDto
{
    public class BookForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockAmount { get; set; }
        public DateTime PublishedDate { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }

        public BookForCreationDto(string title, string description, int authorId,
            int publisherId, DateTime publishedDate, double price, int stockAmount, Genre genre)
        {
            Title = title;
            Description = description;
            PublishedDate = publishedDate;
            Price = price;
            StockAmount = stockAmount;
            Genre = genre;
            AuthorId = authorId;
            PublisherId = publisherId;
        }
    }
}
