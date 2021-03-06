﻿using Ao3Domain.Models.Data;
using Ao3Domain.Models.Response;
using AutoMapper;

namespace Ao3Functions.Configurations
{
    public class MapperConfigurator : Profile
    {
        public MapperConfigurator()
        {
            CreateMap<WorkIndexing, WorkResponse>().ReverseMap();
            //CreateMap<WorkChapter, WorkChapterResponse>().ReverseMap();
        }
    }
}