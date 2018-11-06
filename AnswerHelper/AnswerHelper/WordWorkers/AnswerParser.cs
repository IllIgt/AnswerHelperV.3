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
        delegate string LocationToStringDelegate(long location);
        public List<Rearrangement> NonBalanceRearrangements { get; private set; } = new List<Rearrangement>();
        public List<Rearrangement> IntagenicRearrangements { get; private set; } = new List<Rearrangement>();
        public List<Rearrangement> CNVRearrangements { get; private set; } = new List<Rearrangement>();
        public List<Rearrangement> LOHRearrangements { get; private set; } = new List<Rearrangement>();

        public AnswerParser(Answer answer)
        {
            _Answer = answer;
            SortRearengementsByType();
        }

        private void SortRearengementsByType()
        {
            foreach (var rearrangement in _Answer.Rearrangements)
            {
                switch (rearrangement.Type)
                {
                    case "Интрагенная":
                        IntagenicRearrangements.Add(rearrangement);
                        break;
                    case "Несбалансированная":
                        NonBalanceRearrangements.Add(rearrangement);
                        break;
                    case "CNV":
                        CNVRearrangements.Add(rearrangement);
                        break;
                    case "LOH":
                        LOHRearrangements.Add(rearrangement);
                        break;
                }
            }
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
            foreach (var rearrangement in _Answer.Rearrangements)
                rearrangements += $"{rearrangement.ChromosomeLocus}" +
                    $"({locationToString(rearrangement.StartLocation)}-{locationToString(rearrangement.EndLocation)})" +
                    $"{rearrangement.Type}{(rearrangement != _Answer.Rearrangements.Last<Rearrangement>() ? "," : String.Empty)}";
            return rearrangements;
        }

        public string GetPatientInfo()
        {
            return $"Ф.И.О:\t\t{_Answer.Name} {_Answer.Surname} \tВозраст:\t\t {_Answer.Age} {_Answer.SelectedAgePostfix.ToLower()}\t";
        }
    }
}
