using AutoMapper;
using CreativeIndustries.API.DXS.CompanyViewModels;
using CreativeIndustries.DS.Entities;

namespace CreativeIndustries.API.Mappings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<AddEventViewModel, CompanyEvent>().ReverseMap();

        }
    }
}
