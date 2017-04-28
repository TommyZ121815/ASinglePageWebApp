using ASinglePageWebApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASinglePageWebApp.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        T GetById(int id);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        IEnumerable<T> GetAll();
        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        //IQueryable entity
        IQueryable<T> GetQueryable();

        // Saving the changes to Database
        void SaveChanges();

        IEnumerable<T> AllInclude(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetPagedList(out int totalCount, int? page = null, int? pageSize = null,
            Expression<Func<T, bool>> filter = null, string[] includePaths = null,
            params SortExpression<T>[] sortExpressions);

        IEnumerable<U> GetBy<U>(Expression<Func<T, U>> columns, Expression<Func<T, bool>> where);
    }
}
