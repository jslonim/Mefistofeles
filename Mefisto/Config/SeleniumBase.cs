﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Config
{
    
    public class SeleniumBase
    {
        public IWebDriver browser { get; set; }

        private static IWebDriver _browser;

        protected SeleniumBase()
        {
            browser = GetBrowser();
        }

        public IWebDriver GetBrowser()
        {
            if (_browser == null)
            {
                _browser = new ChromeDriver();
            }

            return _browser;
        }

    }
}