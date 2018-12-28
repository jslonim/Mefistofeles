using Mefistofeles.Config;
using Mefistofeles.PageObjects;
using Mefistofeles.PageObjects.MisMarcadores;
using Mefistofeles.PageObjects.Utils;
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

            //SportsEnum sport = SportsEnum.NHL;

            //BetStars games = new BetStars();
            //SportsChatPlace scp = new SportsChatPlace();

            //List<Match> matchList = games.GetMatchesByLeague(sport);
            //scp.FillMatchesPicks(matchList, sport);

            //browser.Close();

            Team team = new Team("Inventado", 1.2);
            Int64 cosa = TeamService.InsertTeam(team);

        }
    }
}
