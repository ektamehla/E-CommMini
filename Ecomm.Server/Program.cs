using Microsoft.EntityFrameworkCore;
using Ecomm.Server.Data;
using Ecomm.Server.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseInMemoryDatabase("EcommDb"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policyBuilder => policyBuilder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();

app.MapControllers();
SeedData(app);

app.MapFallbackToFile("/index.html");

app.Run();

void SeedData(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ProductContext>();

        if (!context.Products.Any())
        {
            context.Products.AddRange(
                new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 1200, Category = "Electronics" },
                new Product { Id = 2, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 199, Category = "Accessories" }
             );
            context.SaveChanges();
        }
    }
}
