using AccountingApp.Application.Repositories;
using AccountingApp.Application.Repositories.UCAFRepositories;
using AccountingApp.Application.Services;
using AccountingApp.Application.Services.AppServices;
using AccountingApp.Application.Services.CompanyServices;
using AccountingApp.Persistence.Repository;
using AccountingApp.Persistence.Repository.UCAFRepositories;
using AccountingApp.Persistence.Services;
using AccountingApp.Persistence.Services.AppServices;
using AccountingApp.Persistence.Services.CompanyServices;

namespace AccountingApp.API.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContextService, ContextService>();
            #endregion

            #region Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUCAFService, UCAFService>();
            #endregion

            #region Repositories
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion
        }
    }
}
