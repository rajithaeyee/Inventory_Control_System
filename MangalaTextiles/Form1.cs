
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
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(500, 500);
        }

  

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //materialSingleLineTextField1.BackColor = Color.Transparent; 

            
        }



        private void materialFlatButton1_Click_1(object sender, EventArgs e)
        {
            using (var context = new MyContext())
            {

                var E = new Employee
                {

                  F_Name = "Rajitha",
                   L_Name = "Abeyrathna",
                   User_Name = "Rajitha",
                  User_Password = "123",
                    User_Type = "Admin"

                };

                context.Employees.Add(E);
                context.SaveChanges();

                // MessageBox.Show("User Added");

                var Employee = (from em in context.Employees where em.User_Name == materialSingleLineTextField1.Text && em.User_Password == materialSingleLineTextField2.Text select em);


                if (Employee == null || Employee.ToList().Count == 0)
                {

                    MessageBox.Show("Incorrect Username or Password");


                }
                else
                {
                    
                    this.Visible = false;
                    AdminPanel ap = new AdminPanel();
                    ap.ShowDialog();

                    this.Dispose();
                    //Console.Write("xxxxx");
                    //this.Visible = false;

                    // this.Dispose();



                }



                //System.Diagnostics.Debug.WriteLine(Employee.ElementType);
                //System.Diagnostics.Debug.WriteLine(Employee.Expression);
                //System.Diagnostics.Debug.WriteLine(Employee);





            }
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Text = "";
            
            
        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField2.Text = "";
            materialSingleLineTextField2.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }
    }
}
