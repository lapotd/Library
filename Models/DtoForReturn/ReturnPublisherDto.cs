namespace Library.Models.ReturnDto
{
    public record ReturnPublisherDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public List<ReturnBookDto> Books { get; init; }

        public ReturnPublisherDto(int id, string name, string description, List<ReturnBookDto> books)
        {
            Id = id;
            Name = name;
            Description = description;
            Books = books;
        }
    }
}
