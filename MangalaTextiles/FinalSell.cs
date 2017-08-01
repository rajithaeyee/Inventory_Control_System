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
    public partial class FinalSell : MaterialForm
    {
        private double Total;
        private double Balance=0.0;

        public FinalSell()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        public FinalSell(double Total) {

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.Total = Total;
        
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FinalSell_Load(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Text = Total.ToString();
            materialLabel2.Text = "RS. 0.00";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void materialSingleLineTextField2_TextChanged(object sender, EventArgs e)
        {


            double n;
            bool isNumeric = double.TryParse(materialSingleLineTextField2.Text, out n);

            if(isNumeric){
            
                
            double temp = Convert.ToDouble(materialSingleLineTextField2.Text);
            Balance = temp - Total;
            if (Balance >= 0)
            {

                materialLabel2.Text = "RS. " + Balance.ToString();

            }

            
            }


        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
