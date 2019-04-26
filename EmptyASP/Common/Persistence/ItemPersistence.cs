using Common.Persistence.Interfaces;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;
using System.Data.Entity;

namespace Common.Persistence
{
    public class ItemPersistence: IItemPersistence
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public bool Delete(int Id)
        {
            var get = myContext.Items.Find(Id);
            get.Delete();
            myContext.Entry(get).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
                status = true;
            return status;
        }

        public List<Item> Get()
        {
            return myContext.Items.Include("Suppliers").Where(x => x.IsDelete == false).ToList();
        }

        public Item Get(int Id)
        {
            var get = myContext.Items.Find(Id);
            return get;
        }

        public bool Insert(ItemVM itemVM)
        {
            var GetItem = new Item(itemVM);
            var getsupplier = myContext.Suppliers.Find(itemVM.Suppliers_Id);
            GetItem.Suppliers = getsupplier;
            myContext.Items.Add(GetItem);
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

        public bool Update(int Id, ItemVM itemVM)
        {
            var get = myContext.Items.Find(Id);
            get.Update(itemVM);
            var getsupplier = myContext.Suppliers.Find(itemVM.Suppliers_Id);
            get.Suppliers= getsupplier;
            myContext.Entry(get).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
                status = true;
            return status;
        }
    }
}
