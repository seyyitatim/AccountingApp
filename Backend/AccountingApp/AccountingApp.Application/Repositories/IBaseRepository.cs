using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Repositories
{
    public interface IBaseRepository
    {
        void SetDbContextInstance(DbContext context);
    }
}
