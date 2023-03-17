using AccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Presentation.Controllers
{
    public sealed class TestController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("işlem başarılı");
        }
    }
}
