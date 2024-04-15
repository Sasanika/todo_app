using Microsoft.EntityFrameworkCore;

namespace backendCRUD.Models
{
    // DbEntity Framework Core provides a class called Context for interacting with databases.
    public class TodoDbContext : DbContext
    {
        // Constructor that configures the database connection by accepting DbContextOptions as a parameter

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        // Using the DbSet property, the database's collection of Todo entities is represented.

        public DbSet<Todo> Todo { get; set; }

        // Method to configure the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // UseSqlServer shows that SQL Server is the database provider,
            // and the connection string provides the details required to create a connection to the database.


            optionsBuilder.UseSqlServer("Data Source=LAPTOP-EFVLH969; Initial Catalog=taskitems; User Id=sasanika; password=12345; TrustServerCertificate= True");
        }
    }
}