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

        public ICommand AddIntragenicCommand { get; }
        public ICommand AddCNVCommand { get; }
        public ICommand AddLOHCommand { get; }
        public ICommand AddNonBalancedCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand NewAnswerCommand { get; }
        public Answer MainAnswer
        {
            get { return _MainAnswer; }
            set => Set<Answer>(ref _MainAnswer, ref value);
        }


        public MainWindowViewModel()
        {
            AddIntragenicCommand = new Command(OnAddIntagenicCommandExecuted);
            AddCNVCommand = new Command(OnAddCNVCommandExecuted);
            AddLOHCommand = new Command(OnAddLOHCommandExecuted);
            AddNonBalancedCommand = new Command(OnAddNonBalancedCommandExecuted);
            SaveCommand = new Command(OnSaveCommandExecuted);
            NewAnswerCommand = new Command(OnNewAnswerCommandExecuted);
            MainAnswer = Answer.GetInstance();
            Mediator.Register("GetCNV", OnGetCNV);
            Mediator.Register("GetLOH", OnGetLOH);
            Mediator.Register("GetNonBalanced", OnGetNonBalanced);
            Mediator.Register("GetIntragenic", OnGetIntagenic);
        }

        private void OnAddNonBalancedCommandExecuted(object obj)
        {
            NonBalancedWindow nonBalancedWindow = new NonBalancedWindow();
            nonBalancedWindow.ShowDialog();
        }

        private void OnAddLOHCommandExecuted(object obj)
        {
            LOHWindow lohWindow = new LOHWindow();
            lohWindow.ShowDialog();
        }

        private void OnAddCNVCommandExecuted(object obj)
        {
            CNVWindow cnvWindow = new CNVWindow();
            cnvWindow.ShowDialog();
        }

        private void OnAddIntagenicCommandExecuted(object obj)
        {
            IntragenicWindow intragenicWindow = new IntragenicWindow();
            intragenicWindow.ShowDialog();
        }

        private void OnGetIntagenic(object obj)
        {
            MainAnswer.IntragenicRearrangements.Add((IntragenicRearrangement)obj);
        }

        private void OnGetNonBalanced(object obj)
        {
            MainAnswer.NonBalancedRearrangements.Add((NonBalancedRearrangement)obj);
        }

        private void OnGetLOH(object obj)
        {
            MainAnswer.LOHRearrangements.Add((LOHRearrangement)obj);
        }

        private void OnGetCNV(object obj)
        {
            MainAnswer.CNVRearrangements.Add((CNVRearrangement)obj);
        }

        private void OnNewAnswerCommandExecuted(object obj)
        {
            MainAnswer = Answer.Refresh();
        }

        private void OnSaveCommandExecuted(object obj)
        {
            try
            {
                var wordFormatter = new AnswerFileFormatter(_MainAnswer);
                wordFormatter.MakeWord();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }
    }
}
