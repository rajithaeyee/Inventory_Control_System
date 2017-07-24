using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalaTextiles
{
    class MyContext : DbContext
    {
       //Uncomment this constructor when you change the db structure to start the db from initial state

        //public MyContext()
        //{
        //    Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
        //}


       public virtual DbSet<Employee> Employees { get; set; }

       public virtual DbSet<Supplier> Suppliers { get; set; }

       public virtual DbSet<Item> Items { get; set; }

       public virtual DbSet<Order> Orders { get; set; }

       public virtual DbSet<OrderedItem> OrderedItems { get; set; }

       public virtual DbSet<Sale> Sales { get; set; }

       public virtual DbSet<SalesItem> SaleItems { get; set; } 

    }
}
