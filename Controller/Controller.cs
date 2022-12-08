using Newtonsoft.Json;
using Project_WinForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project_WinForms.Controller
{
    internal class Controller
    {
      
        public static async Task<string> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Items/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync("AllItems");
                if (response.IsSuccessStatusCode)
                {
                    string items = await response.Content.ReadAsStringAsync();
                    return items;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return string.Empty;
        }

        public static async Task<string> GetItemById(string ItemID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Items/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                if (ItemID != null)
                {
                    var uri = Path.Combine("GetItemById", ItemID);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string item = await response.Content.ReadAsStringAsync();
                        return item;
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return string.Empty;
        }



        public static async Task<string> create(Items item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Items/");

                var json = new
                {
                    item.Name,
                    item.Price,
                    item.Quantity
                };
                var jsonItem = JsonConvert.SerializeObject(json);
                var data = new StringContent(jsonItem, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("AddItem", data);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return "Item Created Successfully.";
                }
                return "Not Created!!!";
            }
        }


        public static async Task<string> Edit(Items item)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7099/api/Items/");

            var json = new
            {
                item.ItemID,
                item.Name,
                item.Price,
                item.Quantity
            };


            var jsonItem = JsonConvert.SerializeObject(json);

            var data = new StringContent(jsonItem, Encoding.UTF8, "application/json");
            if (item.ItemID != null)
            {
                var uri = Path.Combine("UpdateItem", item.ItemID);
                var response = await client.PutAsync(uri, data);
                response.EnsureSuccessStatusCode();
               if (response.IsSuccessStatusCode)
                {
                    return "Item Updated Successfully.";    
                }
            }
            return "Not Updated!!!";
        }


        public static async Task<string> Delete(string ItemID)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7099/api/Items/");

            var uri = Path.Combine("DeleteItem", ItemID);

            var response = await client.DeleteAsync(uri);
           // response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return "Item Deleted Successfully.";
            }

            return "Item was not found!!!";
        }



        public static async Task<int> GetDailyEarnings(string Date)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                if (Date != null)
                {
                    var uri = Path.Combine("GetDailyEarnings", Date);

                    Console.WriteLine(uri);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string earning = await response.Content.ReadAsStringAsync(); ;
                        return Convert.ToInt32(earning);    
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return 0;
        }


        public static async Task<int> GetWeeklyEarnings(string Date)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (Date != null)
                {
                    var uri = Path.Combine("GetWeeklyEarnings",Date);

                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string earning = await response.Content.ReadAsStringAsync();
                        return Convert.ToInt32(earning);

                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return 0;
        }

        public static async Task<int> GetMonthlyEarnings(string Date)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (Date != null)
                {
                    var uri = Path.Combine("GetMonthlyEarnings", Date);

                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string earning = await response.Content.ReadAsStringAsync();
                        return Convert.ToInt32(earning);

                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return 0;
        }


        public static async Task<int> GetYearlyEarnings(string Date)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (Date != null)
                {
                    var uri = Path.Combine("GetYearlyEarnings", Date);

                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string earning = await response.Content.ReadAsStringAsync();
                        return Convert.ToInt32(earning);

                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return 0;
        }


        public static async Task<string> GetReceipt(string ReceiptID)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                if (ReceiptID != null)
                {
                    var uri = Path.Combine("GetReceipt", ReceiptID);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                       string receipt = await response.Content.ReadAsStringAsync();
                       return receipt;
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return string.Empty;
        }


    }
}
