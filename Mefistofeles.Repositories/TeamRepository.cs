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

            var id = connection.ExecuteScalar("spInsertTeam",
                parameter,
                commandType: CommandType.StoredProcedure);

            return Convert.ToInt64(id);
        }
    }
}
