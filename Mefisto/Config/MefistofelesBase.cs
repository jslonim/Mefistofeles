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
        public TeamService TeamService { get; set; }
        //public MatchService MatchService { get; set; }

        public MefistofelesBase()
        {
            TeamService = new TeamService();
            //MatchRespository = new MatchRespository();
        }
    }
}
