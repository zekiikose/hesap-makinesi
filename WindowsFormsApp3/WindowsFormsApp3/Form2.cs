using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {

        //SqlConnection conn = new SqlConnection("Data Source=NT00938; Initial Catalog=deneme; User Id=zeki.kose;");

        public Form2()
        {
            InitializeComponent();
        }

        //protected void DatagridYenile()
        //{
        //    conn.Open();
        //    DataTable tbl = new DataTable();
        //    SqlDataAdapter adptr = new SqlDataAdapter("Select * from user ", conn);
        //    adptr.Fill(tbl);
        //    conn.Close();
            
        //}



        private void btnSignin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "zeki" && txtPassword.Text == "123")
            {
                MessageBox.Show("Entry Succes ");

                //Diğer formumu açabilmem için o formun classından nesne türetiyorum.
                Form1 frm = new Form1();
                //Show metodu ile nesne olarak türettiğim ikinci formumu açıyorum.
                frm.Show();
                //Bu mevcut formu kapatıyorum.
                this.Hide();


            }
            else
            {
                MessageBox.Show("Eror!");
            }
            

        }
    }
}
