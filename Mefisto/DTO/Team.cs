 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.DTO
{
    public class Team
    {
        public string Name { get; set; }
        public float Odds { get; set; }


        public Team(string name, float odds = 0)
        {
            Name = name;
            Odds = odds;
        }
    }
}
