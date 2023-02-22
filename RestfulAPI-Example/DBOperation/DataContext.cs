using Microsoft.EntityFrameworkCore;
using RestfulAPI_Example.Entities;
using System.Net.Http.Headers;

namespace RestfulAPI_Example.DBOperation
{
    public class DataContext:DbContext
    {        
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Autor> Autors { get; set; }
    }
}
