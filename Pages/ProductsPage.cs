using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.Network;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlipKartWebSite.Utilities;

namespace FlipKartWebSite.Pages
{
    public class ProductsPage 
    {
        private readonly IWebDriver _driver;

        //private readonly IWebElement _categoryName;

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

        public Dictionary<string, int> GetCategoryItemsList()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            var _categoryCounts = new Dictionary<string, int>();

            var _headerNames = _driver.FindElements(By.XPath("//div[@class='_3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _1i2djtb9 _1i2djt0 _1i2djt9x _1i2djt7o _1i2djt36 _1i2djt5f _1i2djt36 _1i2djt5f']"));

            foreach (var header in _headerNames)
            {
                string _headerText = header.Text.Trim();

                // var _items=  wait.Until(driver => _driver.FindElements(By.XPath($"//div[contains,_3U-Vxu') and contains(text(),'{_headerText}')]/following-sibling::div//a")));

                var _items = wait.Until(driver => _driver.FindElements(By.XPath($"//div[contains(text(),'{_headerText}'//div[@class='_3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _1i2djtb9 _1i2djt0 _1i2djt30']")));
                _categoryCounts[_headerText] = _items.Count;
            }
            return _categoryCounts;

        }
        public Dictionary<string, List<string>> GetCategoryItemsList_new()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            var _productItems = new Dictionary<string, List<string>>();

            var _headerNames = _driver.FindElements(By.XPath("//div[@class='_3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _1i2djtb9 _1i2djt0 _1i2djt9x _1i2djt7o _1i2djt36 _1i2djt5f _1i2djt36 _1i2djt5f']"));

            foreach (var header in _headerNames)
            {
                string _headerText = header.Text.Trim();

                // var _items=  wait.Until(driver => _driver.FindElements(By.XPath($"//div[contains,_3U-Vxu') and contains(text(),'{_headerText}')]/following-sibling::div//a")));

                var _items = wait.Until(driver => _driver.FindElements(By.XPath($"//div[contains(text(),'{_headerText}')]/following::div[1]//a")));

                Console.WriteLine($"Found {_items.Count} items under header : {_headerText}");

                foreach(var item in _items)
                {
                    Console.WriteLine(item.Text.Trim());
                }

                var itemNames = _items.Select(item => item.GetAttribute("innerText")?.Trim()).ToList();

                foreach (var name in itemNames)
                {
                    Console.WriteLine($"Item name are : {name}");
                }

                _productItems[_headerText] = itemNames;

            }
            return _productItems;

        }
        //this method returning category name & Product Items names with Price
        public void PrintProductListUnderEachcategory()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            var _headerNames = _driver.FindElements(By.XPath("//div[@class='_3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _1i2djtb9 _1i2djt0 _1i2djt9x _1i2djt7o _1i2djt36 _1i2djt5f _1i2djt36 _1i2djt5f']"));

            foreach (var header in _headerNames)
            {
                string _headerText = header.Text.Trim();

                var _items = wait.Until(driver => _driver.FindElements(By.XPath($"//div[contains(text(),'{_headerText}')]/following::div[1]//a")));

                var itemNames = _items.Select(item => item.GetAttribute("innerText")?.Trim()).ToList();

                Console.WriteLine($"header : {_headerText}, Total Items : {itemNames.Count}");

                foreach(var _productItems in itemNames)
                {
                    Console.WriteLine($" ---> {_productItems}");
                }

            }

        }
        public void PrintProductListUnderEachcategory_New(string category)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            //var _category = _categories.FirstOrDefault(c => c.category == CategoryName);


            var _headerName= _driver.FindElement(By.XPath($"//div[text()='{category}']"));

            var _items = wait.Until(driver => _driver.FindElements(By.XPath($"//div[contains(text(),'{category}')]/following::div[1]//a")));

            var itemNames = _items.Select(item => item.GetAttribute("innerText")?.Trim()).ToList();

            Console.WriteLine($"Category : {category}, Total Items : {itemNames.Count}");

            foreach(var _productItems in itemNames)
            {
                Console.WriteLine($" ---> {_productItems}");
            }



            //var _headerNames = _driver.FindElements(By.XPath("//div[@class='_3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _1i2djtb9 _1i2djt0 _1i2djt9x _1i2djt7o _1i2djt36 _1i2djt5f _1i2djt36 _1i2djt5f']"));

            //foreach (var header in _headerNames)
            //{
            //    string _headerText = header.Text.Trim();

            //    var _items = wait.Until(driver => _driver.FindElements(By.XPath($"//div[contains(text(),'{_headerText}')]/following::div[1]//a")));

            //    var itemNames = _items.Select(item => item.GetAttribute("innerText")?.Trim()).ToList();

            //    Console.WriteLine($"header : {_headerText}, Total Items : {itemNames.Count}");

            //    foreach (var _productItems in itemNames)
            //    {
            //        Console.WriteLine($" ---> {_productItems}");
            //    }         

        }

        public IList<IWebElement> GetCategoryHeaders()
        {
            return _driver.FindElements(By.XPath("//div[@class='_58bkzqcd _3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _58bkzqz _1i2djtb9 _1i2djt0']"));
        }



        public List<string> GetProductsByCategory(IWebElement categoryHeader)
        {
            List<string> productNames = new List<string>();

            try
            {
                
                var container = categoryHeader.FindElement(By.XPath("//ancestor::div[contains(@class,'_1AtVbE')]"));
                var productElements = container.FindElements(By.XPath(".//a[contains(@class,'IRpwTa') or contains(@class,'_4rR01T')]"));

                foreach (var product in productElements)
                {
                    string name = product.Text.Trim();
                    if (!string.IsNullOrEmpty(name))
                        productNames.Add(name);
                }
            }
            catch (NoSuchElementException) { }

            return productNames;
        }

    }
}
