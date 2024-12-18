using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altivo.Models
{
    public class Activity
    {
        [PrimaryKey]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ActivityName { get; set; }
    }
}
