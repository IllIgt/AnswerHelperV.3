using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class IntragenicRearrangement : Rearrangement
    {
        public string Gene { get; private set; }

        public IntragenicRearrangement(
            string chromosome_locus, long start_location, long end_location, string copies_number, string type, string gene)
            : base(chromosome_locus, start_location, end_location, copies_number, type)
        {
            Gene = gene;
        }
    }
}
