using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altivo
{
    public class Time
    {
        public bool IsTime { get; set; }
        public bool IsFullTime { get; set; }
        public int TotalTime { get; set; }
        public bool IsRunningTime { get; set; }

        public Time()
        {
            IsTime = false;
            IsFullTime = true;
            TotalTime = 0;
            IsRunningTime = false;
        }
    }
}
