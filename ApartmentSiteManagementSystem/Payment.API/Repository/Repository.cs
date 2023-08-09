using Microsoft.EntityFrameworkCore;
using Payment.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationPaymentDbContext context;
        private readonly DbSet<T> table;
        public Repository(ApplicationPaymentDbContext _context)
        {
            context = _context;
            table = context.Set<T>();
        }
        public void Add(T entity)
        {
            if (entity != null)
            {
                table.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            if (id!=null)
            {
                var entity = table.Find(id);
                if (entity != null)
                {
                    table.Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(string id)
        {

            var entity = table.Find(id);
            return entity;

        }
        public void Update(T entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
