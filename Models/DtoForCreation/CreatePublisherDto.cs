namespace Library.Models.ReturnDto
{
    public record CreatePublisherDto
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public CreatePublisherDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
