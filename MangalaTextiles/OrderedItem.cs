using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalaTextiles
{
    class OrderedItem
    {

       public int OrderedItemID { get; set; }
       public int Oitem { get; set; }
       public int Quantity { get; set; }

       // Foriegn keys
       public int OrderID { get; set; }
       public Order Order { get; set; }

      // public int OrderedItemID { get; set; }

      // public Item Item { get; set; }

    }
}
