 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTO
{
    public class Team
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public double Odds { get; set; }
        public int CoversWinPercentage { get; set; }
        public int Standing { get; set; }

        public Team() {
        }

        public Team(string name, double odds = 0)
        {
            Name = name;
            Odds = odds;
        }

        public Team(Int64 id, string name, double odds)
        {
            Id = id;
            Name = name;
            Odds = odds;
        }

        public Team(Int64 id, string name, double odds , int coversWinPercentage)
        {
            Id = id;
            Name = name;
            Odds = odds;
            CoversWinPercentage = coversWinPercentage;
        }


        public Team(Int64 id, string name, double odds, int coversWinPercentage, int standing)
        {
            Id = id;
            Name = name;
            Odds = odds;
            CoversWinPercentage = coversWinPercentage;
            Standing = standing;
        }
    }
}
