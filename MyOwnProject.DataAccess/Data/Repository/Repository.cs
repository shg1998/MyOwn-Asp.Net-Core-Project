﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyOwnProject.DataAccess.Data.Repository
{
   public class Repository<T> : IRepository.IRepository<T> where T : class
    {

        protected readonly DbContext context;
        internal DbSet<T> dbSet;


        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter!=null)
            {
                query = query.Where(filter); 
            }
            if (includeProperties !=null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (OrderBy!=null)
            {
                return OrderBy(query).ToList();
            }
            return query.ToList();  
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);
            dbSet.Remove(entityToRemove);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity); 
        }
    }
}
