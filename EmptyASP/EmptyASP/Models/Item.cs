using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmptyASP.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public virtual Supplier suppliers { get; set; }
        public bool IsDelete { get; set; }
    }
}