using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlipKartWebSite.Drivers;
using FlipKartWebSite.Pages;
using OpenQA.Selenium;
using FlipKartWebSite.Utilities;

namespace FlipKartWebSite.TestClasses
{

    [TestFixture]
    public class FlipkartTest
    {
        public IWebDriver _driver;

        private ProductsPage _product;


        [OneTimeSetUp]
        public void SetUp()
        {
            _driver =Driver.GetDriver();
            
        }


        [Test,Order(1)]
        [Description("Verify Product Items under Header -Top Deals (catergory handled dynamically)")]
        public void VerifyProductItemsBycategory()
        {
            _product= new ProductsPage(_driver);

            _product.NavigateUrl();

            _product.PrintProductListUnderEachcategory();
        }

        //This will handle all the categories based on the test data provided in Json file

        [Test,TestCaseSource(typeof(JsonDataReader),nameof(JsonDataReader.GetCategorylist),new object[] {"ConfigData.json"})]
        [Description("Verify Product Items under Header -category Name read from Json")]
        public void VerifyProductItemsBycategoryUsingDataReader(string category)
        {
            _product = new ProductsPage(_driver);

            _product.NavigateUrl();

            _product.PrintProductListUnderEachcategory_New(category);
        }
















        //[Test]
        //[Description("Verify Product Items under Header -Top delas")]
        //public void SearchProductListByCategory()
        //{
        //    _product = new ProductsPage(_driver);
        //    _product.NavigateUrl();

        //    var _categoryItemCounts = _product.GetCategoryItemsList_new();

        //    if (_categoryItemCounts.Count > 0)
        //    {

        //        foreach (var kvp in _categoryItemCounts)
        //        {
        //           //string _header=  kvp.Key;

        //            //List<string> productItems = kvp.Value;

        //            Console.WriteLine($"Header :{kvp.Key},Total Items: {kvp.Value.Count}");


        //            foreach(var item in kvp.Value)
        //            {
        //                Console.WriteLine($"  --> {item}");
        //            }

        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine(" No Product Items Availble");
        //        Assert.Fail();
        //    }

        //}

        //trying for fetching all the catergory names dynamically 
        //[Test]
        //public void VerifyProducts()
        //{
        //    _product = new ProductsPage(_driver);
        //    _product.NavigateUrl();
        //    var categoryHeaders = _product.GetCategoryHeaders();
        //    Dictionary<string, List<string>> allProducts = new Dictionary<string, List<string>>();

        //    foreach (var header in categoryHeaders)
        //    {
        //        string categoryName = header.Text.Trim();
        //        var products = _product.GetProductsByCategory(header);
        //        allProducts[categoryName] = products;
        //    }

        //    foreach (var entry in allProducts)
        //    {
        //        Console.WriteLine($"Category: {entry.Key}");
        //        foreach (var product in entry.Value)
        //        {
        //            Console.WriteLine($" - {product}");
        //        }
        //    }
        //}


        [OneTimeTearDown]
        public void CleanUp()
        {
            _driver.Dispose();
        }
    }
}
