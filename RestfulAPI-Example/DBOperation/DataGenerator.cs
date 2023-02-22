using Microsoft.EntityFrameworkCore;
using RestfulAPI_Example.Entities;

namespace RestfulAPI_Example.DBOperation
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if (context.Customers.Any())
                {
                    return;
                }
                context.Customers.AddRange(
                    new Customer
                    {
                        Id = 1,
                        FirstName = "Alper",
                        LastName = "Cubukcu",
                        PhoneNumber = "(555) 666-3521",
                        CustomerType = 1 // Abroad (Yurt dışı)
                    },
                    new Customer
                    {
                         Id = 2,
                         FirstName = "Mehmet",
                         LastName = "Cubukcu",
                         PhoneNumber = "(555) 666-3522",
                         CustomerType = 2 // Domestic (Yurt içi)
                    },
                    new Customer
                    {
                         Id = 3,
                         FirstName = "Hakkı",
                         LastName = "Cubukcu",
                         PhoneNumber = "(555) 666-3523",
                         CustomerType = 2 // Domestic (Yurt içi)
                    }
                 );


                context.Autors.AddRange(
                 new Autor
                 {
                     Id = 1,
                     FirstName = "Alper",
                     LastName = "Cubukcu",
                     BirtDate =DateTime.Now
                  
                 },
                  new Autor
                  {
                      Id = 2,
                      FirstName = "Alp",
                      LastName = "Cubukcu",
                      BirtDate = DateTime.Now
                  },
                  new Autor
                  {
                      Id = 3,
                      FirstName = "Ozge",
                      LastName = "Cubukcu",
                      BirtDate = DateTime.Now
                  }
              );
                context.SaveChanges();
            }

        }
    }
}
