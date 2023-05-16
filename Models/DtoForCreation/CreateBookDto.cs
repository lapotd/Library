using Library.Entities;
using Library.Models.Enums;

namespace Library.Models.ReturnDto
{
    public record BookForCreationDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
        public int StockAmount { get; init; }
        public DateTime PublishedDate { get; init; }
        public Genre Genre { get; init; }
        public int AuthorId { get; init; }
        public int PublisherId { get; init; }

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
