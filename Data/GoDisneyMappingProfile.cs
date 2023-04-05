using AutoMapper;
using GoDisneyBlog.Data.Entities;
using GoDisneyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDisneyBlog.Data
{
    public class GoDisneyMappingProfile : Profile
    {
        public GoDisneyMappingProfile()
        {
            CreateMap<Card, CardViewModel>()
                //.ForMember(c => c.thisCardId, ex => ex.MapFrom(c => c.Id))
                .ForMember(c => c.cardTitle, ex => ex.MapFrom(c => c.CardTitle))
                .ForMember(c => c.cardCategory, ex => ex.MapFrom(c => c.Category))
                .ForMember(c => c.cardImg, ex => ex.MapFrom(c => c.CardImg))
                .ForMember(c => c.cardImg3, ex => ex.MapFrom(c => c.CardImg3))
                .ForMember(c => c.cardContents, ex => ex.MapFrom(c => c.CardContents))
                .ForMember(c => c.cardIcon, ex => ex.MapFrom(c => c.CardIcon))
                .ForMember(c => c.cardLink, ex => ex.MapFrom(c => c.CardLink))
                .ForMember(c => c.cardLinkName, ex => ex.MapFrom(c => c.CardLinkName))
                .ReverseMap();

            CreateMap<CardContent, CardContentsViewModel>()
                .ForMember(c => c.paraOne, ex => ex.MapFrom(c => c.ParaOne))
                .ForMember(c => c.paraTwo, ex => ex.MapFrom(c => c.ParaTwo))
                .ForMember(c => c.paraThree, ex => ex.MapFrom(c => c.ParaThree))
                .ForMember(c => c.paraFour, ex => ex.MapFrom(c => c.ParaFour))
                .ReverseMap();
        }
    }
}
