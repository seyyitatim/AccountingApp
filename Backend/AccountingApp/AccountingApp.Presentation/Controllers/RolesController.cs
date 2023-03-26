using AccountingApp.Application.Features.RoleFeatures.Commands.DeleteRole;
using AccountingApp.Application.Features.RoleFeatures.Commands.UpdateRole;
using AccountingApp.Application.Features.RoleFeatures.CreateRole;
using AccountingApp.Application.Features.RoleFeatures.Queries.GetAllRoles;
using AccountingApp.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Presentation.Controllers
{
    public class RolesController : BaseController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(CreateRoleRequest request)
        {
            return Ok(await _mediator.Send(request));
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRoles()
        {
            GetAllRolesRequest request = new();
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRole(UpdateRoleRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            DeleteRoleResquest request = new() { Id = id };
            return Ok(await _mediator.Send(request));
        }
    }
}
