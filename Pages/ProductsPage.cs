using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.Network;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipKartWebSite.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver _driver;

        private readonly IWebElement _categoryName;

        private readonly IReadOnlyCollection<IWebElement> _headerNames;
        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;

            //_productList = _driver.FindElements(By.XPath("//div[@theme='[object Object]']/following::div[contains(@class,'_3MlEpv')]//a"));


        }

        public void NavigateUrl()
        {
            _driver.Navigate().GoToUrl("https://www.flipkart.com/");
        }

        //public int GetCatergoryItemCount(string categoryName)
        //{
        //    var header = _categoryName.Text;
        //    var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

        //    var items = wait.Until(driver=>_productList);

        //    return items.Count;
        //}

        public Dictionary<string,int> GetCategoryItemsList()
        {
           var wait =  new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            var _categoryCounts = new Dictionary<string, int>();

           var _headerNames = _driver.FindElements(By.XPath("//div[@class='_3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _1i2djtb9 _1i2djt0 _1i2djt9x _1i2djt7o _1i2djt36 _1i2djt5f _1i2djt36 _1i2djt5f']"));

            foreach(var header in _headerNames)
            {
               string _headerText=  header.Text.Trim();

                // var _items=  wait.Until(driver => _driver.FindElements(By.XPath($"//div[contains,_3U-Vxu') and contains(text(),'{_headerText}')]/following-sibling::div//a")));

                var _items = wait.Until(driver => _driver.FindElements(By.XPath($"//div[@class='_3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _1i2djtb9 _1i2djt0 _1i2djt30']")));
                _categoryCounts[_headerText] = _items.Count;
            }
            return _categoryCounts;

        }

    }
}
