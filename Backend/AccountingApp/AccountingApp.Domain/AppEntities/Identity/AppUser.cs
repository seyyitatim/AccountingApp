﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Domain.AppEntities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string CompanyId { get; set; }
    }
}
