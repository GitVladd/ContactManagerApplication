using ContactManagerApplication.Data;
using ContactManagerApplication.Processor;
using ContactManagerApplication.Repository.Concrete;
using ContactManagerApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerApplication.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbContext, ContactDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IFileProcessor, CsvFileProcessor>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
