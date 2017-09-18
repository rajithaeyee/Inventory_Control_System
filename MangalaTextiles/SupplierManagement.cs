using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangalaTextiles
{
    public partial class SupplierManagement : MaterialForm

    {
        public SupplierManagement()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        
        }

        private void SupplierManagement_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {


            using (var context = new MyContext())
            {
                //Add Supplier

                var supplier = new Supplier()
                {
                    F_Name = materialSingleLineTextField2.Text,
                    L_Name = materialSingleLineTextField3.Text,
                    Email = materialSingleLineTextField4.Text,
                    Tel_No = materialSingleLineTextField5.Text

                };

                context.Suppliers.Add(supplier);
                context.SaveChanges();
                var sup = (from sp in context.Suppliers where sp.F_Name == materialSingleLineTextField2.Text && sp.L_Name == materialSingleLineTextField3.Text select sp);

                foreach (var sp in sup)
                {

                    materialSingleLineTextField1.Text = sp.SuppilerID.ToString();



                }


                MessageBox.Show("Supplier added successfully");


            }

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            //Update a supplier

            int supplier_ID = Convert.ToInt32(materialSingleLineTextField6.Text);

            using (var context = new MyContext())
            {

                var supplier = context.Suppliers.Find(supplier_ID);

                supplier.F_Name = materialSingleLineTextField2.Text;
                supplier.L_Name = materialSingleLineTextField3.Text;
                supplier.Email = materialSingleLineTextField4.Text;
                supplier.Tel_No = materialSingleLineTextField5.Text;

                context.SaveChanges();

                MessageBox.Show("Supplier Details Updated Successfully");


            }

        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            //Delete A Supplier

            int supplier_ID = Convert.ToInt32(materialSingleLineTextField6.Text);

            using (var context = new MyContext())
            {


                var supplier = context.Suppliers.Find(supplier_ID);

                context.Suppliers.Attach(supplier);

                context.Suppliers.Remove(supplier);

                context.SaveChanges();

                MessageBox.Show("Supplier Deleted successfully");

            }

        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            int SupplierID = Convert.ToInt32(materialSingleLineTextField6.Text);

            using (var context = new MyContext())
            {

                var sup = context.Suppliers.Find(SupplierID);

                materialSingleLineTextField1.Text = sup.SuppilerID.ToString();

                materialSingleLineTextField2.Text = sup.F_Name;

                materialSingleLineTextField3.Text = sup.L_Name;

                materialSingleLineTextField4.Text = sup.Email;

                materialSingleLineTextField5.Text = sup.Tel_No;

            };

        }

        private void materialSingleLineTextField6_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField6.Text = "";
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
            try
            {
                MailAddress m = new MailAddress(materialSingleLineTextField4.Text);
                materialLabel1.Visible = false;
                materialFlatButton1.Enabled = true;
                
            }
            catch (Exception)
            {
                materialLabel1.Visible = true;
                materialFlatButton1.Enabled = false;
            }

            materialSingleLineTextField5.Text = "";

        }

        private void materialSingleLineTextField5_TextChanged(object sender, EventArgs e)
        {
            Regex rgx = new Regex("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$");
            if (rgx.IsMatch(materialSingleLineTextField5.Text))
            {
                materialLabel2.Visible = false;
                materialFlatButton1.Enabled = true;
            }
            else {

                materialLabel2.Visible = true;
                materialFlatButton1.Enabled = false;
            }

        }
    }
}
