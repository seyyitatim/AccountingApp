using AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingApp.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using AccountingApp.Application.Features.RoleFeatures.CreateRole;
using AccountingApp.Domain.AppEntities;
using AccountingApp.Domain.AppEntities.Identity;
using AccountingApp.Domain.CompanyEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Persistence.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommandRequest, Company>();
            CreateMap<CreateUCAFCommandRequest, UniformChartOfAccount>();
            CreateMap<CreateRoleRequest, AppRole>().BeforeMap((c, a) => a.Id = Guid.NewGuid().ToString());
        }
    }
}
