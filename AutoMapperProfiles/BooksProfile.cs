﻿using AutoMapper;
using Library.Entities;
using Library.Models.ReturnDto;

namespace Library.AutoMapperProfiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, ReturnBookDto>();
        }
    }
}
