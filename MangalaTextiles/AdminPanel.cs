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

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Form1 backLogin = new Form1();
            backLogin.Show();
         
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            UserManagement um = new UserManagement();

            um.Show();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            SupplierManagement sm = new SupplierManagement();

            sm.Show();
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            ItemManagement im = new ItemManagement();

            im.Show();
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            OrderManagement om = new OrderManagement();
            om.Show();

        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();

        }



    }
}
