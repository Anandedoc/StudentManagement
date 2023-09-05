
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;

namespace StudentManagement.Util
{
    public class ComponentsRegistry
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.Converters.Add(new StringEnumConverter());
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });


            // Add services to the container.

            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddEndpointsApiExplorer();

            serviceCollection.AddDbContext<Repository>(
                      options => options.UseInMemoryDatabase("StudentManagement"));

            serviceCollection.AddScoped<IUserContext, UserContext>();
            serviceCollection.AddScoped<IAuthService, AuthService>();
            serviceCollection.AddScoped<IStudentService, StudentService>();
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
            serviceCollection.AddScoped<IStaffService, StaffService>();
            serviceCollection.AddScoped<IStaffRepository, StaffRepository>();
            serviceCollection.AddScoped<ILoginService, LoginService>();
            serviceCollection.AddScoped<IDbInitializer, DbInitializer>();


        }
    }
}
