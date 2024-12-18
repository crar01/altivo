using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altivo.Models
{
    public class ConcentrationSession
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int DurationInMinutes { get; set; }
        public ConcentrationState State { get; set; } = ConcentrationState.Interrupted;
        public ConcentrationLevel ConcentrationLevel { get; set; } = ConcentrationLevel.None;

        public string CreatedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // add a key from activity like foreign key
        public Guid ActivityId { get; set; }
    }

    public enum ConcentrationState
    {
        InProgress = 0,
        Interrupted = 1,
        Complete = 2
    }

    public enum ConcentrationLevel
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Extreme = 4
    }
}
