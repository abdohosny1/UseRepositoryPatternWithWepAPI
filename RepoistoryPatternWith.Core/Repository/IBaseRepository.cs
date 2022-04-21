using RepoistoryPatternWith.Core.consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoistoryPatternWith.Core.Repository
{
    public interface IBaseRepository<T> where T : class
    {
         Task<IEnumerable<T>> GetAll();
         T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entity);
       //  Task<T> Add(T movie);
         Task<T> GetById(int id);

        T Update(T entity);
        void Delete(T entity);
        IEnumerable<T> DeleteRang(IEnumerable<T> entity);


        void Attach(T entity);
        int count();
        int count(Expression<Func<T, bool>> criteria);

        T Find(Expression<Func<T, bool>> criteria);
        T Find(Expression<Func<T, bool>> criteria, string[] include );
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] include);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take,int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take,int? skip,
                             Expression<Func<T,object>> orderBy=null,string orderByDircation = OrderBy.Assending);



    }
}
