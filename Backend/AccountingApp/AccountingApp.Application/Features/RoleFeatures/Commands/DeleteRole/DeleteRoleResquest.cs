﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.RoleFeatures.Commands.DeleteRole
{
    public class DeleteRoleResquest : IRequest<DeleteRoleResponse>
    {
        public string Id { get; set; }
    }
}
