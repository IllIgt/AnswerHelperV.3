using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class Answer
    {
        private ObservableCollection<Rearrangement> _Rearrangements;
        private string _Date;
        private static Answer Instance;
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
        
    }
}
