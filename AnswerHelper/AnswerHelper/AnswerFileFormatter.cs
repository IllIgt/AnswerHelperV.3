using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace AnswerHelper
{
    class AnswerFileFormatter
    {
        public static void MakeWord(Answer answer)
        {
            AnswerParser answerParser = new AnswerParser(answer);
            Word.Application word = new Word.Application();
            word.Visible = true;
            Word.Document doc = word.Documents.Add();
            doc.Select();
            word.Selection.TypeText(answerParser.GetRearrangments());
        }
    }
}
