using AccountingApp.Domain.AppEntities.Identity;
using AccountingApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AccountingApp.API.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString(SectionName)));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(AccountingApp.Persistence.AssemblyReference).Assembly);
        }
    }
}
