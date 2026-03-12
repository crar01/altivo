using System;

namespace Altivo.Dtos
{
    public class DayContributionDto
    {
        public DateTime Date { get; set; }
        public int SessionCount { get; set; }
        public int TotalMinutes { get; set; }
    }
}
