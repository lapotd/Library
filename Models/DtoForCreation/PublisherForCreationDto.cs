namespace Library.Models.ReturnDto
{
    public record PublisherForCreationDto
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public PublisherForCreationDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
