using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH69LS_HFT_2023241.Models;

namespace TH69LS_HFT_2023241.Repository.Repository
{
    public class Cat_OwnerRepository:Repository<Cat_Owner>, IRepository<Cat_Owner>  
    {
        public Cat_OwnerRepository(CatDbContext x) : base(x)
        {
        }

        public override Cat_Owner Read(int ID)
        {
            return x.Cat_Owners.FirstOrDefault(x => x.OID == ID);
        }

        public override void Update(Cat_Owner item)
        {
            var old = Read(item.OID);
            old.OID = item.OID;
            old.Owner_Name = item.Owner_Name;
            old.Owner_Age = item.Owner_Age;
            old.Is_Married = item.Is_Married;
            old.Nationality = item.Nationality;

            old.Cats = item.Cats;
            //foreach (var prop in old.GetType().GetProperties())
            //{
            //    prop.SetValue(old, prop.GetValue(item));
            //}
            x.SaveChanges();

        }
    }
}
