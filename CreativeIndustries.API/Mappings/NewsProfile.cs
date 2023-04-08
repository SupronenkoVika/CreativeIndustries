using AutoMapper;
using CreativeIndustries.API.DXS.CompanyViewModels;
using CreativeIndustries.DS.Entities;

namespace CreativeIndustries.API.Mappings
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<AddNewsViewModel, CompanyNews>().ReverseMap();

        }
    }
}
