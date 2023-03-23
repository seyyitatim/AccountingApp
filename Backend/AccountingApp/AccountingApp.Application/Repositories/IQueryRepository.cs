using AccountingApp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Repositories
{
    public interface IQueryRepository<T> : IBaseRepository
        where T : Entity
    {
        IQueryable<T> GetAll(bool isTracking = false);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = false);
        Task<T> GetByIdAsync(string id, bool isTracking = false);
        Task<T> GetFirstExpiressionAsync(Expression<Func<T, bool>> expression, bool isTracking = false);
        Task<T> GetFirst(bool isTracking = false);
    }
}
