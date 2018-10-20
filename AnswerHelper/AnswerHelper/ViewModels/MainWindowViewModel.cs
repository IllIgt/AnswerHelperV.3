using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnswerHelper
{
    class MainWindowViewModel : ViewModel
    {
        public ICommand AddCommand { get; }

        public MainWindowViewModel()
        {
            AddCommand = new Command(OnAddCommandExecuted);
        }

        private void OnAddCommandExecuted(object obj)
        {
            RearrangementWindow rearrangementWindow = new RearrangementWindow();
            rearrangementWindow.ShowDialog();
        }
    }
}
