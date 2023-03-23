using AccountingApp.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Repositories.UCAFRepositories
{
    public interface IUCAFCommandRepository : ICommandRepository<UniformChartOfAccount>
    {
    }
}
