using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class AdminPanel : MaterialForm
    {
        public AdminPanel()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void button1_Click(object sender, EventArgs e)
        {
 



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
 

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            materialFlatButton1.Image = Image.FromFile("C:\\Users\\kmdtkonara\\Downloads\\group1.png");
            // Align the image and text on the button.
            materialFlatButton1.ImageAlign = ContentAlignment.MiddleRight;
            materialFlatButton1.TextAlign = ContentAlignment.MiddleLeft;
            



        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
         
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            UserManagement um = new UserManagement();
            this.Visible = false;
            um.ShowDialog();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            SupplierManagement sm = new SupplierManagement();
            this.Visible = false;
            sm.ShowDialog();
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            ItemManagement im = new ItemManagement();
            this.Visible = false;
            im.ShowDialog();
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            OrderManagement om = new OrderManagement();
            om.ShowDialog();

        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            Cart cart = new Cart();
            cart.ShowDialog();

        }

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Reporter rp = new Reporter();
            rp.ShowDialog();

        }

        private void materialFlatButton7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Wizard wiz = new Wizard();
            wiz.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



    }
}
