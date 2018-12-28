using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTO
{
    public class Match
    {
        public Int64 Id { get; set; }
        public Team Local { get; set; }
        public Team Road { get; set; }
        public DateTime MatchDttm { get; set; }
        public double TieOdds {get;set;}
        public string Pick { get; set; }
        public string Expert { get; set; }
        public string Sport { get; set; }


        public Match(Team local, Team road, DateTime matchDttm, double tieOdds = 0)
        {
            Id = Id;
            Local = local;
            Road = road;
            MatchDttm = matchDttm;
            TieOdds = tieOdds;
        }
        public Match(Int64 id, Team local, Team road, DateTime matchDttm, double tieOdds = 0)
        {
            Id = Id;
            Local = local;
            Road = road;
            MatchDttm = matchDttm;
            TieOdds = tieOdds;
        }

        public Match(Int64 id, Team local, Team road, DateTime matchDttm, string pick, string expert, string sport, double tieOdds = 0)
        {
            Id = Id;
            Local = local;
            Road = road;
            MatchDttm = matchDttm;
            TieOdds = tieOdds;
            Pick = pick;
            Expert = expert;
            Sport = sport;
        }



    }
}
