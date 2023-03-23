using AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingApp.Domain.AppEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Persistence.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommandRequest, Company>().ReverseMap();
        }
    }
}
