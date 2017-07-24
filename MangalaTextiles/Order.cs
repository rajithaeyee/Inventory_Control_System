using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalaTextiles
{
    class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Cheque_No { get; set; }

        public string Status { get; set; }
        //Foriegn keys in Standard way

        public int SupplierID { get; set; }

        public Supplier Supplier { get; set; }


       // public ICollection<Item> Items { get; set; }
        public ICollection<OrderedItem> OrderedItems { get; set; }

    }
}
