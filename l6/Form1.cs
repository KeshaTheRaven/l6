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
            button1.Enabled = true;
        }
        void Draw (double x1, double x2, double h, Equation equation)
        {
            chart1.Series[0].Points.AddXY(x1, a.GetValue(x1));
        }
        public Equation  a;

        private void button1_Click(object sender, EventArgs e)
        {

            int c  = comboBox1.SelectedIndex;
            int c2 = comboBox2.SelectedIndex;

            
            double x1 = double.Parse(textBox1.Text);
            double x2 = double.Parse(textBox2.Text);
            double q = x1;
            double h = 0.1;
            if (c2 == 0)
            {
                a = new equation(1, 2, 3);
                chart1.Series[0].Points.Clear();
                while (q < x2)
                {
                    Draw(q, x2, h, a);
                    q += h;
                }

            }
            else if(c2 == 1)
            {
               
                 a = new Cos (x1,x2);
                while (q < x2)
                {
                    Draw(q, x2, h, a);
                    q += h;
                }
            }
            
            if (c == 0)
            {
                Integrator g = new Integrator(a);
                textBox3.Text = g.Integrate(x1, x2).ToString();
            }
            else
            if (c == 1)
            {
                Trap g = new Trap(a);
                textBox3.Text = g.Integrate(x1, x2).ToString();
            }
            else
            if(c == 2)
            {
                
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int c = comboBox1.SelectedIndex;
            if (c >= 0)
            {
                button1.Enabled = true;
            }
        }
    }
}
