using AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using AccountingApp.Application.Services.AppServices;
using AccountingApp.Domain.AppEntities;
using AccountingApp.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Persistence.Services.AppServices
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCompanyAsync(CreateCompanyCommandRequest request)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company?> GetCompanyByNameAsync(string name) => await _context.Set<Company>().FirstOrDefaultAsync(p => p.Name == name);

        public async Task MigrateCompanyDatabaseAsync(MigrateCompanyDatabaseRequest request)
        {
            var companies = await _context.Set<Company>().ToListAsync();

            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }
        }
    }
}
