using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalaTextiles
{
    class SalesItem
    {
        public int SalesItemID { get; set; }
        public int Sitem { get; set; }
        public int Quantity { get; set; }

        // Foriegn keys
        public int SaleID { get; set; }
        public Sale Sale { get; set; }





    }
}
