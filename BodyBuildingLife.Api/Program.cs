using BodyBuildingLife.Api.Exctension;
using BodyBuildingLife.Api.Middlewares;
using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Service.Helpers;
using BodyBuildingLife.Service.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(option => 
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
          
            // Add services to the container.
            builder.Services.AddCustomerService();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddAutoMapper(typeof(MapperProfile));

            WebHostEnvarement.WebRootPath = Path.GetFullPath("wwwroot");

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHendlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}