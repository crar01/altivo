using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altivo
{
    public class Time
    {
        public bool IsTimeUp { get; set; }
        public bool IsFullTime { get; set; }
        public int TotalTimeInSeconds { get; set; }
        public bool IsRunningTime { get; set; }

        public Time()
        {
            IsTimeUp = false;
            IsFullTime = true;
            TotalTimeInSeconds = 0;
            IsRunningTime = false;
        }
    }
}
