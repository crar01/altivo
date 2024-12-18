using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altivo.Models
{
    public class Seed
    {
        private static readonly Guid staticGuid = new Guid("12345678-1234-1234-1234-123456789abc");

        public static Activity DefaultActivity
        {
            get
            {
                return new Activity
                {
                    Id = staticGuid,
                    ActivityName = "Default Activity"
                };
            }
        }
    }
}
