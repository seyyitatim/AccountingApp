using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.RoleFeatures.Commands.DeleteRole
{
    public record DeleteRoleCommandResponse(string Message = "Role başarılı bir şekilde silindi");
}
