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
            //Select Sport
            SportsEnum sport = SportsEnum.NHL;

            // Gets matches
            List<Match> matchList = BetStars.GetMatchesByLeague(sport);
            //Fills up expert picks
            matchList = SportsChatPlace.FillMatchesPicks(matchList, sport);
            //Fills up win percentage
            matchList = Covers.FillCoversPercentages(matchList,sport);

            browser.Close();
            Environment.Exit(0);
        }
    }
}
