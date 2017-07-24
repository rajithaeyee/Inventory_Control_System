using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangalaTextiles
{
    public partial class SupplierManagement : Form
    {
        public SupplierManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int SupplierID = Convert.ToInt32(textBox1.Text);

            using(var context = new MyContext()){

                var sup = context.Suppliers.Find(SupplierID);

                textBox2.Text = sup.SuppilerID.ToString();

                textBox3.Text = sup.F_Name;

                textBox4.Text = sup.L_Name;

                textBox5.Text = sup.Email;

                textBox6.Text = sup.Tel_No;


            };




            }

        private void button2_Click(object sender, EventArgs e)
        {


            using (var context = new MyContext())
            {

                var supplier = new Supplier()
                {
                    F_Name = textBox3.Text,
                    L_Name = textBox4.Text,
                    Email = textBox5.Text,
                    Tel_No = textBox6.Text

                };

                context.Suppliers.Add(supplier);
                context.SaveChanges();
                var sup = (from sp in context.Suppliers where sp.F_Name == textBox3.Text && sp.L_Name == textBox4.Text select sp);

                foreach(var sp in sup){

                    textBox2.Text = sp.SuppilerID.ToString();



                }


                MessageBox.Show("Supplier added successfully");


        }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Update a supplier

            int supplier_ID = Convert.ToInt32(textBox2.Text);

            using(var context = new MyContext()){

                var supplier = context.Suppliers.Find(supplier_ID);

                supplier.F_Name = textBox3.Text;
                supplier.L_Name = textBox4.Text;
                supplier.Email = textBox5.Text;
                supplier.Tel_No = textBox6.Text;

                context.SaveChanges();

                MessageBox.Show("Supplier Details Updated Successfully");


            }




        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Delete A Supplier

            int supplier_ID = Convert.ToInt32(textBox2.Text);
            
            using(var context = new MyContext()){


                var supplier = context.Suppliers.Find(supplier_ID);

                context.Suppliers.Attach(supplier);

                context.Suppliers.Remove(supplier);

                context.SaveChanges();

                MessageBox.Show("Supplier Deleted successfully");

            }




        }
    }
}
