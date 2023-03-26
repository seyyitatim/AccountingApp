using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public record CreateUCAFCommandCommandResponse(string Message = "Hesap planı kaydı başarıyla tamamlandı");
}
