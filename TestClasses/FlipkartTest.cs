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
            _product = new ProductsPage(_driver);
            _product.NavigateUrl();

        }


        [Test,Order(1)]
        [Description("Verify Product Items under Header -Top Deals (catergory handled dynamically)")]
        public void VerifyProductItemsBycategory()
        {

            _product.PrintProductListUnderEachcategory();
        }

        //This will handle all the categories based on the test data provided in Json file

        [Test,TestCaseSource(typeof(JsonDataReader),nameof(JsonDataReader.GetCategorylist),new object[] {"ConfigData.json"})]
        [Description("Verify Product Items under Header -category Name read from Json")]
        public void VerifyProductItemsBycategoryUsingDataReader(string categoryName)
        {

            _product.PrintProductListUnderEachCategoryName(categoryName);
        }

        
        [OneTimeTearDown]
        public void CleanUp()
        {
            _driver.Dispose();
        }
    }
}
