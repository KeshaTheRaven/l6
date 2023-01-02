using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l6
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        Equation a;
        
       

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            a = new equation(1,2,3);
            chart1.Series[0].Points.Clear();
            double x1 = double.Parse(textBox1.Text);
            double x2 = double.Parse(textBox2.Text);
            double h = 0.1;
            while (x1 <= x2)
            {
                chart1.Series[0].Points.AddXY(x1, a.GetValue(x1));
                x1 += h;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
