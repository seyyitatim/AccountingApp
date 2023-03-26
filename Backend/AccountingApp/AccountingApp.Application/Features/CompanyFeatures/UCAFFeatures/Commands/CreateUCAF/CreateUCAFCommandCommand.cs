﻿using AccountingApp.Application.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public class CreateUCAFCommandCommand : ICommand<CreateUCAFCommandCommandResponse>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string CompanyId { get; set; }
    }
}
