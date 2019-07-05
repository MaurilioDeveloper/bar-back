using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalDeParceiros.Infrastructure.IRepository
{
    public interface IRepository<T, Key> : IDisposable where T : class
    {
        List<T> List(Func<T, bool> filter);
        T Find(Key key);
        Task<T> FindAsync(Key key);
        void UpdateAsync(T entity);
        void Insert(T entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        T Update(Key key, T entity);
        void Clean();
    }
}