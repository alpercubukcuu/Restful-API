using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulAPI_Example.Common;
using RestfulAPI_Example.DBOperation;
using RestfulAPI_Example.Model;
using System.Net;

namespace RestfulAPI_Example.CustomerOperations.GetCustomer
{
    public class GetCustomerQuery
    {
        private readonly DataContext _context;
        public GetCustomerQuery(DataContext dataContext)
        {
            _context = dataContext;
        }
        public List<CustomerViewMode> Handle()
        {
            List<CustomerViewMode> vm = new();
            var customers = _context.Customers.OrderBy(p => p.Id).ToList();
            if (customers is null)
                throw new InvalidOperationException("Müşteriler listenlirken bir sorun oluştu!");

            foreach (var cs in customers)
            {               
                vm.Add(new CustomerViewMode()
                {
                    FirstName = cs.FirstName,
                    LastName = cs.LastName,
                    CustomerType = ((TypeEnum)cs.CustomerType).ToString(),
                    PhoneNumber= cs.PhoneNumber,
                    PublisDate = DateTime.Now.ToString("dd/MM/yyyy")

                });                
            }           
            return vm;
        }
    }
    public class CustomerViewMode
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerType { get; set; }
        public string PhoneNumber { get; set; }
        public string PublisDate { get; set; }
    }
}
