﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class AnswerParser
    {
        private Answer _Answer;
        delegate string LocationToStringDelegate(long location);

        public AnswerParser(Answer answer)
        {
            _Answer = answer;
        }

        private string SetLocationToString(long location)
        {
            string stringLocation = "";
            while (location > 1)
            {
                stringLocation = stringLocation.Insert(0, $",{(location % 1000).ToString()}");
                location /= 1000;
            }
            return stringLocation.Insert(0, location.ToString());
        }
        
        public string GetSummary()
        {
            LocationToStringDelegate locationToString = SetLocationToString;
            string rearrangements = "arr ";
            foreach (var rearrangement in _Answer.Rearrangements)
                rearrangements += $"{rearrangement.ChromosomeLocus}" +
                    $"({locationToString(rearrangement.StartLocation)}-{locationToString(rearrangement.EndLocation)})" +
                    $"{rearrangement.Type}{(rearrangement!=_Answer.Rearrangements.Last<Rearrangement>() ? "," : String.Empty)}";
            return rearrangements;
        }
    }
}
