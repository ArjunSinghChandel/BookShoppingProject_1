using BookShoppingProject.DataAccess.Data;
using BookShoppingProject.DataAccess.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShoppingProject.DataAccess.Repository
{
    public class Repository<T> : iRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> DbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T FirstorDefault(Expression<Func<T, bool>> filter = null, string includeproperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            if(includeproperties!=null)
            {
                foreach (var inculdeProp in includeproperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(inculdeProp);
                }

            }
            return FirstorDefault();

        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> Getall(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            if(includeProperties !=null)
            {
                foreach(var includeProp in includeProperties.Split(new Char[] { ','} , StringSplitOptions.RemoveEmptyEntries))
                        {

                    query = query.Include(includeProperties);
                }
            }
            if (orderby != null)
                return orderby(query).ToList();
            return query.ToList();
                
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Remove(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }
    }
}
