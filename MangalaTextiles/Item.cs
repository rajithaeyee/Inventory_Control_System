using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalaTextiles
{
    class Item
    {
        public int ItemID { get; set; }

        public string Bracode { get; set; }

        public string Item_Name { get; set; }

        public string Brand { get; set; }

        public string Size { get; set; }

        public int Quantity { get; set; }

        public double Net_Price { get; set; }

        public double Selling_Price { get; set; }

        //Foreign keys in standard way

        public int Supplier_ID { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<OrderedItem> OrderItems { get; set; }

        

    }
}
