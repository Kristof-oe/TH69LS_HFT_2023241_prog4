using System.Collections.Generic;
using System.Linq;
using TH69LS_HFT_2023241.Models;

namespace TH69LS_HFT_2023241.Logic
{
    public interface ICat_SitterLogic
    {
        void Create(Cat_Sitter item);
        void Delete(int ID);
        Cat_Sitter Read(int ID);
        IQueryable<Cat_Sitter> ReadAll();
        void Update(Cat_Sitter item);

    }
}