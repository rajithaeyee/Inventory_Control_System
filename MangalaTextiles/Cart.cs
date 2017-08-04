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
    public partial class Cart : Form
    {
        double Total = 0;   
        public Cart()
        {
            InitializeComponent();

        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Barcode="";
            int itemID=-1;
            string ItemName="";
            string ItemSize = "";
            double price = 0;
            
            if (true)
            {

                using (var context = new MyContext())
                {

                  var itm = (from i in context.Items where i.Bracode == textBox1.Text select i);

                    foreach (var i in itm)
                    {
                        Barcode = textBox1.Text;
                        itemID = i.ItemID;
                        ItemName = i.Item_Name;
                        ItemSize = i.Size;
                        price = i.Selling_Price;
                    }



                }




                using (SalesItemAdder SIA = new SalesItemAdder(Barcode,itemID,ItemName))
                {

                 

                    if (SIA.ShowDialog() == DialogResult.OK)
                    {

                        dataGridView1.Rows.Add(itemID.ToString(), Barcode, ItemName, ItemSize, price.ToString(),SIA.Quantity);

                        Total = Total + (price * Convert.ToInt32(SIA.Quantity));
                        label2.Text = Total.ToString();

                    }



                
                } 



            }
            else { 
            
            


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FinalSell FS = new FinalSell(Total))
            {

                if (FS.ShowDialog() == DialogResult.OK) {

                using(var context = new MyContext()){


                    var sale = new Sale()
                    {

                        DateTime = DateTime.Now,
                        Amount = Total



                    };

                    context.Sales.Add(sale);
                 
                    context.SaveChanges();
                    int finalSell = context.Sales.Max(s => s.SaleID);
                   // var finalSell = //(from sells in context.Sales where sells.DateTime == sale.DateTime select sells);

                   // int saleID=-1;

                    //foreach(var s in finalSell){
                    int saleID = finalSell;
                    //int saleID = finalSell.SaleID;


                        foreach (DataGridViewRow row in this.dataGridView1.Rows)
                        {

                            int SItemID = Convert.ToInt32(row.Cells[0].Value);
                            int SItemQuantity = Convert.ToInt32(row.Cells[5].Value);

                            var salesItem = new SalesItem()
                            {
                                SaleID = saleID,
                                Sitem = SItemID,
                                Quantity = SItemQuantity

                            };

                            if (salesItem.Sitem != 0 && salesItem.Quantity != 0)
                            {

                                context.SaleItems.Add(salesItem);
                                context.SaveChanges();

                                MessageBox.Show("Done");


                            }


                        }
                    
                    //}


                


                }
    

                
                }

            
            
            }



        }
    }
}
