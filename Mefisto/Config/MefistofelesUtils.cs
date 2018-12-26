using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Config
{
    static class MefistofelesUtils
    {
        public static DateTime ConvertToArgentinaTime(DateTime matchDttm)
        {
            matchDttm = TimeZoneInfo.ConvertTimeToUtc(matchDttm, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(matchDttm, cstZone);
        }
    }
}
