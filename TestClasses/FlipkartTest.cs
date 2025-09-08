using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlipKartWebSite.Drivers;
using FlipKartWebSite.Pages;
using OpenQA.Selenium;

namespace FlipKartWebSite.TestClasses
{

    [TestFixture]
    public class FlipkartTest
    {
        private IWebDriver _driver;

        private ProductsPage _product;


        [SetUp]
        public void SetUp()
        {
            _driver =Driver.GetDriver();
            
        }

        [Test]
        [Description("Verify Product Items under Header -Top delas")]
        public void SearchProductListByCategory()
        {
            _product = new ProductsPage(_driver);
            _product.NavigateUrl();

           var _categoryItemCounts= _product.GetCategoryItemsList();

            if (_categoryItemCounts.Count > 0)
            {
                
                foreach (var kvp in _categoryItemCounts)
                {
                    Console.WriteLine($"{kvp.Key}=> {kvp.Value} items");
                }
                
            }
            else
            {
                Console.WriteLine(" No Product Items Availble");
                Assert.Fail();
            }
            
        }



        [TearDown]
        public void CleanUp()
        {
            _driver.Dispose();
        }
    }
}
