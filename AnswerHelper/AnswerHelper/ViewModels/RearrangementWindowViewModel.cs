using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnswerHelper
{
    class RearrangementWindowViewModel : ViewModel
    {
        public Command SaveCommand { get; private set; }
        public string Chromosome { get; set; }
        public string Location { get; set; }
        public List<string> Types { get; } = new List<string> {"×1", "×2", "×3", "×1~2", "×2~3", "×0~1", "×4", "×2hmz"};
        public string SelectedType { get; set; } = "×2";

        public RearrangementWindowViewModel()
        {
            SaveCommand = new Command(OnSaveCommandExecuted);
        }

        private void OnSaveCommandExecuted(object window)
        {
            Regex regex = new Regex(@"\d+\s+\d+");
            Match match = regex.Match(Location);
            var locations= Regex.Split(match.Value, @"\s+");
            Mediator.NotifyColleggues("GetRearrangement",
                new Rearrangement(
                    Chromosome, 
                    long.Parse(locations[0]), 
                    long.Parse(locations[1]), 
                    SelectedType));
            ((IClosable)window)?.Close();
        }
    }
}
