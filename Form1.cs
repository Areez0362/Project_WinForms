using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Project_WinForms.Controller;
using Project_WinForms.Model;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Project_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
          AllItems display = new AllItems();
          display.Show();
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter ID", "Get Item By ID", "ID_HERE");
            if (id != null)
            {
                var response = await Controller.Controller.GetItemById(id);
                if (response != null)
                {
                    Items item = JsonConvert.DeserializeObject<Items>(response);
                    MessageBox.Show("Name: "+item.Name + "\n"+"Price: "+ item.Price + "\n"+"Quantity: "+item.Quantity);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            create CreateForm = new create();
            CreateForm.Show();
                     
        }

        private void button4_Click(object sender, EventArgs e)
        {
            update UpdateForm= new update();
            UpdateForm.Show();
        }

        private async void  button5_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter ID", "Delete Item By ID", "ID_HERE");
            if (id != null)
            {
                var response = await Controller.Controller.Delete(id);
                MessageBox.Show(response.ToString());
             
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter Date", "Daily Earnings", "2022-12-01");
            if (id != null)
            {
                var response = await Controller.Controller.GetDailyEarnings(id);
                MessageBox.Show("Daily Earnings: "+response.ToString());

            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter starting day of the week:", "Weekly Earnings", "1");
            if (id != null)
            {
                var response = await Controller.Controller.GetWeeklyEarnings(id);
                MessageBox.Show("Weekly Earnings: " + response.ToString());

            }

        }

        private async void button8_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter Month Number:", "Monthly Earnings", "1");
            if (id != null)
            {
                var response = await Controller.Controller.GetMonthlyEarnings(id);
                MessageBox.Show("Monthly Earnings: " + response.ToString());

            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter Year Number:", "Yearly Earnings", "2022");
            if (id != null)
            {
                var response = await Controller.Controller.GetYearlyEarnings(id);
                MessageBox.Show("Yearly Earnings: " + response.ToString());

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Enter Receipt ID:", "Receipt", "");
            if (id != null)
            {
                Receipt receipt = new Receipt(id);
                receipt.Show();
           
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
