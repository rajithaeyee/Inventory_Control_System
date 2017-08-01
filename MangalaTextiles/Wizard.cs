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
    public partial class Wizard : MaterialForm
    {
        public Wizard()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Wizard_Load(object sender, EventArgs e)
        {

            Dictionary<string, int> dictionary =
            new Dictionary<string, int>();
            DateTime date = DateTime.Now;
            DateTime startDate = new DateTime(date.Year,date.Month,1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            using (var context = new MyContext())
            {

                //Stock Chart
                var items = context.Items.ToList();

                foreach (var it in items)
                {

                    chart3.Series[0].Points.AddXY(it.Item_Name, it.Quantity);
                    chart4.Series[0].Points.AddXY(it.Item_Name, it.Quantity);

                }


                //Sales Chart
                var filteredSales = context.Sales.Where(t => t.DateTime >= startDate && t.DateTime <= endDate);

                foreach (var fs in filteredSales)
                {
                    // var salesitem = context.SaleItems.Find(fs.SaleID);
                    var salesitem = (from slitm in context.SaleItems where slitm.SaleID == fs.SaleID select slitm);

                    foreach (var si in salesitem)
                    {


                        var itm = context.Items.Find(si.Sitem);
                        string itmName = itm.Item_Name;
                        int quantity = si.Quantity;

                        if (dictionary.ContainsKey(itmName))
                        {
                            int q = dictionary[itmName];
                            int tot = q + quantity;
                            dictionary[itmName] = tot;

                        }
                        else
                        {

                            dictionary.Add(itmName, quantity);


                        }

                    }


                }



            }


            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                chart1.Series[0].Points.AddXY(pair.Key,pair.Value);
                chart2.Series[0].Points.AddXY(pair.Key,pair.Value);
            }







        }
    }
}
