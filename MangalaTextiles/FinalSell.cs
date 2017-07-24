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
    public partial class FinalSell : Form
    {
        private double Total;
        private double Balance=0.0;

        public FinalSell()
        {
            InitializeComponent();
        }

        public FinalSell(double Total) {

            InitializeComponent();
            this.Total = Total;
        
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FinalSell_Load(object sender, EventArgs e)
        {
            textBox1.Text = Total.ToString();
            label2.Text = "RS. 0.00";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double temp = Convert.ToDouble(textBox2.Text);
            Balance = Total - temp;
            if (Balance >= 0)
            {

                label2.Text = "RS. "+Balance.ToString();

            }


        }
    }
}
