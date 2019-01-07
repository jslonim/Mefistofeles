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
        private By matchHeader = By.CssSelector(".cmg_matchup_header_team_names");
        private By teamWinPercentages = By.CssSelector(".cmg_matchup_list_odds_value");
        private By matchWinner = By.CssSelector(".cmg_matchup_list_winner");
        private By matchStatus = By.CssSelector(".cmg_matchup_list_status");
        private By standingRows = By.CssSelector("tr");
        private By standingCells = By.CssSelector("td");


        public List<Match> FillCoversPercentages(List<Match> matches, SportsEnum sport)
        {
            string URL = "https://www.covers.com/sports/{1}/matchups";
            URL = URL.Replace("{1}", sport.ToString());
            browser.Navigate().GoToUrl(URL);
            WaitForPageLoad(30);

            foreach (var match in matches)
            {
                IWebElement box = browser.FindElements(gameBoxes)
                    .First(x => match.Local.Name.Trim().Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at", "vs" }, StringSplitOptions.None)[0].Trim())
                             || match.Local.Name.Trim().Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at", "vs" }, StringSplitOptions.None)[1].Trim())
                             || match.Road.Name.Trim().Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at", "vs" }, StringSplitOptions.None)[0].Trim())
                             || match.Road.Name.Trim().Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at", "vs" }, StringSplitOptions.None)[1].Trim())
                           );

                int[] percentages = box.FindElements(teamWinPercentages).Select(x => x.Text != "-" ? Convert.ToInt32(x.Text.Replace('%', ' ')) : 0).ToArray();

                match.Road.CoversWinPercentage = percentages[0];
                match.Local.CoversWinPercentage = percentages[1];
            }
            return matches;
        }

        public List<Match> FillMatchesResults(List<Match> matches)
        {
            string URL = "https://www.covers.com/sports/{1}/matchups";
            URL = URL.Replace("{1}", matches[0].Sport);
            URL = URL + "?selectedDate=" + matches[0].MatchDttm.Date.ToString("yyyy-MM-dd");
            browser.Navigate().GoToUrl(URL);
            WaitForPageLoad(30);

            foreach (var match in matches)
            {
                IWebElement box = browser.FindElements(gameBoxes)
                    .First(x => match.Local.Name.Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at", "vs" }, StringSplitOptions.None)[0].Trim())
                             || match.Local.Name.Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at", "vs" }, StringSplitOptions.None)[1].Trim())
                             || match.Road.Name.Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at", "vs" }, StringSplitOptions.None)[0].Trim())
                             || match.Road.Name.Contains(x.FindElement(matchHeader).Text.Split(new string[] { "at", "vs" }, StringSplitOptions.None)[1].Trim())
                           );

                string winner = box.FindElement(matchWinner).GetAttribute("className").Split(' ')[0];
                match.Result = winner.Contains("home") ? match.Local.Name : match.Road.Name;
                match.AfterTime = box.FindElement(matchStatus).Text == "Final" ? false : true;
            }
            return matches;
        }

        public List<Match> FillStandings(List<Match> matches, SportsEnum sport)
        {
            string URL = "https://www.covers.com/Sports/{1}/standings/conference";
            
            URL = URL.Replace("{1}", sport.ToString());
            browser.Navigate().GoToUrl(URL);
            WaitForPageLoad(30);

            foreach (var match in matches)
            {
                IWebElement rowLocal = browser.FindElements(standingRows)
                .First(x => match.Local.Name.Contains(x.FindElements(standingCells)[1].Text.Trim()));

                IWebElement rowRoad = browser.FindElements(standingRows)
                .First(x => match.Road.Name.Contains(x.FindElements(standingCells)[1].Text.Trim()));

                match.Local.Standing = Convert.ToInt32(rowLocal.FindElements(standingCells)[0].Text);
                match.Road.Standing = Convert.ToInt32(rowRoad.FindElements(standingCells)[0].Text);
            }

            return matches;
        }
    }
}
