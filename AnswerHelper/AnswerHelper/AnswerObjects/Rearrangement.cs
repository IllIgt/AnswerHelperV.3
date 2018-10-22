using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class Rearrangement
    {
        private long _Size;
        public string Type { get; set; }
        public long StartLocation { get; set; }
        public long EndLocation { get; set; }
        public string ChromosomeLocus { get; set; }

        public Rearrangement(string chromosome_locus, long start_location, long end_location, string type)
        {
            StartLocation = start_location;
            EndLocation = end_location;
            _Size = end_location - start_location;
            Type = type;
            ChromosomeLocus = chromosome_locus;
        }

        public override string ToString()
        {
            return $"\b{Type}\b0 {ChromosomeLocus} (геномная локализация: {StartLocation}-{EndLocation};" +
                    $" размер: {_Size} пн): {Type}, затронувшая";
        }

    }
}
