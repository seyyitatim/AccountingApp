using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public class MigrateCompanyDatabaseResponse
    {
        public string Message { get; set; } = "Şirketletin database bilgileri migrate edildi!";
    }
}
