using Mefistofeles.Config;
using Mefistofeles.PageObjects.Utils;
using OpenQA.Selenium;
using Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.PageObjects
{
    public class Covers : PageObjectBase
    {
        private By gameBoxes = By.CssSelector(".cmg_matchup_game_box");
        private By matchHeader = By.CssSelector(".cmg_matchup_header");
        private By teamWinPercentages = By.CssSelector(".cmg_matchup_list_odds_value");

        private string URL = "https://www.covers.com/sports/{1}/matchups";
        public List<Match> FillCoversPercentages(List<Match> matches, SportsEnum sport)
        {
            URL = URL.Replace("{1}", sport.ToString());
            browser.Navigate().GoToUrl(URL);
            WaitForPageLoad(20);

            foreach (var match in matches)
            {
                IWebElement box = browser.FindElements(gameBoxes)
                    .Single(x=> match.Local.Name.Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at" }, StringSplitOptions.None)[0].Trim()) 
                             || match.Local.Name.Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at" }, StringSplitOptions.None)[1].Trim())
                             || match.Road.Name.Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at" }, StringSplitOptions.None)[0].Trim())
                             || match.Road.Name.Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at" }, StringSplitOptions.None)[1].Trim())
                           );

                int[] percentages = box.FindElements(teamWinPercentages).Select(x => Convert.ToInt32(x.Text.Replace('%',' '))).ToArray();

                match.Road.CoversWinPercentage = percentages[0];
                match.Local.CoversWinPercentage = percentages[1];
                
            }
            return matches;
        }
    }
}
