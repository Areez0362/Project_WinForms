using Project_WinForms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_WinForms
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Items tmp = new Items();
            tmp.Name = textBox2.Text;
            tmp.Price = Convert.ToInt32(textBox3.Text);
            tmp.Quantity = Convert.ToInt32(textBox4.Text);
            var response = await Controller.Controller.create(tmp);
            MessageBox.Show(response.ToString());
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
