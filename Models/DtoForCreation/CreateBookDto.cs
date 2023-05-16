using Library.Entities;

namespace Library.Models.ReturnDto
{
    public record CreateBookDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
        public int StockAmount { get; init; }
        public DateTime PublishedDate { get; init; }
        public int AuthorId { get; init; }
        public int PublisherId { get; init; }

        public CreateBookDto(string title, string description, int authorId,
            int publisherId, DateTime publishedDate, double price, int stockAmount)
        {
            Title = title;
            Description = description;
            PublishedDate = publishedDate;
            Price = price;
            StockAmount = stockAmount;
            AuthorId = authorId;
            PublisherId = publisherId;
        }
    }
}
