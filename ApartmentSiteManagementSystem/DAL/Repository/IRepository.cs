using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(string id);
        List<T> GetAll();
        T GetById(string id);
        void Update(T entity);
    }
}
