using AccountingApp.Application.Repositories.UCAFRepositories;
using AccountingApp.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Persistence.Repository.UCAFRepositories
{
    public class UCAFQueryRepository : QueryRepository<UniformChartOfAccount>, IUCAFQueryRepository
    {
    }
}
