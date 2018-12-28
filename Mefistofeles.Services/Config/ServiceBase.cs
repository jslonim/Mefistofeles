using Mefistofeles.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Services.Config
{
    public class ServiceBase
    {
        protected TeamRepository TeamRepository{get;set;}
        protected MatchRespository MatchRespository { get; set; }

        public ServiceBase()
        {
            TeamRepository = new TeamRepository();
            MatchRespository = new MatchRespository();
        }
    }
}
