using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using RestSharp;

namespace ShortenUrlServiceTest
{
    [TestClass]
    public class ShortenUrlTests
    { 
        ShortenUrlTests()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(ConfigurationManager.AppSettings["ShortenUrlBase"]);

        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
