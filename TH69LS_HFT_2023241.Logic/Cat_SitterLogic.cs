using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH69LS_HFT_2023241.Models;
using TH69LS_HFT_2023241.Repository;

namespace TH69LS_HFT_2023241.Logic
{
    public class Cat_SitterLogic : ICat_SitterLogic
    {
         IRepository<Cat_Sitter> repo;

        public Cat_SitterLogic(IRepository<Cat_Sitter> repo)
        {
            this.repo = repo;
        }

        public void Create(Cat_Sitter item)
        {
            if (item.Sitter_Name == null)
            {
                throw new ArgumentException("You need to give a name for your sitter");
            }
            this.repo.Create(item);
        }

        public void Delete(int ID)
        {

            this.repo.Delete(ID);
        }

        public Cat_Sitter Read(int ID)
        {
            
            return this.repo.Read(ID);
        }

        public IQueryable<Cat_Sitter> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Cat_Sitter item)
        {
          
            this.repo.Update(item);
        }

        /*public IEnumerable<string> CatHere(int item)
        {
            if (this.repo.Read(item) == null)
            {
                throw new ArgumentException($"We have not found any sitter with this ID: {item}");
            }
            return this.repo.Read(item).Where(x => x.Cat_Name));

            return seged.CID.where(x => x.Cat_Name);

        }*/

        public IEnumerable<Cat_Sitter> Salary()
        {
            return this.repo.ReadAll().Where(t => t.Its_salary_month>200000).OrderBy(t => t.Sitter_Name);
        }
    }
}
