using Dynamic_Application.AppContext;
using Dynamic_Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace Dynamic_Application.Service
{
    public static class ServiceRegistration
    {
        private static readonly ILoggerFactory ContextLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public static void ConfigureCors(this IServiceCollection serviceCollection) =>
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination"));
            });

        public static void ConfigureIisIntegration(this IServiceCollection serviceCollection) =>
            serviceCollection.Configure<IISOptions>(options => { });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationData>(opts =>
                opts.UseSqlServer(connString));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IApplicationRepo, ApplicationRepo>();
            services.AddScoped<IProgramRepo, ProgramRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IQuestionAndAnswerRepo, QuestionAndAnswerRepo>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IProgramService, ProgramService>();
            services.AddScoped<IQuestionAndAnswerService, QuestionAndAnswerService>();
           
        }

    }

}