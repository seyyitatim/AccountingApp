﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.RoleFeatures.Commands.UpdateRole
{
    public record UpdateRoleCommandResponse(string Message = "Role güncelleme işlemi başarıyla tamamlandı");
}
