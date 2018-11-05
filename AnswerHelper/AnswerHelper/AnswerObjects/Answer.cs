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
        private ObservableCollection<NonBalancedRearrangement> _NonBalancedRearrangements;
        private ObservableCollection<CNVRearrangement> _CNVRearrangements;
        private ObservableCollection<IntragenicRearrangement> _IntragenicRearrangements;
        private ObservableCollection<LOHRearrangement> _LOHRearrangements;
        private string _Date;
        private static Answer Instance;

        public List<string> AgePostfixes { get; } = new List<string> { "Год", "Года", "Месяц", "Месяцев", "Месяца", "Лет"};
        public string SelectedAgePostfix { get; set; } = "Лет";
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }

        public ObservableCollection<NonBalancedRearrangement> NonBalancedRearrangements
        {
            get { return _NonBalancedRearrangements ??
                    (_NonBalancedRearrangements = new ObservableCollection<NonBalancedRearrangement>()); }
        }

        public ObservableCollection<CNVRearrangement> CNVRearrangements
        {
            get {return _CNVRearrangements ?? (_CNVRearrangements = new ObservableCollection<CNVRearrangement>());}
        }

        public ObservableCollection<IntragenicRearrangement> IntragenicRearrangements
        {
            get { return _IntragenicRearrangements ?? 
                    (_IntragenicRearrangements = new ObservableCollection<IntragenicRearrangement>()); }
        }

        public ObservableCollection<LOHRearrangement> LOHRearrangements
        {
            get { return _LOHRearrangements ?? (_LOHRearrangements = new ObservableCollection<LOHRearrangement>()); }
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
