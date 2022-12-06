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
        }

        private async void Receipt_Load(object sender, EventArgs e)
        {
            if(receiptid != null)
            {
                var response = await Controller.Controller.GetReceipt(this.receiptid);
                if (response != null)
                {
                    List<Receipt> item = JsonConvert.DeserializeObject<List<Receipt>>(response);
                    foreach (Receipt i in item)
                    {
                        MessageBox.Show(i.Name);                           
                    }
                }
            }
        }
          

    }
}

