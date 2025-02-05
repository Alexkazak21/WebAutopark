using WebAutopark.DAO;
using WebAutopark.DAO.Interfaces;
using WebAutopark.Services;
using WebAutopark.Models;

namespace WebAutopark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });

            builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            //builder.Services.AddSwaggerGen();

            // Adding Services to work with DB
            var connectionString = builder.Configuration["ConnectionString"];
            builder.Services.AddTransient<IRepository<Vehicle>, VehicleRepository>(provider => new(connectionString));
            builder.Services.AddTransient<IRepository<VehicleTypes>, VehicleTypeRepository>(provider => new(connectionString));
            builder.Services.AddTransient<IRepository<Components>, ComponentRepository>(provider => new(connectionString));
            builder.Services.AddTransient<IRepository<OrderItems>, OrderItemRepository>(provider => new(connectionString));
            builder.Services.AddTransient<IRepository<Orders>, OrderRepository>(provider => new(connectionString));
            builder.Services.AddScoped<ICRUDService<Vehicle>, VehicleService>();
            builder.Services.AddScoped<ICRUDService<VehicleTypes>, VehicleTypeService>();
            builder.Services.AddScoped<ICRUDService<Orders>, OrderService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                //app.UseBrowserLink();
            }

            // Add Swagger
            //app.UseSwagger();
            //app.UseSwaggerUI();            

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
