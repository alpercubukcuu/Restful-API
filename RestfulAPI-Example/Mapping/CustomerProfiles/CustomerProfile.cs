using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using RestfulAPI_Example.Common;
using RestfulAPI_Example.Entities;
using RestfulAPI_Example.Features.Queries.GetCustomer;

namespace RestfulAPI_Example.Mapping.CustomerProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerViewModel>().ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => ((TypeEnum)src.CustomerType).ToString()));

        }
    }
}
