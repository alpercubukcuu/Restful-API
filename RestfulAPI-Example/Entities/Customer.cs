using Microsoft.EntityFrameworkCore;

namespace RestfulAPI_Example.Entities
{    
    public class Customer : BaseEntity
    {        
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerType { get; set; }
        public string PhoneNumber { get; set; }

    }
}
