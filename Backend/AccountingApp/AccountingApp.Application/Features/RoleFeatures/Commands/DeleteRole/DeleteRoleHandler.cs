using AccountingApp.Application.Services.AppServices;
using AccountingApp.Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.RoleFeatures.Commands.DeleteRole
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleResquest, DeleteRoleResponse>
    {
        private readonly IRoleService roleService;

        public DeleteRoleHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async Task<DeleteRoleResponse> Handle(DeleteRoleResquest request, CancellationToken cancellationToken)
        {
            await roleService.DeleteByIdAsync(request.Id);
            return new();
        }
    }
}
