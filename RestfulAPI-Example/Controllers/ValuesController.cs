using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulAPI_Example.Features.Queries.GetCustomer;
using RestfulAPI_Example.DBOperation;
using RestfulAPI_Example.Entities;
using System.Net;
using System.Reflection.Metadata;
using AutoMapper;

namespace RestfulAPI_Example.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ValuesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/GetCustomers")]
        public IActionResult GetCustomers()
        {
            GetCustomerQuery getCustomersQuery = new GetCustomerQuery(_context, _mapper);
            List<CustomerViewModel> customer = new();
            try
            {
                customer = getCustomersQuery.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            return Ok(customer);
        }

        [HttpGet]
        [Route("/api/example/list")]
        public List<Customer> ListCustomer([FromQuery] string firstname)
        {
            var List = _context.Customers.Where(p => p.FirstName == firstname).ToList();
            return List;
        }

        [HttpPost]
        public string AddCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return "Add is ok";
        }

        [HttpPut]
        public string UpdateCustomer([FromQuery] int id)
        {
            var customer = _context.Customers.FirstOrDefault(p => p.Id == id);
            Customer cts = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber
            };

            _context.Customers.Update(cts);
            _context.SaveChanges();

            return "Update is ok";
        }

        [HttpPatch("{id}")]
        public string UpdateCustomerForHeader(int id)
        {
            Customer customer = _context.Customers.First(p => p.Id == id);
            try
            {
                Customer cts = new Customer()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber
                };

                _context.Customers.Update(cts);
                _context.SaveChanges();

                return "Update is ok";

            }
            catch (Exception e)
            {
                if (customer.Equals(customer.FirstName))
                {
                    string error = (HttpStatusCode.NotModified).ToString(); // Update işemi gerçekleşmediğine dair bilgi dönülüyor.
                    return error;
                }

                return e.Message;
            }

        }

        [HttpDelete]
        public string DeleteCustomer([FromQuery] int id)
        {
            var customer = _context.Customers.First(p => p.Id == id);

            _context.Remove(customer);
            _context.SaveChanges();

            return "Delete is ok";
        }

    }
}
