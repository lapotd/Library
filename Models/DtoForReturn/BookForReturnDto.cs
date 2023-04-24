using Library.Models.Enums;

namespace Library.Models.ReturnDto
{
    public class BookForReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorForReturnDto Author { get; set; }
        public PublisherForReturnDto Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockAmount { get; set; }
        public Genre Genre { get; set; }

        public BookForReturnDto(int id, string title, string description, AuthorForReturnDto author,
            PublisherForReturnDto publisher, DateTime published, double price, int stockAmount, Genre genre)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            Publisher = publisher;
            PublishedDate = published;
            Price = price;
            StockAmount = stockAmount;
            Genre = genre;
        }
    }
}
