﻿namespace Library.Models.ReturnDto
{
    public record AuthorForReturnDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public List<BookForReturnDto?>? Books { get; init; }

        public AuthorForReturnDto(int id, string name, string description, List<BookForReturnDto?>? books)
        {
            Id = id;
            Name = name;
            Description = description;
            Books = books;
        }
    }
}
