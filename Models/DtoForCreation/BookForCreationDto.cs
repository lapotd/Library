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
        public Author? Author { get; set; }
        public int? AuthorId { get; set; }
        public Publisher? Publisher { get; set; }
        public int? PublisherId { get; set; }

        public BookForCreationDto(int id, string title, string description, int? authorId,
            int? publisherId, DateTime published, double price, int stockAmount, Genre genre)
        {
            Title = title;
            Description = description;
            PublishedDate = published;
            Price = price;
            StockAmount = stockAmount;
            Genre = genre;
            AuthorId = authorId;
            PublisherId = publisherId;
           
            //first check if author exists and add author to book
            // second check for publisher and add publisher to book
            //third add book to author
            //fourth add book to publisher
        }
    }
}
