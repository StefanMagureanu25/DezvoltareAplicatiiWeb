using IMDB.Helpers.Authorization;
using IMDB.Repositories.DirectorRepository;
using IMDB.Repositories.MovieRepository;
using IMDB.Repositories.UserRepository;
using IMDB.Services.DirectorService;
using IMDB.Services.MovieService;
using IMDB.Services.UserService;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace IMDB.Helpers.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IMovieService, MovieService>();
            //services.AddTransient<IDirectorService, DirectorService>();

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
