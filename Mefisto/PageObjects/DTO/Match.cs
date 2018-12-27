using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.PageObjects.DTO
{
    public class Match
    {
        public Team Local { get; set; }
        public Team Road { get; set; }
        public DateTime MatchDttm { get; set; }
        public float TieOdds{get;set;}
        public string Pick { get; set; }

        public Match(Team local, Team road, DateTime matchDttm,float tieOdds = 0)
        {
            Local = local;
            Road = road;
            MatchDttm = matchDttm;
            TieOdds = tieOdds;
        }
    }
}
