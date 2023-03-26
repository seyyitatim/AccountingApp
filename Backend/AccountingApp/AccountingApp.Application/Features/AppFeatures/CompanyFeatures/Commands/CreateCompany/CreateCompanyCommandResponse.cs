using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public record CreateCompanyCommandResponse(string Message = "Şirket kaydı başarıyla tamamlandı!");
}
