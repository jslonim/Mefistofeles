using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.PageObjects.DTO
{
    public class HockeyMatch
    {
        public Team Local { get; set; }
        public Team Visiting { get; set; }
        public DateTime MatchDttm{get;set;}


        public HockeyMatch(Team local, Team visiting, DateTime matchDttm)
        {
            Local = local;
            Visiting = visiting;
            MatchDttm = matchDttm;
        }
    }
}
