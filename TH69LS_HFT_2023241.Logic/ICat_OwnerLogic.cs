using System.Collections.Generic;
using System.Linq;
using TH69LS_HFT_2023241.Models;

namespace TH69LS_HFT_2023241.Logic
{
    public interface ICat_OwnerLogic
    {
       // int CatPricePerMonth(int ID);
        void Create(Cat_Owner item);
        void Delete(int ID);
        IEnumerable<Cat_Owner> MarriedOwner();
        Cat_Owner Read(int ID);
        IQueryable<Cat_Owner> ReadAll();
        IEnumerable<Cat_Owner> RetiredPerson();
        void Update(Cat_Owner item);
    }
}