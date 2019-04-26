using BussinessLogic.Applications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;
using Common.Persistence.Interfaces;

namespace BussinessLogic.Applications
{
    public class SupplierApplication : ISupplierApplication
    { 
        private readonly ISupplierPersistence _supplierPersistence;
        public SupplierApplication(ISupplierPersistence supplierPersistence)
        {
            _supplierPersistence = supplierPersistence;
        }
        public bool Delete(int Id)
        {
            if(string.IsNullOrEmpty(Id.ToString()) || string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return false;
            }
            else
            {
                return _supplierPersistence.Delete(Id);
            }
        }

        public List<Supplier> Get()
        {
            return _supplierPersistence.Get();
        }

        public Supplier Get(int Id)
        {
            return _supplierPersistence.Get(Id);   
        }

        public bool Insert(SupplierVM supplierVM)
        {
            if (string.IsNullOrEmpty(supplierVM.Name) || string.IsNullOrWhiteSpace(supplierVM.Name))
            {
                return false;
            }
            else
            {
                return _supplierPersistence.Insert(supplierVM);
            }
        }

        public bool Update(int Id, SupplierVM supplierVM)
        {
            if (string.IsNullOrEmpty(Id.ToString()) || string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(supplierVM.Name) || string.IsNullOrWhiteSpace(supplierVM.Name))
            {
                return false;
            }
            else
            {
                return _supplierPersistence.Update(Id, supplierVM);
            }
        }
    }
}
