using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnswerHelper
{
    class RearrangementWindowViewModel : ViewModel
    {
        public Command SaveCommand { get; private set; }
        public string Chromosome { get; set; }
        public int StartLocation { get; set; }
        public int EndLocation { get; set; }

        public RearrangementWindowViewModel()
        {
            SaveCommand = new Command(OnSaveCommandExecuted);
        }

        private void OnSaveCommandExecuted(object window)
        {
            Mediator.NotifyColleggues("GetRearrangement",new Rearrangement(Chromosome, StartLocation, EndLocation, "Duplication"));
            ((IClosable)window)?.Close();
        }
    }
}
