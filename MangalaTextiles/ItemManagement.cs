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
using MaterialSkin.Controls;
using MaterialSkin;


namespace MangalaTextiles
{
    public partial class ItemManagement : MaterialForm
    {
        public ItemManagement()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
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
            



        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            string code = (materialSingleLineTextField3.Text.GetHashCode() + materialSingleLineTextField5.Text.GetHashCode()).ToString().Replace("-", "");

            string FileName = "D:\\" + materialSingleLineTextField3.Text + "_" + materialSingleLineTextField4.Text + ".jpg";

            Linear barcode;

            materialSingleLineTextField2.Text = code;

            barcode = new Linear();
            barcode.Type = BarcodeType.CODE11;
            barcode.Data = code;
            barcode.drawBarcode(FileName);

            MessageBox.Show("Barcode Generated Successfully!");

            using (var context = new MyContext())
            {

                var itm = new Item
                {
                    Bracode = code,
                    Item_Name = materialSingleLineTextField3.Text,
                    Brand = materialSingleLineTextField4.Text,
                    Size = comboBox1.SelectedText,
                    Quantity = Convert.ToInt32(materialSingleLineTextField5.Text),
                    Net_Price = Convert.ToDouble(materialSingleLineTextField6.Text),
                    Selling_Price = Convert.ToDouble(materialSingleLineTextField7.Text),
                    Supplier_ID = Convert.ToInt32(comboBox2.SelectedValue)
                };

                context.Items.Add(itm);

                context.SaveChanges();

                var it = (from i in context.Items where i.Bracode == code select i);

                foreach (var i in it)
                {

                    materialSingleLineTextField1.Text = i.ItemID.ToString();

                }


                MessageBox.Show("Item Saved Successfully");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            int itemid = Convert.ToInt32(materialSingleLineTextField1.Text);

            using (var context = new MyContext())
            {

                var itm = context.Items.Find(itemid);

                context.Items.Attach(itm);

                context.Items.Remove(itm);

                context.SaveChanges();

                MessageBox.Show("Item Deleted Successfully");

            }
        
        }

        private void materialSingleLineTextField8_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField8.Text = "";
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField2.Text = "";

        }

        private void materialSingleLineTextField3_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField3.Text = "";

        }

        private void materialSingleLineTextField4_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField4.Text = "";
        }

        private void materialSingleLineTextField5_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField5.Text = "";
        }

        private void materialSingleLineTextField6_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField6.Text = "";
        }

        private void materialSingleLineTextField7_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField7.Text = "";
        }

        private void materialSingleLineTextField5_TextChanged(object sender, EventArgs e)
        {
            try {

                Convert.ToInt32(materialSingleLineTextField5.Text);
                materialLabel1.Visible = false;
                materialFlatButton1.Enabled = true;
            
            }catch(Exception){

                materialLabel1.Visible = true;
                materialFlatButton1.Enabled = false;
            }
        }

        private void materialSingleLineTextField6_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Convert.ToDouble(materialSingleLineTextField6.Text);
                materialLabel2.Visible = false;
                materialFlatButton1.Enabled = true;

            }
            catch (Exception)
            {

                materialLabel2.Visible = true;
                materialFlatButton1.Enabled = false;
            }

        }

        private void materialSingleLineTextField7_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Convert.ToDouble(materialSingleLineTextField7.Text);
                materialLabel3.Visible = false;
                materialFlatButton1.Enabled = true;

            }
            catch (Exception)
            {

                materialLabel3.Visible = true;
                materialFlatButton1.Enabled = false;
            }
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void ItemManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Visible = false;
            AdminPanel aP = new AdminPanel();
            aP.ShowDialog();
            this.Dispose();
        }
    }
}
