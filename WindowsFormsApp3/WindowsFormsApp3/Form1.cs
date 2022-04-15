using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        bool optDurum=false;
        double sonuc = 0;
        string opt = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void ortak(object sender, EventArgs e)
        {
            if(textBox1.Text == "0" || optDurum)
                textBox1.Clear();  
            optDurum= false;
            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
        }

        private void opthesap(object sender, EventArgs e)
        {
            optDurum= true;
            Button btn = (Button)sender;  
            string yeniOpt= btn.Text;

            label1.Text = label1.Text + " " + textBox1.Text + " " + yeniOpt; 
            switch(opt)
            {
                case "+": textBox1.Text = (sonuc+ double.Parse(textBox1.Text)).ToString(); break;
                case "-": textBox1.Text = (sonuc - double.Parse(textBox1.Text)).ToString(); break;
                case "*": textBox1.Text = (sonuc * double.Parse(textBox1.Text)).ToString(); break;
                case "/": textBox1.Text = (sonuc / double.Parse(textBox1.Text)).ToString(); break;
            }

            sonuc = double.Parse(textBox1.Text);
            textBox1.Text=sonuc.ToString();
            opt = yeniOpt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = "";
            opt = "";
            sonuc = 0;
            optDurum = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            optDurum = true;
            switch (opt)
            {
                case "+": textBox1.Text = (sonuc + double.Parse(textBox1.Text)).ToString(); break;
                case "-": textBox1.Text = (sonuc - double.Parse(textBox1.Text)).ToString(); break;
                case "*": textBox1.Text = (sonuc * double.Parse(textBox1.Text)).ToString(); break;
                case "/": textBox1.Text = (sonuc / double.Parse(textBox1.Text)).ToString(); break;
            }

            sonuc = double.Parse(textBox1.Text);
            textBox1.Text = sonuc.ToString();
            opt = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0,";
            }
            else if (optDurum == true)
            {
                textBox1.Text = "0";
            }
            else if (optDurum == false)
            {
                textBox1.Text += ",";
            }
            //else 
            //{
            //    textBox1.Text += ",";
            //}
            //if(textBox1.Text.Contains(","))
            //{
            //    textBox1.Text += ",";
            //}
            optDurum=false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.OrangeRed;
        }
    }
}
