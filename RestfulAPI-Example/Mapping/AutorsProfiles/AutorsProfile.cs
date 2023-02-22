using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using RestfulAPI_Example.Common;
using RestfulAPI_Example.Entities;
using RestfulAPI_Example.Features.Queries.GetAutors;


namespace RestfulAPI_Example.Mapping.CustomerProfiles
{
    public class AutorsProfile : Profile
    {
        public AutorsProfile()
        {
            CreateMap<Autor, AutorViewModel>();

        }
    }
}
