using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH69LS_HFT_2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected CatDbContext x;
        public Repository(CatDbContext x)
        {
                this.x = x;
        }
        public void Create(T item)
        {
            x.Set<T>().Add(item);
            x.SaveChanges();
        }

        public void Delete(int ID)
        {
            x.Set<T>().Remove(Read(ID));
            x.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return x.Set<T>();
        }

        abstract public T Read(int ID);
        abstract public void Update(T item);
    }
}
