using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Models.Tables
{
    public class UserSettings
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string BCP { get; set; }
        public string Alphabet { get; set; }
        public int RecentReturnNumber { get; set; }

    }
}
