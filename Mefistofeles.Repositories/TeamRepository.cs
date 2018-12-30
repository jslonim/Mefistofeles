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
    public class TeamRepository : RepositoryBase
    {
        public Int64 InsertTeam(Team team)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Name", team.Name, DbType.String, ParameterDirection.Input);
            parameter.Add("@Odds", team.Odds, DbType.Int64, ParameterDirection.Input);
            parameter.Add("@CoversWinPercentage", team.CoversWinPercentage, DbType.Int32, ParameterDirection.Input);

            var id = connection.ExecuteScalar("spInsertTeam",
                parameter,
                commandType: CommandType.StoredProcedure);

            return Convert.ToInt64(id);
        }

        public Team GetTeamById(int id)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            return connection.Query<Team>("spGetTeamById",parameter, commandType: CommandType.StoredProcedure).ToList()[0];
        }
    }
}
