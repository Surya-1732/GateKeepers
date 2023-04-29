using Energy.Models;
using Microsoft.EntityFrameworkCore;

namespace Energy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EnergyContext>(options => 
                options.UseSqlServer("Server=tcp:hexathon2023server.database.windows.net,1433;Initial Catalog=Energy;Persist Security Info=False;User ID=hexathon2023;Password=Hexathon@2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            var app = builder.Build();

            //builder.Configuration.GetSection("Settings");

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
        }
    }
}