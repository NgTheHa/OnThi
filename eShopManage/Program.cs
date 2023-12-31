
using eShopManage.Contexts;
using eShopManage.Services.ProviderServices.Implements;
using eShopManage.Services.ProviderServices.Interfaces;
using eShopManage.Services.ShopServices.Implements;
using eShopManage.Services.ShopServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShopManage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IShopService, ShopService>();
            builder.Services.AddScoped<IProviderService, ProviderService>();
            var app = builder.Build();

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