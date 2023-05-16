namespace Library.Models.ReturnDto
{
    public record AuthorForCreationDto
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public AuthorForCreationDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
