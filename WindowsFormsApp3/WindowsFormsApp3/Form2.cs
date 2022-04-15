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

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        //SqlConnection conn = new SqlConnection("Data Source=NT00938; Initial Catalog=deneme; User Id=zeki.kose;");

        public Form2()
        {
            InitializeComponent();
        }

        protected void Sign_in()
        {
            string sorgu = "select * from Users where username=@user and password=@pass";
            con = new SqlConnection("server=NT00938; Initial Catalog=login;Integrated Security=true");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", txtUsername.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
                //Diğer formumu açabilmem için o formun classından nesne türetiyorum.
                Form1 frm = new Form1();
                //Show metodu ile nesne olarak türettiğim ikinci formumu açıyorum.
                frm.Show();
                //Bu mevcut formu kapatıyorum.
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            con.Close();

        }



        private void btnSignin_Click(object sender, EventArgs e)
        {
            Sign_in();

            //if(txtUsername.Text == "zeki" && txtPassword.Text == "123")
            //{
            //    MessageBox.Show("Entry Succes ");

            //    //Diğer formumu açabilmem için o formun classından nesne türetiyorum.
            //    Form1 frm = new Form1();
            //    //Show metodu ile nesne olarak türettiğim ikinci formumu açıyorum.
            //    frm.Show();
            //    //Bu mevcut formu kapatıyorum.
            //    this.Hide();


            //}
            //else
            //{
            //    MessageBox.Show("Eror!");
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
