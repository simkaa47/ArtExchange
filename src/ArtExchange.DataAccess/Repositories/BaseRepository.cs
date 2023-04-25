﻿using ArtExchange.Application.Contracts.Repository;
using ArtExchange.DataAccess.DataContext;
using ArtExchange.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArtExchange.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepositoryAsync<T> where T : EntityCommon
    {
        private readonly ApplicationContext _dbContext;

        public BaseRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async  Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(entity=>entity.Id == id);
        }

        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>()                
                .ToListAsync();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
