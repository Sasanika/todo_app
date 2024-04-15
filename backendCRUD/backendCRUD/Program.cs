using backendCRUD.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configures the DbContext to use SQL Server with the connection string named "TodoDbContext" from appsettings.json
builder.Services.AddDbContext<TodoDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDbContext")));


var app = builder.Build();

// Allows requests from any origin by enabling Cross-Origin Resource Sharing (CORS).
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
