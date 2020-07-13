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
    /// <inheritdoc cref="IEntityRepository"/>
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
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <inheritdoc/>
        public T GetEntityByID(int id)
        {
            return  _dbSet.Find(id);
        }
    }
}
