using Mefistofeles.PageObjects;
using Mefistofeles.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mefistofeles.Config
{
    public class MefistofelesBase : SeleniumBase
    {
        protected TeamService TeamService { get; set; }
        protected MatchService MatchService { get; set; }
        protected BetStars BetStars { get; set; }
        protected SportsChatPlace SportsChatPlace { get; set; }
        protected Covers Covers { get; set; }

        public MefistofelesBase()
        {
            BetStars = new BetStars();
            SportsChatPlace = new SportsChatPlace();
            Covers = new Covers();
            TeamService = new TeamService();
            MatchService = new MatchService();
        }

        public void TryRetry<T>( Func<T> operation, int times = 3)
        {
            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    operation();
                    break; 
                }
                catch (Exception ex)
                {
                    if (attempts == times)
                        throw;

                    Thread.Sleep(3000);
                }
            } while(true);
        }
    }
}
