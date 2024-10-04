using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.Services.Models;

namespace Otus.Teaching.PromoCodeFactory.Services.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerShortResponse>();
            CreateMap<Customer, CustomerResponse>();

            CreateMap<CreateOrEditCustomerRequest, Customer>();

            CreateMap<Preference, PreferenceResponse>();

            CreateMap<PromoCode, PromoCodeShortResponse>()
                .ForMember(dest => dest.BeginDate,
                    opt => opt.MapFrom(src =>
                        src.BeginDate.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.EndDate,
                    opt => opt.MapFrom(src =>
                        src.EndDate.ToString("dd.MM.yyyy")));
        }
    }
}
