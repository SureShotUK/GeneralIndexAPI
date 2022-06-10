﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Portland.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null);

        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null);

        T GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
            );

        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
            );

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
            );

        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
            );

        void Add(T entity);
        Task AddAsync(T entity);

        bool IfExists(Expression<Func<T, bool>>? filter = null);

        Task<bool> IfExistsAsync(Expression<Func<T, bool>>? filter = null);
    }
}
