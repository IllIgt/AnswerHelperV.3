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
        private AnswerFileFormatter _AnswerFileFormatter;
        private List<Rearrangement> _SummaryRearrangements;
        delegate string LocationToStringDelegate(long location);

        public AnswerParser(Answer answer)
        {
            _Answer = answer;
            _SummaryRearrangements = new List<Rearrangement>(); 
            _SummaryRearrangements.AddRange(_Answer.IntragenicRearrangements);
            _SummaryRearrangements.AddRange(_Answer.NonBalancedRearrangements);
            _SummaryRearrangements.AddRange(_Answer.CNVRearrangements);
        }

        private string SetLocationToString(long location)
        {
            string stringLocation = "";
            while (location > 1)
            {
                stringLocation = stringLocation.Insert(0, $",{(location % 1000).ToString()}");
                location /= 1000;
            }
            return location != 0 ? stringLocation.Insert(0, $"{location.ToString()}"):stringLocation.Remove(0, 1);
        }

        public string GetSummary()
        {
            LocationToStringDelegate locationToString = SetLocationToString;
            string rearrangements = "arr ";
            foreach (var rearrangement in _SummaryRearrangements)
                rearrangements += $"{rearrangement.ChromosomeLocus}" +
                    $"({locationToString(rearrangement.StartLocation)}-{locationToString(rearrangement.EndLocation)})" +
                    $"{rearrangement.CopiesNumber}{(rearrangement != _SummaryRearrangements.Last<Rearrangement>() ? "," : String.Empty)}";
            return rearrangements;
        }

        public string GetPatientInfo()
        {
            return $"Ф.И.О:\t\t{_Answer.Name} {_Answer.Surname} \tВозраст:\t\t {_Answer.Age} {_Answer.SelectedAgePostfix.ToLower()}\t";
        }

        public void CreateAndFillWdDocument()
        {
            //_AnswerFileFormatter = new AnswerFileFormatter();
        }

    }
}
