using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Applications.Interfaces
{
    public interface ISupplierApplication
    {
        List<Supplier> Get();
        Supplier Get(int Id);
        bool Insert(SupplierVM supplierVM);
        bool Update(int Id, SupplierVM supplierVM);
        bool Delete(int Id);
    }
}
