using System;
using System.Net.Http;

namespace CurrencyTest
{
    class Program
    {
        private const string URL = "https://bananabudget.azurewebsites.net/?startDate=10-12-2017&numberOfDays=20";
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);

            HttpResponseMessage messge = client.GetAsync(URL).Result;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }
        }
    }
}
