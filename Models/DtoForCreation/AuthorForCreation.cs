namespace Library.Models.ReturnDto
{
    public class AuthorForCreation
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public AuthorForCreation(int id, string name, string description, List<BookForReturnDto> books)
        {
            Name = name;
            Description = description;
        }
    }
}
