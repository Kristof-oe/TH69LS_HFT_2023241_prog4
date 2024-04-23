using System;
using System.Collections.Generic;
using System.Linq;
using TH69LS_HFT_2023241.Models;
using TH69LS_HFT_2023241.Repository;

namespace TH69LS_HFT_2023241.Logic
{
    public class CatLogic : ICatLogic
    {
         IRepository<Cat> repo;

        public CatLogic(IRepository<Cat> repo)
        {
            this.repo = repo;
        }

        public void Create(Cat item)
        {
            if (item.Cat_Name == null)
            {
                throw new ArgumentException("You need to give a name for your cat");
            }
            repo.Create(item);
        }

        public void Delete(int ID)
        {

            repo.Delete(ID);
        }

        public Cat Read(int ID)
        {

            return repo.Read(ID);
        }

        public IQueryable<Cat> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Cat item)
        {
 
            repo.Update(item);
        }
        public IEnumerable<Cat> Mixed()
        {
            return repo.ReadAll().Where(t => t.Is_Mixed == true).OrderBy(t => t.Cat_Name);
        }


        public IEnumerable<TopBreed> Top2Breed()
        {
            var q = from x in repo.ReadAll()
                    group x by x.Breed into g
                    select new TopBreed
                    {
                        Breed = g.Key,
                        Count = g.Count()
                    };
            return q.OrderByDescending(x => x.Count).Take(2).Distinct();
        }
    }

    public class TopBreed
    {
        public string Breed { get; set; }
        public int Count { get; set; }
    }
}
