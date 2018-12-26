using Mefistofeles.Config;
using Mefistofeles.PageObjects;
using Mefistofeles.PageObjects.DTO;
using Mefistofeles.PageObjects.MisMarcadores;
using Mefistofeles.PageObjects.Utils;
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
            Hockey games = new Hockey();
            SportsChatPlace scp = new SportsChatPlace();

            List<Match> matchList = games.GetMatchesByLeague(HockeyLeagueEnum.NHL);
            scp.FillMatchesPicks(matchList,AmericanSportEnum.NHL);

            browser.Close();
        }
    }
}
