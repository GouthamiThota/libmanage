using AutoMapper;
using AutoMapper.Configuration;
using Database;
using LibraryManagement.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using Microsoft.Extensions.Configuration;

namespace librarymanagement.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ConfigurationManager config)
        {

           services.AddControllersWithViews();
            services.AddScoped<IBookProvider, BookProvider>();
            services.AddScoped<IBookrepository,BookRepository>();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt =>
            {

                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();

            return services;
        }
    }
}
