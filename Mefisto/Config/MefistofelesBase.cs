using Mefistofeles.PageObjects;
using Mefistofeles.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Config
{
    public class MefistofelesBase : SeleniumBase
    {
        protected BetStars BetStars { get; set; }
        protected SportsChatPlace SportsChatPlace { get; set; }
        protected Covers Covers { get; set; }

        public MefistofelesBase()
        {
            BetStars = new BetStars();
            SportsChatPlace = new SportsChatPlace();
            Covers = new Covers();
        }
    }
}
