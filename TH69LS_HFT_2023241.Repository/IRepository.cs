using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH69LS_HFT_2023241.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ReadAll();

        T Read(int ID);

        void Create(T item);

        void Update(T item);
        void Delete(int ID);    
    }
}
