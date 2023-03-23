using AccountingApp.Application.Services;
using AccountingApp.Domain.AppEntities;
using AccountingApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Persistence.Services
{
    public class ContextService : IContextService
    {
        private readonly AppDbContext _dbContext;

        public ContextService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext CreateDbContextInsatance(string companyId)
        {
            var company = _dbContext.Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }
    }
}
