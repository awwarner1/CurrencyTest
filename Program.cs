using System;
using System.Net.Http;
using NUnit.Framework;

namespace CurrencyTest
{
    class Program
    {
        private const string URL = "https://bananabudget.azurewebsites.net/";

        [Test]
        public void TestWeek1()
        {
            String queryString = "?startDate=10-01-2017&numberOfDays=7";
            //Console.WriteLine("Hello World!");
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);

            HttpResponseMessage messge = client.GetAsync(URL+queryString).Result;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                Assert.AreEqual("{\"totalCost\":\"$0.25\"}", result);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestWeek2()
        {
            String queryString = "?startDate=10-07-2017&numberOfDays=7";
            //Console.WriteLine("Hello World!");
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);

            HttpResponseMessage messge = client.GetAsync(URL+queryString).Result;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                Assert.AreEqual("{\"totalCost\":\"$0.50\"}", result);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestWeek3()
        {
            String queryString = "?startDate=10-14-2017&numberOfDays=7";
            //Console.WriteLine("Hello World!");
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);

            HttpResponseMessage messge = client.GetAsync(URL+queryString).Result;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                Assert.AreEqual("{\"totalCost\":\"$0.75\"}", result);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestWeekend()
        {
            String queryString = "?startDate=10-14-2017&numberOfDays=2";
            //Console.WriteLine("Hello World!");
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);

            HttpResponseMessage messge = client.GetAsync(URL+queryString).Result;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                Assert.AreEqual("{\"totalCost\":\"$0.00\"}", result);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestTwentyDays()
        {
            String queryString = "?startDate=10-12-2017&numberOfDays=20";
            //Console.WriteLine("Hello World!");
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);

            HttpResponseMessage messge = client.GetAsync(URL+queryString).Result;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                Assert.AreEqual("{\"totalCost\":\"$2.45\"}", result);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestFullYear()
        {
            String queryString = "?startDate=01-01-2017&numberOfDays=365";
            //Console.WriteLine("Hello World!");
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);

            HttpResponseMessage messge = client.GetAsync(URL+queryString).Result;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                Assert.AreEqual("{\"totalCost\":\"$35.00\"}", result);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestFullYearPlus1()
        {
            String queryString = "?startDate=01-01-2017&numberOfDays=366";
            //Console.WriteLine("Hello World!");
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);

            HttpResponseMessage messge = client.GetAsync(URL+queryString).Result;
            string reason = messge.ReasonPhrase;
   
            Assert.AreEqual("Bad Request", reason);
        }
    }
}
