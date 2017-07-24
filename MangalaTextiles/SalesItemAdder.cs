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
    public partial class SalesItemAdder : Form
    {
        private string p;
        private string Barcode;
        private int itemID;
        private string ItemName;
        public string Quantity;

        public SalesItemAdder()
        {
            InitializeComponent();
        }

        
        public SalesItemAdder(string Barcode, int itemID, string ItemName)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.Barcode = Barcode;
            this.itemID = itemID;
            this.ItemName = ItemName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quantity = textBox4.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SalesItemAdder_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.itemID.ToString();
            textBox2.Text = this.Barcode;
            textBox3.Text = this.ItemName;
            Quantity = textBox4.Text;
        }

    }
}
