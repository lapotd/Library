
namespace Library.Models.ReturnDto
{
    public record ReturnBookDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public int AuthorId { get; init; }
        public int PublisherId { get; init; }
        public DateTime PublishedDate { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
        public int StockAmount { get; init; }

        public ReturnBookDto(int id, string title, string description, int authorId,
            int publisherId, DateTime publishedDate, double price, int stockAmount)
        {
            Id = id;
            Title = title;
            Description = description;
            AuthorId = authorId;
            PublisherId = publisherId;
            PublishedDate = publishedDate;
            Price = price;
            StockAmount = stockAmount;
        }
    }
}
