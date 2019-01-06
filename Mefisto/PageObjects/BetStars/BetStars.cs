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
    public class BetStars : PageObjectBase
    {
        private string URL;
        private By matches_Rows;
        private By matches_Rows1 = By.CssSelector("li .eventView");
        private By matches_Rows2 = By.CssSelector("Section.afEvt");
        private By match_Teams = By.CssSelector(".event-schedule-participants-name");
        private By match_Time = By.CssSelector(".match-time");
        private By txt_UserID = By.Id("userID");
        private By txt_Password = By.Id("password");
        private By btn_Login = By.Id("loginButton");
        private By btn_Popup_Close = By.CssSelector(".previous");
        private By match_Odds;

        public List<Match> GetMatchesByLeague(SportsEnum sport)
        {
            List<Match> matches = new List<Match>();
            switch (sport)
            {
                case SportsEnum.NHL:
                    URL = "https://www.betstars.com/espanol/#/ice_hockey/competitions/4719984";
                    matches_Rows = matches_Rows1;
                    match_Odds = By.CssSelector(".selectionOdds");
                    break;
                case SportsEnum.NBA:
                    URL = "https://www.betstars.com/espanol/#/basketball/competitions/4700094";
                    matches_Rows = matches_Rows2;
                    match_Odds = By.CssSelector(".market-BAML");
                    break;
                case SportsEnum.NFL:
                    URL = "https://www.betstars.com/espanol/#/american_football/competitions/2308790";
                    matches_Rows = matches_Rows2;

                    break;
                default:
                    throw new Exception("Sport not found");
                    break;
            }
            browser.Navigate().GoToUrl(URL);
            WaitForPageLoad(20);
            WaitUntilElementClickable(match_Time);
            WaitUntilElementClickable(matches_Rows);
            Thread.Sleep(5000);

            List<IWebElement> matches_rows = browser.FindElements(matches_Rows).ToList();
            Thread.Sleep(1000);
            foreach (var match_row in matches_rows)
            {
                if (IsElementPresent(match_row,match_Time) && match_row.FindElements(match_Odds)[0].Text != "OTB" && match_row.FindElements(match_Odds)[1].Text != "OTB")
                {
                    string[] matchTime = match_row.FindElement(match_Time).Text.Split(':', ' ', '\r');
                    Team local = new Team(match_row.FindElements(match_Teams)[0].Text, Convert.ToDouble(match_row.FindElements(match_Odds)[0].Text));
                    Team road;
                    if (sport == SportsEnum.NHL)
                    {
                        road = new Team(match_row.FindElements(match_Teams)[1].Text, Convert.ToDouble(match_row.FindElements(match_Odds)[2].Text));
                    }
                    else
                    {
                        road = new Team(match_row.FindElements(match_Teams)[1].Text, Convert.ToDouble(match_row.FindElements(match_Odds)[1].Text));
                    }
                    
                    DateTime matchDttm = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(matchTime[0]), Convert.ToInt32(matchTime[1]), 0);
                    Match match = new Match(local, road, matchDttm, Convert.ToDouble(match_row.FindElements(match_Odds)[1].Text));

                    matches.Add(match);
                }
            }

            return matches;
        }

        public void Login()
        {
            User user = LoadUserAndPass();
            browser.FindElement(txt_UserID).SendKeys(user.UserName);
            browser.FindElement(txt_Password).SendKeys(user.Password);
            browser.FindElement(btn_Login).Click();
            WaitForPageLoad(20);
            WaitUntilElementClickable(match_Time);
            Thread.Sleep(5000);

        }

        public void BetMatches(List<Match> matchList)
        {
            URL = "https://www.betstars.com/espanol/#/ice_hockey/competitions/4719984";
            browser.Navigate().GoToUrl(URL);
            WaitForPageLoad(20);
            WaitUntilElementClickable(match_Time);
            Thread.Sleep(5000);

            Login();
            browser.FindElement(btn_Popup_Close).Click();

        }
    }
}
