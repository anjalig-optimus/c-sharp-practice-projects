using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<MyDbContext>(static options =>
                options.UseSqlServer(connectionString: "DefaultConnection"))
            .BuildServiceProvider();

        var context = serviceProvider.GetService<MyDbContext>();

        // Call methods to interact with stored procedures
        GetCustomersByCity(context);
       InsertCustomer(context);
    }

    static void GetCustomersByCity(MyDbContext context)
    {
        // Call the stored procedure to get customers by city
        var customers = context.Customers
            .FromSqlRaw("EXEC GetCustomersByCity @CityName",
                        new SqlParameter("@CityName", "New York"))
            .ToList();

        // Display the results
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.Name}, {customer.Email}, {customer.City}");
        }
    }

    static void InsertCustomer(MyDbContext context)
    {
        // Call stored procedure to insert a new customer
        context.Database.ExecuteSqlRaw("EXEC InsertCustomer @Name, @Email, @City",
            new SqlParameter("@Name", "John Doe"),
            new SqlParameter("@Email", "johndoe@example.com"),
            new SqlParameter("@City", "Los Angeles"));

        Console.WriteLine("Customer inserted successfully.");
    }
}
