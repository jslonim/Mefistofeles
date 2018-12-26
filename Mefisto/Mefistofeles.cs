using Mefistofeles.Config;
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
            MMHockey games = new MMHockey();
            games.GetMatchesByLeague(HockeyLeague.NHL);
            browser.Close();
        }
    }
}
