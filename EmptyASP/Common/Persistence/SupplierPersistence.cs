using Common.Persistence.Interfaces;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;

namespace Common.Persistence
{
    public class SupplierPersistence : ISupplierPersistence
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public bool Delete(int Id)
        {
            var get = myContext.Suppliers.Find(Id);
            get.Delete();
            myContext.Entry(get).State = System.Data.Entity.EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
                status = true;
            return status;
        }

        public List<Supplier> Get()
        {
            return myContext.Suppliers.Where(x => x.IsDelete == false).ToList();
        }

        public Supplier Get(int Id)
        {
            var get = myContext.Suppliers.Find(Id);
            return get;
        }

        public bool Insert(SupplierVM supplierVM)
        {
            var getsupplier = new Supplier(supplierVM);

            myContext.Suppliers.Add(getsupplier);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                return status = true;
            }
            else
            {
                return status = false;
            }
        }

        public bool Update(int Id, SupplierVM supplierVM)
        {
            var get = myContext.Suppliers.Find(Id);
            get.Update(supplierVM);
            myContext.Entry(get).State = System.Data.Entity.EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
                status = true;
            return status;
        }
    }
}
