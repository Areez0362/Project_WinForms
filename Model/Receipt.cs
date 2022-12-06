﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_WinForms.Model
{
    internal class Receipt
    {
        public string? ReceiptID { get; set; }
        public int TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public string? ItemID { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
