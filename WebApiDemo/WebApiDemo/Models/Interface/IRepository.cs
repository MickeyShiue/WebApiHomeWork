using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Models.Interface
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        void Create(T instance);

        void Update(T instance);

        void Delete(T id);

        T Get(int primaryID);

        IQueryable<T> GetAll();

        void SaveChanges();

    }
}
