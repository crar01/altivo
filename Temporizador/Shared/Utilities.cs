using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altivo.Shared
{
    public class Utilities
    {
        /// <summary>
        /// Converts minutes to hours and minutes with the format "xh ym"
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static string TotalTime(int minutes) 
        {
            int hours = minutes / 60;
            int minutesModular = minutes % 60;

            return (hours > 0 ? $"{hours}h" : "") + (minutesModular > 0 ? $"{minutesModular}m" : "");
        }
    }
}
