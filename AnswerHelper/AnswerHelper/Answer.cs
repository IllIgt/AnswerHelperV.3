using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class Answer
    {
        public List<Rearrangement> Rearrangements { get; set; }
        private string _Date;
        private static Answer Instance;

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
