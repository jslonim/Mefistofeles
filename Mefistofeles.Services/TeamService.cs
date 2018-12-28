using Mefistofeles.Services.Config;
using Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Services
{
    public class TeamService : ServiceBase
    {
        public Int64 InsertTeam(Team team)
        {
            return TeamRepository.InsertTeam(team);
        }
    }
}
