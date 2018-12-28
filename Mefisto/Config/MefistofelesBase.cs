using Mefistofeles.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Config
{
    public class MefistofelesBase : SeleniumBase
    {
        protected TeamService TeamService { get; set; }
        protected MatchService MatchService { get; set; }

        public MefistofelesBase()
        {
            TeamService = new TeamService();
            MatchService = new MatchService();
        }
    }
}
