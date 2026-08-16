using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eish
{

    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost\\MSSQLSERVER01;Initial Catalog=MediFlow_2;Integrated Security=True;Trust Server Certificate=True");

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string pname = edtName.Text;
                string surname = edtSurname.Text;
                string gender = cmbGender.Text;
                string id = edtID.Text;
                Int64 contact = Convert.ToInt64(edtContact.Text);
                string bloodtype = edtBT.Text;
                string address = edtAddress.Text;
                string notes = edtNotess.Text;
                int age = Convert.ToInt32(edtAge.Text);
                string mc = edtMC.Text;
                string pl = edtPL.Text;

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "insert into table_1 values('" + id + "','" + pname + "','" + surname + "', '" + age + "','" + contact + "','" + gender + "''" + bloodtype + "','" + mc + "','" + pl + "','" + notes + "')";
                SqlDataAdapter sd = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                sd.Fill(dt);
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again");
            }

            MessageBox.Show("Data saved");
            edtID.Clear();
            edtName.Clear();
            edtSurname.Clear();
            edtAge.Clear();
            edtContact.Clear();
            cmbGender.ResetText();
            edtBT.Clear();
            edtMC.Clear();
            edtPL.Clear();
            edtNotess.Clear();
                
              

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
