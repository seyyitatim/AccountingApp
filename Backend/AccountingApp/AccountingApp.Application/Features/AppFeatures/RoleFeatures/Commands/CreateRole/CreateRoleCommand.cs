using AccountingApp.Application.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.RoleFeatures.CreateRole
{
    public class CreateRoleCommand : ICommand<CreateRoleCommandResponse>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
