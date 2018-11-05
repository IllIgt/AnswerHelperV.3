using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class LOHRearrangement : Rearrangement
    {
        public LOHRearrangement(
            string chromosome_locus, long start_location, long end_location, string copies_number, string type)
            : base(chromosome_locus, start_location, end_location, copies_number, type)
        {
        }
    }
}
