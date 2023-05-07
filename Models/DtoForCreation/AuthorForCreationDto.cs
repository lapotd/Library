namespace Library.Models.ReturnDto
{
    public record AuthorForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public AuthorForCreationDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
