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
            object begin = 0;
            object end = 0;
            Word.Range wordrange = doc.Range(ref begin, ref end);
            var headerParagraph = doc.Paragraphs.Add();
            headerParagraph.Format.SpaceAfter = 30f;
            doc.InlineShapes.AddPicture(@"D:\GitHub\AnswerHelperV.3\AnswerHelper\AnswerHelper\Additional\AnswerHeader.png", 
                Range:headerParagraph.Range);
            headerParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphDistribute;
            var titleParagraph = doc.Paragraphs.Add();
            titleParagraph.Format.SpaceAfter = 30f;
            titleParagraph.Range.Font.Size = 14;
            titleParagraph.Range.Font.Name = "Times New Roman";
            titleParagraph.Range.Font.Bold = 1;
            titleParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            titleParagraph.Range.Text = "Результаты молекулярно-цитогенетического исследования методом сравнительной геномной гибридизации на микрочипах (молекулярное кариотипирование) с использованием SNP/олигонуклеотидной микроматрицы Affymetrix Cytoscan HD, содержащей 2 696 550 проб.";
            titleParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            Word.Paragraph paragraph = doc.Paragraphs.Add();
            //paragraph.Range.Text = answerParser.GetSummary();
        }
    }
}
