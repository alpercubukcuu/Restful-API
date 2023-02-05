using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI_Example.Model;
using System.Net;

namespace RestfulAPI_Example.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        Context db = new(); // Gerçek bir veri tabanı bağlantısı bulunmamaktadır. O yüzden oluşturualn actionlar null dönecektir! 

        [HttpGet]
        public IActionResult Example()
        {
            return Ok();
        }

        [HttpGet]
        [Route("/api/example/list")]
        public List<Customer> ListCustomer([FromQuery] string firstname)
        {
            var name = db.Customers.Where(p => p.FirstName == firstname).ToList();
            return name;
        }

        [HttpPost]
        public string AddCustomer([FromBody] Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return "Add is ok";
        }

        [HttpPut]
        public string UpdateCustomer([FromQuery] int id)
        {
            var customer = db.Customers.FirstOrDefault(p => p.Id == id);
            Customer cts = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber
            };

            db.Customers.Update(cts);
            db.SaveChanges();

            return "Update is ok";
        }

        [HttpPatch("{id}")]
        public string UpdateCustomerForHeader(int id)
        {
            Customer customer = db.Customers.First(p => p.Id == id);
            try
            {
                Customer cts = new Customer()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber
                };

                db.Customers.Update(cts);
                db.SaveChanges();

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
            var customer = db.Customers.First(p => p.Id == id);

            db.Remove(customer);
            db.SaveChanges();

            return "Delete is ok";
        }

    }
}
