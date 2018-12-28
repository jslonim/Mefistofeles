using Mefistofeles.Config;
using Mefistofeles.PageObjects.Utils;
using OpenQA.Selenium;
using Repositories.DTO;
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
        By expert = By.CssSelector(".bg-blue");

        public List<Match> FillMatchesPicks(List<Match> matchList, SportsEnum sport)
        {
            List<string> entriesLinks = new List<string>();
            List<Match> existingMatches = new List<Match>();
            URL = URL.Replace("{1}", sport.ToString());
            browser.Navigate().GoToUrl(URL);
            WaitForPageLoad(20);

            foreach (var entry in browser.FindElements(entries))
            {
                string[] title = entry.FindElements(entryTitle)[0].Text.Split(new string[] { "-", "NHL", "NBA", "NFL" , "MBL" , "Soccer" }, StringSplitOptions.None);
                title[0] = title[0].Trim();
                title[1] = title[1].Trim();
                matchList[0].MatchDttm.Date.ToString("MM/dd/yy");
                bool matchExsit = matchList.Any(x => title[0].Contains(x.Local.Name) && title[0].Contains(x.Road.Name) && title[1] == x.MatchDttm.Date.ToString("MM/dd/yy"));

                if (matchExsit)
                {
                    entriesLinks.Add(entry.FindElements(entryTitle)[0].GetAttribute("href"));
                    existingMatches.Add(matchList.First(x => title[0].Contains(x.Local.Name) && title[0].Contains(x.Road.Name) && title[1] == x.MatchDttm.Date.ToString("MM/dd/yy")));
                }
            }

            foreach (var link in entriesLinks)
            {
                browser.Navigate().GoToUrl(link);
                string[] title = browser.FindElements(articleTitle)[0].Text.Split(new string[] { "-", "NHL", "NBA", "NFL", "MBL", "Soccer" }, StringSplitOptions.None);
                title[0] = title[0].Trim();
                title[1] = title[1].Trim();
                WaitForPageLoad(20);

                if (existingMatches.Any(x => title[0].Contains(x.Local.Name) && title[0].Contains(x.Road.Name) && title[1] == x.MatchDttm.Date.ToString("MM/dd/yy")))
                {
                    var existingmatch = existingMatches.Single(x => title[0].Contains(x.Local.Name) && title[0].Contains(x.Road.Name) && title[1] == x.MatchDttm.Date.ToString("MM/dd/yy"));
                    existingmatch.Pick = browser.FindElement(matchPick).Text;
                    existingmatch.Expert = browser.FindElement(expert).Text.Split(new string[] { "'" }, StringSplitOptions.None)[0].ToLower();
                    existingmatch.Sport = sport.ToString();
                }
            }
            return existingMatches;
        }
    }
}
