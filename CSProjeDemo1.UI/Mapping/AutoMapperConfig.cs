﻿using AutoMapper;
using CSProjeDemo1.Entitys;
using CSProjeDemo1.UI.Dtos.BookHistoryDto;
using CSProjeDemo1.UI.Dtos.BookNovelDto;
using CSProjeDemo1.UI.Dtos.LoginDto;
using CSProjeDemo1.UI.Dtos.RegisterDto;

namespace CSProjeDemo1.UI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ListBookHistoryDto, BookHistory>().ReverseMap();
            CreateMap<CreateBookHistoryDto, BookHistory>().ReverseMap();

            CreateMap<CreateBookNovelDto, BookNovel>().ReverseMap();
            CreateMap<ListBookNovelDto, BookNovel>().ReverseMap();

            CreateMap<CreateNewMemberDto, Member>().ReverseMap();
            CreateMap<LoginMemberDto, Member>().ReverseMap();
           
        }
    }
}
