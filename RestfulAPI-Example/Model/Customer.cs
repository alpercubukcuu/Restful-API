using Microsoft.EntityFrameworkCore;

namespace RestfulAPI_Example.Model
{    
    public class Customer
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerType { get; set; }
        public string PhoneNumber { get; set; }

    }
}
