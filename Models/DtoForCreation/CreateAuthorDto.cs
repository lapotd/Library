namespace Library.Models.ReturnDto
{
    public record CreateAuthorDto
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public CreateAuthorDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
