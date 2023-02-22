using Microsoft.EntityFrameworkCore;

namespace RestfulAPI_Example.Entities
{
    public class Autor : BaseEntity
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtDate { get; set; }

    }
}
