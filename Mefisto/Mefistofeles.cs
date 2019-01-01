using Mefistofeles.Config;
using Mefistofeles.PageObjects;
using Mefistofeles.PageObjects.Utils;
using Mefistofeles.Services;
using Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles
{
    public class Mefistofeles : MefistofelesBase
    {
        public void Start()
        {
            ColectAndBet(SportsEnum.NHL);
            ColectAndBet(SportsEnum.NBA);
            ColectAndBet(SportsEnum.NFL);

            //Close
            browser.Quit();
        }

        private void ColectAndBet(SportsEnum sport)
        {
            //Gets matches
            List<Match> matchList = BetStars.GetMatchesByLeague(sport);
            matchList = SportsChatPlace.FillMatchesPicks(matchList, sport);
            matchList = Covers.FillCoversPercentages(matchList, sport);

            //Save in DB
            MatchService.InsertMatches(matchList);

            ////Gets yesterday's matchs to complete scores
            matchList = MatchService.GetMatchesByDate(DateTime.Now.AddDays(-1), sport.ToString());
            matchList = Covers.FillMatchesResults(matchList);
            MatchService.UpdateMatchesResults(matchList);
        }
    }
}

