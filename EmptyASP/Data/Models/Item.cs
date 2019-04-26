using Core.Base;
using Data.Context;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Item: BaseModel
    {
        public string Name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }

        public virtual Supplier Suppliers { get; set; }
        public Item() { }
        public Item(ItemVM itemVM)
        {
            this.Name = itemVM.Name;
            this.price = itemVM.price;
            this.stock = itemVM.stock;
            //var getSupplier = myContext.Suppliers.Find(itemVM.suppliers_Id);
            //this.suppliers = getSupplier;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public virtual void Update(ItemVM itemVM)
        {
            this.Name = itemVM.Name;
            this.price = itemVM.price;
            this.stock = itemVM.stock;
            //var getSupplier = myContext.Suppliers.Find(itemVM.suppliers_Id);
            //this.suppliers = getSupplier;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public virtual void Delete()
        {
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            this.IsDelete = true;
        }
    }
}
