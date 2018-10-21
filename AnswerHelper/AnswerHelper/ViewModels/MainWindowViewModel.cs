using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnswerHelper
{
    class MainWindowViewModel : ViewModel
    {
        public Answer MainAnswer { get; set; }

        public ICommand AddCommand { get; }

        public MainWindowViewModel()
        {
            AddCommand = new Command(OnAddCommandExecuted);
            MainAnswer = Answer.GetInstance();
            MainAnswer.Rearrangements.Add(new Rearrangement("Xp12q1", 100, 300, "Duplication"));
            Mediator.Register("GetRearrangement", OnGetRearrangement);
        }

        private void OnGetRearrangement(object obj)
        {
            MainAnswer.Rearrangements.Add((Rearrangement)obj);
        }

        private void OnAddCommandExecuted(object obj)
        {
            RearrangementWindow rearrangementWindow = new RearrangementWindow();
            rearrangementWindow.ShowDialog();
        }
    }
}
