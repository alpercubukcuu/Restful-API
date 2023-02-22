using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulAPI_Example.Common;
using RestfulAPI_Example.DBOperation;
using RestfulAPI_Example.Entities;
using RestfulAPI_Example.Features.Queries.GetCustomer;
using System.Net;

namespace RestfulAPI_Example.Features.Queries.GetAutors
{
    public class GetAutorQuery
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetAutorQuery(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        public List<AutorViewModel> Handle()
        {
            List<AutorViewModel> vm = new();
            var autors = _context.Autors.OrderBy(p => p.Id).ToList();
            if (autors is null)
                throw new InvalidOperationException("Yazarlar listenlirken bir sorun oluştu!");
            vm = _mapper.Map<List<AutorViewModel>>(autors);
                     
            return vm;
        }
    }
    public class AutorViewModel
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtDay { get; set; } = DateTime.Now;
    }
}
