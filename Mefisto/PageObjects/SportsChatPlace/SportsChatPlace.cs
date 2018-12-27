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

        public List<Match> FillMatchesPicks(List<Match> matchList, AmericanSportEnum sport)
        {
            URL = URL.Replace("{1}", sport.ToString());
            browser.Navigate().GoToUrl(URL);
            WaitUntilElementClickable(entries);

            foreach (var entry in browser.FindElements(entries))
            {
                string[] title = entry.FindElements(entryTitle)[0].Text.Split(new string[] { "-", "NHL"}, StringSplitOptions.None);
                title[0] = title[0].Trim();
                title[1] = title[1].Trim();
                matchList[0].MatchDttm.Date.ToString("MM/dd/yy");
                bool matchExsit = matchList.Any(x => title[0].Contains(x.Local.Name) && title[0].Contains(x.Road.Name) && title[1] == x.MatchDttm.Date.ToString("MM/dd/yy"));

                if (matchExsit)
                {
                    entry.FindElements(entryTitle)[0].Click();
                    WaitUntilElementClickable(matchPick,10);
                    //TODO: Poner pick en el slot de match de pick
                }
            }
            

            return new List<Match>();
        }
    }
}
