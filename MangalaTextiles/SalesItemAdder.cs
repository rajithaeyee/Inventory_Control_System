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
    public partial class SalesItemAdder : MaterialForm
    {
        private string p;
        private string Barcode;
        private int itemID;
        private string ItemName;
        public string Quantity;
        public int Stock;
        public SalesItemAdder()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }


        public SalesItemAdder(string Barcode, int itemID, string ItemName, int Quantity)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        
            // TODO: Complete member initialization
            this.Barcode = Barcode;
            this.itemID = itemID;
            this.ItemName = ItemName;
            this.Stock = Quantity;
        }


        private void SalesItemAdder_Load(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Text = this.itemID.ToString();
            materialSingleLineTextField2.Text = this.Barcode;
            materialSingleLineTextField3.Text = this.ItemName;
            materialLabel2.Text = this.Stock.ToString();
            Quantity = materialSingleLineTextField4.Text;

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

            Quantity = materialSingleLineTextField4.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();


        }

        private void SalesItemAdder_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Visible = false;
            AdminPanel aP = new AdminPanel();
            aP.ShowDialog();
            this.Dispose();
        }

    }
}
