using Newtonsoft.Json;
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

namespace Project_WinForms
{
    public partial class AllItems : Form
    {
        public AllItems()
        {
            InitializeComponent();
            listView1.View = View.Details;
            this.listView1.GridLines = true;
            listView1.Columns.Add("Name", 110);
            listView1.Columns.Add("Price", 80);
            listView1.Columns.Add("Quantity", 80);
            listView1.FullRowSelect = true;

          
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void AllItems_Load(object sender, EventArgs e)
        {
            var response = await Controller.Controller.GetAll();
            if (response != null)
            {
                List<Items> item = JsonConvert.DeserializeObject<List<Items>>(response);
                foreach (Items i in item)
                {
                    string[] arr = new string[3];
                    ListViewItem item1;
                    arr[0] = i.Name;
                    arr[1] = Convert.ToString((i.Price));
                    arr[2] = Convert.ToString((i.Quantity));
                    item1 = new ListViewItem(arr);
                    listView1.Items.Add(item1);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
