using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH69LS_HFT_2023241.Models;
using TH69LS_HFT_2023241.Repository;

namespace TH69LS_HFT_2023241.Logic
{
    public class Cat_OwnerLogic : ICat_OwnerLogic
    {
         IRepository<Cat_Owner> repo;

        public Cat_OwnerLogic(IRepository<Cat_Owner> repo)
        {
            this.repo = repo;
        }

        public void Create(Cat_Owner item)
        {
            if (item.Owner_Name == null)
            {
                throw new ArgumentException("You need to give a name for your owner");
            }
            this.repo.Create(item);
        }

        public void Delete(int ID)
        {
       
            this.repo.Delete(ID);
        }

        public Cat_Owner Read(int ID)
        {
        
            return this.repo.Read(ID);
        }

        public IQueryable<Cat_Owner> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Cat_Owner item)
        {
  
            this.repo.Update(item);
        }

        /*public int CatPricePerMonth(int ID)
        {
            var cowner = this.repo.Read(ID);
            if (cowner == null)
            {
                throw new ArgumentException($"We have not found any cat with this ID: {ID}");
            }
            return cowner.Cats.Select(x => x.Cat_Sitter).Sum(t => t.);
        }*/

        public IEnumerable<Cat_Owner> RetiredPerson()
        {

            return this.repo.ReadAll().Where(x => x.Owner_Age > 64).OrderByDescending(x => x.Owner_Age);
        }

        public IEnumerable<Cat_Owner> MarriedOwner()
        {
            return this.repo.ReadAll().Where(t => t.Is_Married == true).OrderBy(t => t.Owner_Age);
        }
    }
}
