using Mefistofeles.Config;
using Mefistofeles.PageObjects.DTO;
using Mefistofeles.PageObjects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.PageObjects.MisMarcadores
{
    public class MMHockey : PageObjectBase
    {
        private string URL;
        private By matches_Hockey = By.CssSelector("li .eventView");
        private By match_Teams = By.CssSelector(".event-schedule-participants-name");
        private By match_Time = By.CssSelector(".match-time");
        private By match_Odds = By.CssSelector(".selectionOdds");

        public List<HockeyMatch> GetMatchesByLeague(HockeyLeague league)
        {
            List<HockeyMatch> matches = new List<HockeyMatch>();
            switch (league)
            {
                case HockeyLeague.NHL:
                    URL = "https://www.betstars.com/espanol/#/ice_hockey/competitions/4719984";
                    break;
                default:
                    URL = "https://www.betstars.com/espanol/#/ice_hockey/competitions/4719984";
                    break;
            }
            browser.Navigate().GoToUrl(URL);
            WaitUntilElementClickable(match_Odds, 10);
            List<IWebElement> matches_rows = browser.FindElements(matches_Hockey).ToList();
            foreach (var match_row in matches_rows)
            {
                WaitUntilElementClickable(matches_Hockey, 10);
                string[] matchTime = match_row.FindElement(match_Time).Text.Split(':',' ');            
                Team local = new Team(match_row.FindElements(match_Teams)[0].Text , float.Parse(match_row.FindElements(match_Odds)[0].Text));
                Team visiting = new Team(match_row.FindElements(match_Teams)[1].Text, float.Parse(match_row.FindElements(match_Odds)[2].Text));         
                DateTime matchDttm = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(matchTime[0]), Convert.ToInt32(matchTime[1]), 0);
                HockeyMatch match = new HockeyMatch(local, visiting, matchDttm, float.Parse(match_row.FindElements(match_Odds)[1].Text));

                matches.Add(match);
            }

             return matches;
        }
        
    }
}
