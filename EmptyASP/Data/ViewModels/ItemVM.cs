using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class ItemVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Item Name")]
        public string Name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public int Suppliers_Id { get; set; }
    }
}
