using Library.Models.Enums;

namespace Library.Models.ReturnDto
{
    public class BookForReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockAmount { get; set; }
        public Genre Genre { get; set; }

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
