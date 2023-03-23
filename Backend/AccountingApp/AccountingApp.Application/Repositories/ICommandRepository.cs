using AccountingApp.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Repositories
{
    public interface ICommandRepository<T> : IBaseRepository
        where T : Entity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void UpdateAsync(T entity);
        void UpdateRangeAsync(IEnumerable<T> entities);
        Task RemoveByIdAsync(string id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
