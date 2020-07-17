using Commander.Common.Interfaces;
using Commander.DAL.Models;
using Commander.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Comander.BLL
{
    /// <inheritdoc cref="IRepository"/>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public void CreateEntity(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Add(entity);
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <inheritdoc/>
        public T GetEntityByID(int id)
        {
            return  _dbSet.Find(id);
        }

        /// <inheritdoc/>
        public void UpdateEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <inheritdoc/>
        public void DeleteEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbSet.Remove(entity);
        }

        /// <inheritdoc/>
        public bool SaveChanges()
        {
           return _context.SaveChanges() >= 0;
        }
    }
}
