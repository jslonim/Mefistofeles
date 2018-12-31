using Mefistofeles.Services.Config;
using Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Services
{
    public class MatchService : ServiceBase
    {
        public void InsertMatch(Match match)
        {
            match.Local.Id = TeamRepository.InsertTeam(match.Local);
            match.Road.Id = TeamRepository.InsertTeam(match.Road);

            MatchRespository.InsertMatch(match);
        }

        public void UpdateMatchResult(Match match)
        {
            MatchRespository.UpdateMatchResult(match);
        }

        public void UpdateMatchesResults(List<Match> matches)
        {
            foreach (var match in matches)
            {
                MatchRespository.UpdateMatchResult(match);
            }        
        }

        public void InsertMatches(List<Match> matchList)
        {
            foreach (Match match in matchList)
            {
                InsertMatch(match);
            }
        }

        public List<Match> GetMatchesByDate(DateTime date, string sport)
        {
            return MatchRespository.GetMatchesByDate(date,sport);
        }
    }
}
