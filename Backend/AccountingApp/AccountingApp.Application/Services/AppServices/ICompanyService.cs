﻿using AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using AccountingApp.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Services.AppServices
{
    public interface ICompanyService
    {
        Task CreateCompanyAsync(CreateCompanyCommand request);
        Task MigrateCompanyDatabaseAsync(MigrateCompanyDatabaseCommand request);
        Task<Company?> GetCompanyByNameAsync(string name);
    }
}
