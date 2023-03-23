using AccountingApp.Application.Services.CompanyServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public class CreateUCAFCommandHandler : IRequestHandler<CreateUCAFCommandRequest, CreateUCAFCommandResponse>
    {
        private readonly IUCAFService _uCAFService;

        public CreateUCAFCommandHandler(IUCAFService uCAFService)
        {
            _uCAFService = uCAFService;
        }

        public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommandRequest request, CancellationToken cancellationToken)
        {
            _uCAFService.CreateUcafAsync(request);
            return new();
        }
    }
}
