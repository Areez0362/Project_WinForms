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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_WinForms
{
    public partial class Receipt : Form
    {
        string? receiptid;
        public Receipt(string id)
        {
            InitializeComponent();
            this.receiptid = id;
            listView1.View = View.Details;
            this.listView1.GridLines = true;
            listView1.Columns.Add("Name", 110);
            listView1.Columns.Add("Price", 80);
            listView1.Columns.Add("Quantity", 80);
            listView1.FullRowSelect = true;
        }

        private async void Receipt_Load(object sender, EventArgs e)
        {
            if(receiptid != null)
            {
                var response = await Controller.Controller.GetReceipt(this.receiptid);
                if (response != null)
                {
                    int am = 0;
                    List<Receipts> item = JsonConvert.DeserializeObject<List<Receipts>>(response);
                    textBox1.Text = receiptid;
                    textBox2.Text = item[0].Date.ToString();
                     foreach (Receipts i in item)
                    {
                        string[] arr = new string[3];
                        ListViewItem item1;
                        arr[0] = i.Name;
                        arr[1] = Convert.ToString((i.Price));
                        am = am + (i.Price * i.Quantity);
                        arr[2] = Convert.ToString((i.Quantity));
                        item1 = new ListViewItem(arr);
                        listView1.Items.Add(item1);
                    }
                    textBox3.Text = am.ToString();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

