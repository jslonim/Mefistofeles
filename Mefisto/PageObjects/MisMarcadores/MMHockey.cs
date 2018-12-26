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
        private string URL = "https://www.mismarcadores.com/hockey/";
        private By header_KHL = By.XPath("//table[@class='hockey' and contains(.,'KHL')]");
        private By matches_KHL = By.XPath("//table[@class='hockey' and contains(.,'KHL')]//Tbody//tr//td//span[@class='padl']"); 
        private By matches_time_KHL = By.XPath("//table[@class='hockey' and contains(.,'KHL')]//td[@class='cell_ad time']");

        public void GetMatchesByLeague(HockeyLeague league)
        {
            By leagueLocator;
            List<HockeyMatch> matches = new List<HockeyMatch>();
            int j = 0;
            switch (league)
            {
                case HockeyLeague.KHL:
                    leagueLocator = matches_KHL;
                    break;
                default:
                    leagueLocator = matches_KHL;
                    break;
            }
            browser.Navigate().GoToUrl(URL);
            WaitUntilElementVisible(leagueLocator);
            List<IWebElement> teams = browser.FindElements(leagueLocator).ToList();

            for (int i = 0; i < teams.Count; i += 2)
            {
                Team local = new Team(teams[i].Text);
                Team visiting = new Team(teams[i].Text);
                DateTime matchDttm = Convert.ToDateTime(DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " " + browser.FindElements(matches_time_KHL)[j].Text);
                HockeyMatch match = new HockeyMatch(local,visiting,matchDttm);
                matches.Add(match);
                j++;
            }
        }
        
    }
}
