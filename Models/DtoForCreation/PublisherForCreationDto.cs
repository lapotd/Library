namespace Library.Models.ReturnDto
{
    public class PublisherForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public PublisherForCreationDto(int id, string name, string description, List<BookForReturnDto> books)
        {
            Name = name;
            Description = description;
        }
    }
}
