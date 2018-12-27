﻿using Mefistofeles.Config;
using Mefistofeles.PageObjects.DTO;
using Mefistofeles.PageObjects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mefistofeles.PageObjects.MisMarcadores
{
    public class Hockey : PageObjectBase
    {
        private string URL;
        private By matches_Hockey = By.CssSelector("li .eventView");
        private By match_Teams = By.CssSelector(".event-schedule-participants-name");
        private By match_Time = By.CssSelector(".match-time");
        private By match_Odds = By.CssSelector(".selectionOdds");

        public List<Match> GetMatchesByLeague(HockeyLeagueEnum league)
        {
            List<Match> matches = new List<Match>();
            switch (league)
            {
                case HockeyLeagueEnum.NHL:
                    URL = "https://www.betstars.com/espanol/#/ice_hockey/competitions/4719984";
                    break;
                default:
                    URL = "https://www.betstars.com/espanol/#/ice_hockey/competitions/4719984";
                    break;
            }
            browser.Navigate().GoToUrl(URL);
            WaitUntilElementClickable(match_Odds, 10);
            List<IWebElement> matches_rows = browser.FindElements(matches_Hockey).ToList();
            Thread.Sleep(1000);
            foreach (var match_row in matches_rows)
            {
                string[] matchTime = match_row.FindElement(match_Time).Text.Split(':',' ');            
                Team local = new Team(match_row.FindElements(match_Teams)[0].Text , float.Parse(match_row.FindElements(match_Odds)[0].Text));
                Team Road = new Team(match_row.FindElements(match_Teams)[1].Text, float.Parse(match_row.FindElements(match_Odds)[2].Text));         
                DateTime matchDttm = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(matchTime[0]), Convert.ToInt32(matchTime[1]), 0);
                Match match = new Match(local, Road, matchDttm, float.Parse(match_row.FindElements(match_Odds)[1].Text));

                matches.Add(match);
            }

             return matches;
        }
        
    }
}
