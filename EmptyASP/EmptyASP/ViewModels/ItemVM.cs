using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyASP.ViewModels
{
    public class ItemVM 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public int Suppliers_Id { get; set; }
    }
}