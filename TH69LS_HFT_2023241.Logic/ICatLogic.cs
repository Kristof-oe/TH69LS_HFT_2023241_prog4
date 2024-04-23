using System.Collections.Generic;
using System.Linq;
using TH69LS_HFT_2023241.Models;

namespace TH69LS_HFT_2023241.Logic
{
    public interface ICatLogic
    {
       
        void Create(Cat item);
        void Delete(int ID);
        Cat Read(int ID);
        IQueryable<Cat> ReadAll();
        public IEnumerable<Cat> Mixed();
        IEnumerable<TopBreed> Top2Breed();
        void Update(Cat item);
    }
}