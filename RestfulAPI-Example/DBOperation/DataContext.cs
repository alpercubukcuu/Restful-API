using Microsoft.EntityFrameworkCore;
using RestfulAPI_Example.Model;
using System.Net.Http.Headers;

namespace RestfulAPI_Example.DBOperation
{
    public class DataContext:DbContext
    {        
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
