using AutoMapper;
using CreativeIndustries.API.DXS.CompanyViewModels;
using CreativeIndustries.DS.Entities;

namespace CreativeIndustries.API.Mappings
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyViewModel, Company>().ReverseMap();
        }
    }
}
