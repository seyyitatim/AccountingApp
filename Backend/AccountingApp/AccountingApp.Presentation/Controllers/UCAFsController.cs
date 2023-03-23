using AccountingApp.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
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
    public class UCAFsController : BaseController
    {
        public UCAFsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUCAF(CreateUCAFCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
