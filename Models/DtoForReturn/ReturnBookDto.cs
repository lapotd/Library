using Library.Models.Enums;

namespace Library.Models.ReturnDto
{
    public record BookForReturnDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public int AuthorId { get; init; }
        public int PublisherId { get; init; }
        public DateTime PublishedDate { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
        public int StockAmount { get; init; }
        public Genre Genre { get; init; }

        public BookForReturnDto(int id, string title, string description, int authorId,
            int publisherId, DateTime publishedDate, double price, int stockAmount, Genre genre)
        {
            Id = id;
            Title = title;
            Description = description;
            AuthorId = authorId;
            PublisherId = publisherId;
            PublishedDate = publishedDate;
            Price = price;
            StockAmount = stockAmount;
            Genre = genre;
        }
    }
}
