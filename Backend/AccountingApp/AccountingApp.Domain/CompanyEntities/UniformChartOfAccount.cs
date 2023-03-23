﻿using AccountingApp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Domain.CompanyEntities
{
    public class UniformChartOfAccount:Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
