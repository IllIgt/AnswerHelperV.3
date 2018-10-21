using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class AnswerParser
    {
        private Answer _Answer;

        public AnswerParser(Answer answer)
        {
            _Answer = answer;
        }

        public string GetRearrangments()
        {
            string rearrangements = "";
            foreach (var rearrangement in _Answer.Rearrangements)
                rearrangements += $" {rearrangement.ChromosomeLocus}({rearrangement.StartLocation} - {rearrangement.EndLocation})";
            return rearrangements;
        }
    }
}
