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
    
            connection.Execute("spInsertMatch",
                parameter,
                commandType: CommandType.StoredProcedure);
        }
    }
}
