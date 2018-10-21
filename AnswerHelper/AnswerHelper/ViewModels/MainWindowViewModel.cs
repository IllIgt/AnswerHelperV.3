using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnswerHelper
{
    class MainWindowViewModel : ViewModel
    {

        private Answer _MainAnswer;

        public ICommand AddCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand NewAnswerCommand { get; }
        public Answer MainAnswer
        {
            get { return _MainAnswer; }
            set => Set<Answer>(ref _MainAnswer, ref value);
        }


        public MainWindowViewModel()
        {
            AddCommand = new Command(OnAddCommandExecuted);
            SaveCommand = new Command(OnSaveCommandExecuted);
            NewAnswerCommand = new Command(OnNewAnswerCommandExecuted);
            MainAnswer = Answer.GetInstance();
            MainAnswer.Rearrangements.Add(new Rearrangement("Xp12q1", 100, 300, "Duplication"));
            Mediator.Register("GetRearrangement", OnGetRearrangement);
        }

        private void OnNewAnswerCommandExecuted(object obj)
        {
            MainAnswer = Answer.Refresh();
        }

        private void OnSaveCommandExecuted(object obj)
        {
            AnswerFileFormatter.MakeWord(MainAnswer);
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
