using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class Answer
    {
        private ObservableCollection<Rearrangement> _Rearrangements;
        private string _Date;
        private static Answer Instance;

        public List<string> AgePostfixes { get; } = new List<string> { "Год", "Года", "Месяц", "Месяцев", "Месяца", "Лет"};
        public string SelectedAgePostfix { get; set; } = "Лет";
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }

        public ObservableCollection<Rearrangement> Rearrangements
        {
            get { return _Rearrangements ?? (_Rearrangements = new ObservableCollection<Rearrangement>()); }
        }

        public Answer()
        {
            _Date = DateTime.Now.ToString("dd MMMM yyyy");
        }

        public static Answer GetInstance()
        {
            if (Instance == null)
                Instance = new Answer();
            return Instance;
        }

        public static Answer Refresh()
        {
            if (Instance != null)
                Instance = new Answer();
            return Instance;
        }

    }
}
