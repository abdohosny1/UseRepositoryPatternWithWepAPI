using Microsoft.EntityFrameworkCore;
using RepoistoryPatternWith.Core.consts;
using RepoistoryPatternWith.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoistoryPatternWith.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        T IBaseRepository<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entites)
        {
            _context.Set<T>().AddRange(entites);
            _context.SaveChanges();
            return entites;
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public int count()
        {
            return _context.Set<T>().Count();
        }

        public int count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);

        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> DeleteRang(IEnumerable<T> entitites)
        {
            _context.Set<T>().RemoveRange(entitites);
            _context.SaveChanges();
            return entitites;
        }

        public T Find(Expression<Func<T, bool>> criteria)
        {
           return _context.Set<T>().SingleOrDefault(criteria);
        }

        public T Find(Expression<Func<T, bool>> criteria, string[] include)
        {
            IQueryable<T> quary = _context.Set<T>();
            if (include != null)
            {
                foreach (var item in include)
                {
                    quary=quary.Include(item);
                }
            }

            return quary.SingleOrDefault(criteria);

        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDircation = "ASC")
        {
           IQueryable<T> quary= _context.Set<T>().Where(criteria);

            if (take.HasValue)
            {
                quary = quary.Take(take.Value);
            }

            if (skip.HasValue)
            {
                quary = quary.Skip(skip.Value);
            }

            if(orderBy != null)
            {
                if (orderByDircation == OrderBy.Assending)
                {
                    quary=quary.OrderBy(orderBy);
                }
                else
                {
                    quary = quary.OrderByDescending(orderBy);
                }
            }
            return quary.ToList();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var res = await _context.Set<T>().ToListAsync();
            return res;

        }

        public async Task<T> GetById(int id)
        {
            return  await _context.Set<T>().FindAsync(id);
                }



        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        IEnumerable<T> IBaseRepository<T>.FindAll(Expression<Func<T, bool>> criteria, string[] include)
        {
            IQueryable<T> quary = _context.Set<T>();
            if (include != null)
            {
                foreach (var item in include)
                {
                    quary = quary.Include(item);
                }
            }

            return quary.Where(criteria);
        }

       
    }
}
