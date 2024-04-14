using Microsoft.EntityFrameworkCore;

namespace backendCRUD.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-EFVLH969; Initial Catalog=taskitems; User Id=sasanika; password=12345; TrustServerCertificate= True");
        }
    }
}