using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Common.Interfaces
{
    /// <summary>
    /// Interface which allows to operate with entities.
    /// </summary>
    /// <typeparam name="T">Class of entity.</typeparam>
    public interface IRepository<T> where T: class
    {
        /// <summary>
        /// Get all specific entities.
        /// </summary>
        /// <returns>IEnumerable entities.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get specific entity by ID.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>T entity.</returns>
        T GetEntityByID(int id);
    }
}
