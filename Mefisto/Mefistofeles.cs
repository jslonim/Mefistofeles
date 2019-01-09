using Mefistofeles.Config;
using Mefistofeles.PageObjects;
using Mefistofeles.PageObjects.Utils;
using Mefistofeles.Services;
using Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles
{
    public class Mefistofeles : MefistofelesBase
    {
        public void Start()
        {
            TryRetry(() => ColectAndBetMatches(SportsEnum.NHL));
            TryRetry(() => UpdatesLastMatches(SportsEnum.NHL));
            TryRetry(() => ColectAndBetMatches(SportsEnum.NBA));
            TryRetry(() => UpdatesLastMatches(SportsEnum.NBA));


            //Close program
            browser.Quit();
        }

        private object ColectAndBetMatches(SportsEnum sport)
        {
            //Gets matches
            List<Match> matchList = BetStars.GetMatchesByLeague(sport);
            matchList = SportsChatPlace.FillMatchesPicks(matchList, sport);
            matchList = Covers.FillCoversPercentages(matchList, sport);
            matchList = Covers.FillStandings(matchList, sport);
            BetStars.BetMatches(matchList,sport);

            //Save in DB
            MatchService.InsertMatches(matchList);

            return null;
        }

        private object UpdatesLastMatches(SportsEnum sport)
        {
            ////Gets yesterday's matchs to complete scores
            List<Match> matchList = MatchService.GetMatchesByDate(DateTime.Now.AddDays(-1), sport.ToString());
            matchList = Covers.FillMatchesResults(matchList);

            //Save in DB
            MatchService.UpdateMatchesResults(matchList);

            return null;
        }
    }
}

