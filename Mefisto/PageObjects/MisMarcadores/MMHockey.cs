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
        private string URL = "https://www.cbssports.com/nhl/schedule/";
        private By matches_NHL = By.XPath("//tr[@class='TableBase-bodyTr   ']");

        public void GetMatchesByLeague(HockeyLeague league)
        {
            By leagueLocator;
            List<HockeyMatch> matches = new List<HockeyMatch>();
            switch (league)
            {
                case HockeyLeague.NHL:
                    leagueLocator = matches_NHL;
                    break;
                default:
                    leagueLocator = matches_NHL;
                    break;
            }
            browser.Navigate().GoToUrl(URL);
            WaitUntilElementVisible(leagueLocator);
            List<IWebElement> matches_rows = browser.FindElements(leagueLocator).ToList();

            foreach (var match_row in matches_rows)
            {               
                List<IWebElement> match_cells = match_row.FindElements(By.CssSelector("td")).ToList();
                string[] matchTime = match_cells[2].Text.Split(':', ' ');
                Team local = new Team(match_cells[1].Text);
                Team visiting = new Team(match_cells[0].Text);

                DateTime matchDttm = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, matchTime[2] == "pm" ? Convert.ToInt32(matchTime[0]) + 12 : (Convert.ToInt32(matchTime[0])) , Convert.ToInt32(matchTime[1]) , 0);
                matchDttm = MefistofelesUtils.ConvertToArgentinaTime(matchDttm);

                HockeyMatch match = new HockeyMatch(local, visiting, matchDttm);

                matches.Add(match);
            }
        }
        
    }
}
