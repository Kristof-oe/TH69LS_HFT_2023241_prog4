using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH69LS_HFT_2023241.Models;

namespace TH69LS_HFT_2023241.Repository.Repository
{
    public class Cat_SitterRepository : Repository<Cat_Sitter>, IRepository<Cat_Sitter>
    {
        public Cat_SitterRepository(CatDbContext x) : base(x)
        {
        }

        public override Cat_Sitter Read(int ID)
        {
            return x.Cat_Sitters.FirstOrDefault(x => x.SID == ID);
        }

        public override void Update(Cat_Sitter item)
        {
            var old = Read(item.SID);
            old.SID = item.SID;
            old.Sitter_Name = item.Sitter_Name;
            old.Sitter_Age = item.Sitter_Age;
            old.Its_salary_month=item.Its_salary_month;
            old.Is_professional = item.Is_professional;


            old.Cat=item.Cat;
            old.CID = item.CID;
            //foreach (var prop in old.GetType().GetProperties())
            //{
            //    prop.SetValue(old,prop.GetValue(item));
            //}
            x.SaveChanges();

        }
    }
}
