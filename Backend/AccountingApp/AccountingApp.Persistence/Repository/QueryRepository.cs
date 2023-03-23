﻿using AccountingApp.Application.Repositories;
using AccountingApp.Domain.Abstractions;
using AccountingApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Persistence.Repository
{
    public class QueryRepository<T> : IQueryRepository<T>
        where T : Entity
    {
        private CompanyDbContext _context;
        public DbSet<T> Entity;

        // context içinde FirstOrDefaultAsync kullanmamıza gerek yok method async olduğu için o şekilde çalışacak.
        private static readonly Func<CompanyDbContext, string, bool, Task<T>> GetByIdCompiled = EF.CompileAsyncQuery((CompanyDbContext context, string id, bool isTracking) =>
            isTracking ? context.Set<T>().FirstOrDefault(p => p.Id == id)
                       : context.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id));

        private static readonly Func<CompanyDbContext, bool, Task<T>> GetFirstCompiled = EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) =>
            isTracking ? context.Set<T>().FirstOrDefault()
                       : context.Set<T>().AsNoTracking().FirstOrDefault());

        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, bool, Task<T>> GetFirstExpiressionCompiled = EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> expression, bool isTracking) =>
            isTracking ? context.Set<T>().FirstOrDefault(expression)
                       : context.Set<T>().AsNoTracking().FirstOrDefault(expression));

        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
            Entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll(bool isTracking = false)
        {
            var result = Entity.AsQueryable();
            if (!isTracking) result = result.AsNoTracking();
            return result;
        }

        public async Task<T> GetByIdAsync(string id, bool isTracking = false)
        {
            return await GetByIdCompiled(_context, id, isTracking);
        }

        public async Task<T> GetFirst(bool isTracking = false)
        {
            return await GetFirstCompiled(_context, isTracking);
        }

        public async Task<T> GetFirstExpiressionAsync(Expression<Func<T, bool>> expression, bool isTracking = false)
        {
            return await GetFirstExpiressionCompiled(_context, expression, isTracking);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = false)
        {
            var result = Entity.Where(expression);
            if (!isTracking) result = result.AsNoTracking();
            return result;
        }
    }
}
