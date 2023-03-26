using AccountingApp.Application.Messaging;
using AccountingApp.Application.Services.CompanyServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public class CreateUCAFCommandCommandHandler : ICommandHandler<CreateUCAFCommandCommand, CreateUCAFCommandCommandResponse>
    {
        private readonly IUCAFService _uCAFService;

        public CreateUCAFCommandCommandHandler(IUCAFService uCAFService)
        {
            _uCAFService = uCAFService;
        }

        public async Task<CreateUCAFCommandCommandResponse> Handle(CreateUCAFCommandCommand request, CancellationToken cancellationToken)
        {
            _uCAFService.CreateUcafAsync(request);
            return new();
        }
    }
}
