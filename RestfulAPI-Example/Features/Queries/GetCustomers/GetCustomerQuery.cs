using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulAPI_Example.Common;
using RestfulAPI_Example.DBOperation;
using RestfulAPI_Example.Entities;
using System.Net;

namespace RestfulAPI_Example.Features.Queries.GetCustomer
{
    public class GetCustomerQuery
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetCustomerQuery(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        public List<CustomerViewModel> Handle()
        {
            List<CustomerViewModel> vm = new();
            var customers = _context.Customers.OrderBy(p => p.Id).ToList();
            if (customers is null)
                throw new InvalidOperationException("Müşteriler listenlirken bir sorun oluştu!");

            vm = _mapper.Map<List<CustomerViewModel>>(customers);

              
            return vm;
        }
    }
    public class CustomerViewModel
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerType { get; set; }
        public string PhoneNumber { get; set; }
        public string PublisDate { get; set; } = DateTime.Now.ToString();
    }
}
