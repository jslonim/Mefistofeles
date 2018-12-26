using Mefistofeles.Config;
using Mefistofeles.PageObjects.DTO;
using Mefistofeles.PageObjects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mefistofeles.PageObjects
{
    public class SportsChatPlace : PageObjectBase
    {
        private string URL = "https://sportschatplace.com/{1}-picks/";
        By entries = By.CssSelector(".sports-a-cell");
        By entryTitle = By.CssSelector("a");

        public List<Match> FillMatchesPicks(List<Match> matchList, AmericanSportEnum sport)
        {
            URL = URL.Replace("{1}", sport.ToString());
            browser.Navigate().GoToUrl(URL);
            WaitUntilElementClickable(entries);

            foreach (var entry in browser.FindElements(entries))
            {
                string[] title = entry.FindElements(entryTitle)[0].Text.Split(new string[] { "-" , "NHL" }, StringSplitOptions.None);

            }
           

            return new List<Match>();
        }
    }
}
