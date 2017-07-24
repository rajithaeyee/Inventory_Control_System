using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalaTextiles
{
    class Supplier
    {
        [Key]
        public int SuppilerID { get; set; }

        public string F_Name { get; set; }

        public string L_Name { get; set; }

        public string Email { get; set; }

        public string Tel_No { get; set; }

        public string Full_Name {

            get
            {
                return F_Name + " " + L_Name;
            }
        
        }

        public ICollection<Item> Items { get; set; }



    }
}
