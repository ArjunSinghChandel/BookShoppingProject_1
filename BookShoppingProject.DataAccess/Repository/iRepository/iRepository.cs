using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShoppingProject.DataAccess.Repository.iRepository
{
    public interface iRepository<T>where T:class
    {
        //for Find
        T Get(int id);
       
        //for Display
        IEnumerable<T> Getall(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string includeProperties = null);
        //accessing/find  multiple Table
       T FirstorDefault(
            Expression<Func<T,bool>>filter=null,
            string includeproperties=null
            );
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<T> entity);
       
    }
}
