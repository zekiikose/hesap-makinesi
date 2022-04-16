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
        string infocity;

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
            string ekle = "INSERT INTO Users (Name,Surname,Username,Password,Sex,City) values (@Name,@Surname,@Username,@Password,@Sex,@City)";
            SqlCommand komut = new SqlCommand();
            komut = new SqlCommand(ekle, con);
            con.Open();
            komut.Parameters.AddWithValue("@Name", txtName.Text);
            komut.Parameters.AddWithValue("@Surname", txtSurname.Text);
            komut.Parameters.AddWithValue("@Username", txtUsername2.Text);
            komut.Parameters.AddWithValue("@Password", txtPassword2.Text);
            komut.Parameters.AddWithValue("@Sex", sex);
            komut.Parameters.AddWithValue("@City", infocity);
            komut.ExecuteNonQuery();
            con.Close();
            txtName.Text = "";
            txtSurname.Text = "";
            txtUsername2.Text = "";
            txtPassword2.Text = "";
            MessageBox.Show("Succes");

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
            if (txtName.Text =="")
            {
                labelControl3.Visible = true;
            }
            else
            {
                labelControl3.Visible = false;
            }
            if (txtSurname.Text == "")
            {
                labelControl4.Visible = true;
            }
            else
            {
                labelControl4.Visible = false;
            }
            if (txtUsername2.Text == "")
            {
                labelControl1.Visible = true;
            }
            else
            {
                labelControl1.Visible = false;
            }
            if (txtPassword2.Text == "")
            {
                labelControl2.Visible = true;
            }
            else
            {
                labelControl2.Visible = false;
            }
            if (labelControl1.Visible ==true || labelControl2.Visible==true || labelControl3.Visible==true || labelControl4.Visible==true || labelControl5.Visible==true )
            {
                MessageBox.Show("* ile işaretli yerleri doldurun");
            }
            else
            {
                Register();
            }
            

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
            //labelControl1.Visible = false;
            //labelControl2.Visible = false;
            //labelControl3.Visible = false;
            //labelControl4.Visible = false;



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
            
            var deger = comboBox1.SelectedIndex;

                string sorgu = "select sehir from iller where id=@id";
                con = new SqlConnection("server=NT00938; Initial Catalog=login;Integrated Security=true");
                cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@id", deger+1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //lblsehir.Text = dr["sehir"].ToString();
                    infocity = dr["sehir"].ToString();
            }
            
        }

        private void OrtakTxtBox(object sender, EventArgs e)
        {
            if (txtName.Text !="")
            {
                //labelControl1.Visible = false;
                //labelControl2.Visible = false;  
                //labelControl3.Visible = false;
                //labelControl4.Visible = false;
            }
            else
            {
                //MessageBox.Show("Bu alanı boş geçemezsiniz");
                //labelControl1.Visible = true;
                //labelControl2.Visible = true;
                //labelControl3.Visible = true;
                //labelControl4.Visible = true;
            }
        }

        private void Ortaklbl(object sender, EventArgs e)
        {
            //labelControl1.Visible=false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //if (txtName.Text != "")
            //{
            //    labelControl3.Visible = false;
            //}
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            //if (txtSurname.Text != "")
            //{
            //    labelControl4.Visible = false;
            //}
        }

        private void txtUsername2_TextChanged(object sender, EventArgs e)
        {
            //if (txtUsername2.Text != "")
            //{
            //    labelControl1.Visible = false;
            //}
        }

        private void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            //if (txtPassword2.Text != "")
            //{
            //    labelControl2.Visible = false;
            //}
        }
    }
}
