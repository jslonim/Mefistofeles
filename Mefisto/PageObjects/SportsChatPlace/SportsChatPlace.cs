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
        By matchPick = By.CssSelector("h3.block");
        By articleTitle = By.CssSelector(".clearfix h1");

        public List<Match> FillMatchesPicks(List<Match> matchList, AmericanSportEnum sport)
        {
            List<string> entriesLinks = new List<string>();
            URL = URL.Replace("{1}", sport.ToString());
            browser.Navigate().GoToUrl(URL);
            WaitForPageLoad(20);

            foreach (var entry in browser.FindElements(entries))
            {
                string[] title = entry.FindElements(entryTitle)[0].Text.Split(new string[] { "-", "NHL" }, StringSplitOptions.None);
                title[0] = title[0].Trim();
                title[1] = title[1].Trim();
                matchList[0].MatchDttm.Date.ToString("MM/dd/yy");
                bool matchExsit = matchList.Any(x => title[0].Contains(x.Local.Name) && title[0].Contains(x.Road.Name) && title[1] == x.MatchDttm.Date.ToString("MM/dd/yy"));

                if (matchExsit)
                {
                    entriesLinks.Add(entry.FindElements(entryTitle)[0].GetAttribute("href"));
                }
            }

            foreach (var link in entriesLinks)
            {
                browser.Navigate().GoToUrl(link);  
                string[] title = browser.FindElements(articleTitle)[0].Text.Split(new string[] { "-", "NHL" }, StringSplitOptions.None);
                title[0] = title[0].Trim();
                title[1] = title[1].Trim();
                WaitForPageLoad(20);

                if (matchList.Any(x => title[0].Contains(x.Local.Name) && title[0].Contains(x.Road.Name) && title[1] == x.MatchDttm.Date.ToString("MM/dd/yy")))
                {
                    matchList.First(x => title[0].Contains(x.Local.Name) && title[0].Contains(x.Road.Name) && title[1] == x.MatchDttm.Date.ToString("MM/dd/yy")).Pick = browser.FindElement(matchPick).Text;
                }
            }

            return matchList;
        }
    }
}
