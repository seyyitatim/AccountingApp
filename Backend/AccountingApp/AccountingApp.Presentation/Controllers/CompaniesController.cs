using AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
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
    public class CompaniesController : BaseController
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CrateCompany(CreateCompanyCommandRequest request)
        {
            CreateCompanyCommandResponse response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabaseAsync()
        {
            MigrateCompanyDatabaseRequest request = new();
            var response = await _mediator.Send(request);

            return Ok(response);

        }
    }
}
