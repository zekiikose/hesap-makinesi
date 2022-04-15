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
using System.Data.Sql;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

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
        private void Register()
        {

            string sex = "male";
            if (radioButtonMale.Checked == true)
            {
                sex = "male";
            }
            else if (radioButtonFamale.Checked == true)
            {
                sex = "famale";
            }

            con = new SqlConnection("server=NT00938; Initial Catalog=login;Integrated Security=true");
            string ekle = "INSERT INTO Users (Name,Surname,Username,Password,Sex) values (@Name,@Surname,@Username,@Password,@Sex)";
            SqlCommand komut = new SqlCommand();
            komut = new SqlCommand(ekle, con);
            con.Open();
            komut.Parameters.AddWithValue("@Name", txtName.Text);
            komut.Parameters.AddWithValue("@Surname", txtSurname.Text);
            komut.Parameters.AddWithValue("@Username", txtUsername2.Text);
            komut.Parameters.AddWithValue("@Password", txtPassword2.Text);
            komut.Parameters.AddWithValue("@Sex", sex);
            komut.ExecuteNonQuery();
            con.Close();
            txtName.Text = "";
            txtSurname.Text = "";
            txtUsername2.Text = "";
            txtPassword2.Text = "";

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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Register();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
                SqlConnection baglanti = new SqlConnection();
                baglanti.ConnectionString =" server = NT00938; Initial Catalog = login; Integrated Security = true";
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT *FROM iller";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["sehir"]);
                }
                baglanti.Close();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void or(object sender, EventArgs e)
        {
            //Visible = false;    
        }

        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i=1;
            var deger = comboBox1.SelectedIndex;

            
            
                string sorgu = "select sehir from iller where id=@id";
                con = new SqlConnection("server=NT00938; Initial Catalog=login;Integrated Security=true");
                cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@id", deger+1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblsehir.Text = dr["sehir"].ToString();
                }
            
        }
    }
}
