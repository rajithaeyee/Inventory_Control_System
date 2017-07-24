using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnBarcode.Barcode;


namespace MangalaTextiles
{
    public partial class ItemManagement : Form
    {
        public ItemManagement()
        {
            InitializeComponent();
        }

        private void ItemManagement_Load(object sender, EventArgs e)
        {
            using(var context = new MyContext()){

                comboBox2.DataSource = context.Suppliers.ToList();
                comboBox2.DisplayMember = "Full_Name";
                comboBox2.ValueMember = "SuppilerID";
            
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            string code = (textBox4.Text.GetHashCode() + textBox5.Text.GetHashCode()).ToString().Replace("-", "");

            string FileName = "D:\\" + textBox4.Text + "_" + textBox5.Text + ".jpg";

            Linear barcode;

            textBox3.Text = code;

            barcode = new Linear();
            barcode.Type = BarcodeType.CODE11;
            barcode.Data = code;
            barcode.drawBarcode(FileName);

            MessageBox.Show("Barcode Generated Successfully!");

            using(var context = new MyContext()){

                var itm = new Item
                {
                    Bracode = code,
                    Item_Name = textBox4.Text,
                    Brand = textBox5.Text,
                    Size = comboBox1.SelectedText,
                    Quantity = Convert.ToInt32(textBox6.Text),
                    Net_Price = Convert.ToDouble(textBox7.Text),
                    Selling_Price = Convert.ToDouble(textBox8.Text),
                    Supplier_ID = Convert.ToInt32(comboBox2.SelectedValue)
                };

                context.Items.Add(itm);

                context.SaveChanges();

                var it = (from i in context.Items where i.Bracode == code select i);

                foreach(var i in it){

                    textBox2.Text = i.ItemID.ToString();
                
                }


                MessageBox.Show("Item Saved Successfully");
            
            }




        }

        private void button4_Click(object sender, EventArgs e)
        {
            int itemid = Convert.ToInt32(textBox2.Text);

            using(var context = new MyContext()){

                var itm = context.Items.Find(itemid);

                context.Items.Attach(itm);

                context.Items.Remove(itm);

                context.SaveChanges();

                MessageBox.Show("Item Deleted Successfully"); 

            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
