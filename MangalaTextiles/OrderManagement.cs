using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangalaTextiles
{
    public partial class OrderManagement : Form
    {
        public OrderManagement()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (var context = new MyContext())
            {
                int ItmID = Convert.ToInt32(comboBox3.SelectedValue);
                var item = (from itm in context.Items where itm.ItemID == ItmID select itm);

                foreach(var it in item){
                    this.dataGridView1.Rows.Add(it.ItemID,it.Item_Name, textBox2.Text);
                }

                
            }




            //MailMessage message = new MailMessage();
            //SmtpClient smtp = new SmtpClient();

            //message.From = new MailAddress("rajithaeye@gmail.com");
            //message.To.Add(new MailAddress("rajithaeye@gmail.com"));
            //message.Subject = "Test";
            //message.Body = "Content";

            //smtp.Port = 465;
            //smtp.Host = "smtp.gmail.com";
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new NetworkCredential("rajithaeye@gmail.com", "rajitha prabath@");
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.Send(message);

        }

        private void OrderManagement_Load(object sender, EventArgs e)
        {
            using (var context = new MyContext())
            {
                comboBox1.DataSource = context.Orders.ToList();
                comboBox1.DisplayMember = "DateAndTime";
                comboBox1.ValueMember = "OrderID";
                comboBox2.DataSource = context.Suppliers.ToList();
                comboBox2.DisplayMember = "Full_Name";
                comboBox2.ValueMember = "SuppilerID";

            }



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int supid;
            
            try{
            
            supid = Convert.ToInt32(comboBox2.SelectedValue);
            }catch(Exception ex){
                supid = 1;
            }
           
            using(var context = new MyContext()){
            var item = (from itm in context.Items where itm.Supplier_ID == supid select itm).ToList<Item>();
            comboBox3.DataSource = item;
            comboBox3.DisplayMember = "Item_Name";
            comboBox3.ValueMember = "ItemID";
            
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new MyContext())
            {

                var order = new Order()
                {

                    DateAndTime = DateTime.Now,
                    Cheque_No = textBox3.Text,
                    Status = "Processing",
                    SupplierID = Convert.ToInt32(comboBox2.SelectedValue)

                };

                context.Orders.Add(order);
                context.SaveChanges();
                var finalOrder = (from ord in context.Orders where ord.Cheque_No == textBox3.Text select ord);

                foreach (var o in finalOrder)
                {

                    textBox1.Text = o.OrderID.ToString();

                }

                int OrderNumber = Convert.ToInt32(textBox1.Text);

                foreach(DataGridViewRow row in this.dataGridView1.Rows){
                    int OItemID = Convert.ToInt32(row.Cells[0].Value);
                    int OItemQuantity = Convert.ToInt32(row.Cells[2].Value);

                 var ordereditem = new OrderedItem(){
                                      OrderID = OrderNumber,
                                      Oitem = OItemID,                    
                                      Quantity = OItemQuantity    
                                          };
                 if (ordereditem.Oitem != 0 && ordereditem.Quantity != 0)
                 {

                        context.OrderedItems.Add(ordereditem);
                        context.SaveChanges();
                    
                    }
                
                }

                

                comboBox1.DataSource = context.Orders.ToList();
                comboBox1.DisplayMember = "DateAndTime";
                comboBox1.ValueMember = "OrderID";
                MessageBox.Show("Order Added successfully");


            }



        }

        private void button4_Click(object sender, EventArgs e)
        {

            int orderID = Convert.ToInt32(comboBox1.SelectedValue);
            this.dataGridView1.Rows.Clear();
           
            using (var context = new MyContext()){

                var order = (from o in context.Orders where o.OrderID == orderID select o);
                var orderitem = (from orditm in context.OrderedItems where orditm.OrderID == orderID select orditm);

                foreach(var x in order){

                    if (x.Status.Equals("Cancelled"))
                    {

                        this.dataGridView1.Rows.Add("This Order", "Is Already", "Cleared");

                    }
                    else {


                        foreach (var y in orderitem)
                        {

                            var itm = context.Items.Find(y.Oitem);
                            this.dataGridView1.Rows.Add(itm.ItemID, itm.Item_Name, y.Quantity);
                            //MessageBox.Show(itm.Item_Name);

                        }
                    
                    
                    
                    }

                
                }
                
                

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(comboBox1.SelectedValue);


            using (var context = new MyContext())
            {
                var Order = context.Orders.Find(orderID);

                Order.Status = "Cancelled";

                context.SaveChanges();
               // MessageBox.Show("Employee {0} Removed From The Database successfully", em.EmployeeID.ToString());
                MessageBox.Show("Order Cancelled");

            }




        }
    }
}
