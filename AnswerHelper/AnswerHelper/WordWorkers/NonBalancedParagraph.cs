using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace AnswerHelper.WordWorkers
{
    class NonBalancedParagraph
    {
        public NonBalancedParagraph(Word.Range range, string text)
        {
            range.Text = text;
        } 
    }
}
