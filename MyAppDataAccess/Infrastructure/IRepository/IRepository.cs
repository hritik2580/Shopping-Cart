using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyAppDataAccess.Infrastructure.IRepository
{
    public interface IRepository <T> where T : class //  dont jnoow what  is this t is temlate class
    {
        IEnumerable<T> GetAll ();// product
        // we cant write id for some reason so we wiill wriite general expression first or default ypes kuch
        T GetT(Expression<Func<T,bool>>predicate);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities); // implement in repository pattern
    }
}
