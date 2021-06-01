using PersonelApp.DAL.Repostories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PersonelApp.DAL.Repostories.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        internal DbContext  dbContext;
        private readonly DbSet<TEntity> dbSet;
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext?.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Remove(int id)
        {
            var dbCheck=dbSet.Remove(GetById(id));
           
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }
        [ValidateAntiForgeryToken]
        public bool Update(TEntity entity,int id)
        {
            var theItem = dbSet.Find(id);
            if (theItem == null)
            {
                return false;
            }
           
            return true;
        }
    }
}
