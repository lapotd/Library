namespace Library.Models.ReturnDto
{
    public record PublisherForReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BookForReturnDto> Books { get; set; }

        public PublisherForReturnDto(int id, string name, string description, List<BookForReturnDto> books)
        {
            Id = id;
            Name = name;
            Description = description;
            Books = books;
        }
    }
}
