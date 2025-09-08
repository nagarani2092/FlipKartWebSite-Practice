using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace FlipKartWebSite.Drivers
{

   
    public class Driver
    {
        public static IWebDriver _driver;
       
       public static IWebDriver GetDriver()
        {
            if(_driver == null )
            {
                _driver= new EdgeDriver();
                _driver.Manage().Window.Maximize();
            }
            return _driver;
        }



        
        public static void QuitDriver()
        {
            if (_driver != null)
            { 
                _driver.Quit();
            }

        }
        
    }
}
