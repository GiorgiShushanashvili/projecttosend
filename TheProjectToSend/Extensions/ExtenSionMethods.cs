using Microsoft.EntityFrameworkCore;
using TheProjectToSend.Context;

namespace TheProjectToSend.Api.Extensions
{
    public static class ExtenSionMethods
    {
        public static IServiceCollection AddPersonContext(this IServiceCollection services, IConfiguration configuration) =>
        
            services.AddDbContext<PersonContext>(config => config.UseSqlServer(configuration.GetConnectionString("NewDatabase"))
            .EnableSensitiveDataLogging()
                             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        
    }
}
