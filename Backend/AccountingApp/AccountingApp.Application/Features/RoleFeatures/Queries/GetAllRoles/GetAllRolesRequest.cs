using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.RoleFeatures.Queries.GetAllRoles
{
    public  class GetAllRolesRequest:IRequest<GetAllRolesResponse>
    {
    }
}
