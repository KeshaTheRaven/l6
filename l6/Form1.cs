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
            button1.Enabled = false;
        }
        void Draw (double x1, double x2, double h, Equation equation)
        {
            chart1.Series[0].Points.Clear();
            double q = x1;
            while (q < x2)
            {
                chart1.Series[0].Points.AddXY(q, a.GetValue(q));
                q += h;
            }
            Refresh();
        }
        public Equation  a;

        private void button1_Click(object sender, EventArgs e)
        {

            
            int integrator  = comboBox1.SelectedIndex;
            int func = comboBox2.SelectedIndex;

            
            double x1 = double.Parse(textBox1.Text);
            double x2 = double.Parse(textBox2.Text);
            double q = x1;
            double h = 0.1;
            
                
            
            if (func == 0)
            {
                a = new equation(1, 2, 3);
                chart1.Series[0].Points.Clear();
                
                Draw(x1, x2, h, a);
                 

            }
            else if(func == 1)
            {
               
                 a = new Cos (x1,x2);
                 Draw(x1, x2, h, a);
                 
            }
            
            if (integrator == 0)
            {
                Integrator g = new Integrator(a);
                textBox3.Text = g.Integrate(x1, x2).ToString();
            }
            else
            if (integrator == 1)
            {
                Trap g = new Trap(a);
                textBox3.Text = g.Integrate(x1, x2).ToString();
            }
            else
            if(integrator == 2)
            {
                Simpson g = new Simpson(a);
                textBox3.Text = g.Integrate(x1, x2).ToString();
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
