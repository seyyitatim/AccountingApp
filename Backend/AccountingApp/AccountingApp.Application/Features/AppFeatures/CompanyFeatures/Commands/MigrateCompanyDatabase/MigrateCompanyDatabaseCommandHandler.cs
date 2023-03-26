using AccountingApp.Application.Messaging;
using AccountingApp.Application.Services.AppServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public class MigrateCompanyDatabaseCommandHandler : ICommandHandler<MigrateCompanyDatabaseCommand, MigrateCompanyDatabaseCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public MigrateCompanyDatabaseCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<MigrateCompanyDatabaseCommandResponse> Handle(MigrateCompanyDatabaseCommand request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabaseAsync(request);
            return new();
        }
    }
}
