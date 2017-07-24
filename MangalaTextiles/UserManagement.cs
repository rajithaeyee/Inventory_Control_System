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
    public partial class UserManagement : MaterialForm
    {
        public UserManagement()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }



        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UserManagement_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            //Add new Employee 
            string UserType;

            if (materialRadioButton1.Checked == true)
            {

                UserType = "Admin";

            }
            else
            {

                UserType = "Non-Admin";

            }


            using (var context = new MyContext())
            {

                var Em = new Employee
                {
                    F_Name = materialSingleLineTextField2.Text,
                    L_Name = materialSingleLineTextField3.Text,
                    User_Name = materialSingleLineTextField4.Text,
                    User_Password = materialSingleLineTextField5.Text,
                    User_Type = UserType


                };

                context.Employees.Add(Em);
                context.SaveChanges();

                var employee = (from em in context.Employees where em.User_Name == materialSingleLineTextField4.Text && em.User_Password == materialSingleLineTextField5.Text select em).ToList<Employee>();

                foreach (var empl in employee)
                {

                    materialSingleLineTextField1.Text = empl.EmployeeID.ToString();


                }

                MessageBox.Show("User Added Successfully");


            }

        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            //Update an Employee

            int UserID = Convert.ToInt32(materialSingleLineTextField1.Text);

            using (var context = new MyContext())
            {

                var empl = context.Employees.Find(UserID);

                empl.F_Name = materialSingleLineTextField3.Text;
                empl.User_Name = materialSingleLineTextField4.Text;
                empl.User_Password = materialSingleLineTextField5.Text;

                


                if (materialRadioButton1.Checked == true)
                {

                    empl.User_Type = "Admin";

                }
                else
                {

                    empl.User_Type = "Non-Admin";
                }

                context.SaveChanges();



            }

        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            //Delete an Employee

            int UserID = Convert.ToInt32(materialSingleLineTextField1.Text);


            using (var context = new MyContext())
            {

                Employee em = new Employee
                {

                    EmployeeID = UserID

                };

                context.Employees.Attach(em);
                context.Employees.Remove(em);
                context.SaveChanges();

                MessageBox.Show("Employee {0} Removed From The Database successfully", em.EmployeeID.ToString());

            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            // Search An Employee

            int userID = Convert.ToInt32(materialSingleLineTextField6.Text);

            using (var context = new MyContext())
            {


                var empl = context.Employees.Find(userID);

                materialSingleLineTextField1.Text = empl.EmployeeID.ToString();
                materialSingleLineTextField2.Text = empl.F_Name;
                materialSingleLineTextField3.Text = empl.L_Name;
                materialSingleLineTextField4.Text = empl.User_Name;
                materialSingleLineTextField5.Text = empl.User_Password;
                materialSingleLineTextField5.PasswordChar='*';
                if (empl.User_Type == "Admin")
                {

                    materialRadioButton1.Checked = true;

                }
                else
                {

                    materialRadioButton2.Checked = true;

                }


            }

        }
    }
}
