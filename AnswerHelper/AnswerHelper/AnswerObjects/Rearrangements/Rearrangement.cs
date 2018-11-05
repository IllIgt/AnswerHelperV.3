using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    abstract class Rearrangement
    {
        private long _Size;
        public string  CopiesNumber { get; set; }
        public string Type { get; set; }
        public long StartLocation { get; set; }
        public long EndLocation { get; set; }
        public string ChromosomeLocus { get; set; }

        public Rearrangement(string chromosome_locus, long start_location, long end_location,
            string copies_number, string type)
        {
            StartLocation = start_location;
            EndLocation = end_location;
            _Size = end_location - start_location;
            Type = type;
            CopiesNumber = copies_number;
            ChromosomeLocus = chromosome_locus;
        }

    }
}
