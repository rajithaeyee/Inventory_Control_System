using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalaTextiles
{
    class Sale
    {
        [Key]
        public int SaleID { get; set; }

        public DateTime DateTime { get; set; }

        public double Amount { get; set; }

        public ICollection<SalesItem> SalesItems { get; set; }

    }
}
