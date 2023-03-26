using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.AppFeatures.AppUserFeauteres.Login
{
    public record LoginCommandResponse(
        string Token,
        string Email,
        string UserId,
        string FullName);
}
