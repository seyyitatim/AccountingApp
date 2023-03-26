using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public record MigrateCompanyDatabaseCommandResponse(string Message = "Şirketletin database bilgileri migrate edildi!");
}
