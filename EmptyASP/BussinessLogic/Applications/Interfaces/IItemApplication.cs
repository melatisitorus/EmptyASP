using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Applications.Interfaces
{
    public interface IItemApplication
    {
        List<Item> Get();
        Item Get(int Id);
        bool Insert(ItemVM itemVM);
        bool Update(int Id, ItemVM itemVM);
        bool Delete(int Id);
    }
}
