using Microsoft.EntityFrameworkCore;

namespace RestfulAPI_Example.Model
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }

    public class Customer
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
