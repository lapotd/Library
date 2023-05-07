namespace Library.Models.ReturnDto
{
    public record PublisherForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public PublisherForCreationDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
