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
    public class ItemApplication : IItemApplication
    {
        private readonly IItemPersistence _itemPersistence;
        public ItemApplication(IItemPersistence itemPersistence)
        {
            _itemPersistence = itemPersistence;
        }
        public bool Delete(int Id)
        {
            if (string.IsNullOrEmpty(Id.ToString()) || string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return false;
            }
            else
            {
                return _itemPersistence.Delete(Id);
            }

        }

        public List<Item> Get()
        {
            return _itemPersistence.Get();
        }

        public Item Get(int Id)
        {
            return _itemPersistence.Get(Id);
        }

        public bool Insert(ItemVM itemVM)
        {
            if (string.IsNullOrEmpty(itemVM.Name) || string.IsNullOrWhiteSpace(itemVM.Name)) 
            {
                return false;
            }
            else if (string.IsNullOrEmpty(itemVM.price.ToString()) || string.IsNullOrWhiteSpace(itemVM.price.ToString()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(itemVM.stock.ToString()) || string.IsNullOrWhiteSpace(itemVM.stock.ToString()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(itemVM.Suppliers_Id.ToString()) || string.IsNullOrWhiteSpace(itemVM.Suppliers_Id.ToString()))
            {
                return false;
            }
            else
            {
                return _itemPersistence.Insert(itemVM);
            }
        }

        public bool Update(int Id, ItemVM itemVM)
        {
            if (string.IsNullOrEmpty(Id.ToString()) || string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(itemVM.Name) || string.IsNullOrWhiteSpace(itemVM.Name))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(itemVM.price.ToString()) || string.IsNullOrWhiteSpace(itemVM.price.ToString()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(itemVM.stock.ToString()) || string.IsNullOrWhiteSpace(itemVM.stock.ToString()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(itemVM.Suppliers_Id.ToString()) || string.IsNullOrWhiteSpace(itemVM.Suppliers_Id.ToString()))
            {
                return false;
            }
            else
            {
                return _itemPersistence.Update(Id, itemVM);
            }
        }
    }
}
