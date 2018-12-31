using Dapper;
using Mefistofeles.Repositories.Config;
using Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Repositories
{
    public class MatchRespository : RepositoryBase
    {
        public void InsertMatch(Match match)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@LocalTeam", match.Local.Id, DbType.Int64, ParameterDirection.Input);
            parameter.Add("@RoadTeam", match.Road.Id, DbType.Int64, ParameterDirection.Input);
            parameter.Add("@TieOdds", match.TieOdds, DbType.Decimal, ParameterDirection.Input);
            parameter.Add("@MatchDttm", match.MatchDttm, DbType.DateTime, ParameterDirection.Input);
            parameter.Add("@Pick", match.Pick, DbType.String, ParameterDirection.Input);
            parameter.Add("@Sport", match.Sport, DbType.String, ParameterDirection.Input);
            parameter.Add("@Result", match.Result, DbType.String, ParameterDirection.Input);
            parameter.Add("@AfterTime", match.AfterTime, DbType.Boolean, ParameterDirection.Input);
            parameter.Add("@Expert", match.Expert, DbType.String, ParameterDirection.Input);

            connection.Execute("spInsertMatch",
                parameter,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateMatchResult(Match match)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", match.Local.Id, DbType.Int64, ParameterDirection.Input);
            parameter.Add("@Result", match.Expert, DbType.String, ParameterDirection.Input);
            parameter.Add("@AfterTime", match.AfterTime, DbType.Binary, ParameterDirection.Input);

            connection.Execute("spUpdateMatchResult",
                parameter,
                commandType: CommandType.StoredProcedure);
        }

        public List<Match> GetMatchesByDate(DateTime date)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@MatchDttm", date, DbType.DateTime, ParameterDirection.Input);

            return connection.Query<Match, Team, Team, Match>(
                 "spGetMatchesByDate",
                 (match, team, team2) =>
                 {
                     match.Local = team;
                     match.Road = team;
                     return match;
                 },
                 parameter,              
                 splitOn: "Id,Id",
                 commandType: CommandType.StoredProcedure
                 )
                 .Distinct()
                 .ToList();
        }
    }
}
