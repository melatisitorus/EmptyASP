using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmptyASP.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public bool IsDelete { get; set; }
    }
}