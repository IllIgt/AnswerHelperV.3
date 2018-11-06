using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace AnswerHelper
{
    class AnswerFileFormatter
    {
        private List<NonBalancedRearrangement> _NonBalancedRearrangements;
        private List<IntragenicRearrangement> _IntragenicRearrangements;
        private List<LOHRearrangement> _LOHRearrangements;
        private List<CNVRearrangement> _CNVRearrangements;

        public AnswerFileFormatter(Answer answer)
        {

        }

        public void MakeWord()
        {
            Word.Application word = new Word.Application();
            word.Visible = true;
            Word.Document doc = word.Documents.Add();

            //Set Document Style
            #region
            Word.Style style = word.ActiveDocument.Styles["Обычный"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
            #endregion

            //Set Header Image from Resources
            #region
            var tempPath = Path.GetTempPath() + "AnswerHeader.png";
            if (!File.Exists(tempPath))
            {
                var headerBitmap = Properties.Resources.AnswerHeader;
                System.Drawing.Bitmap headerImage = (System.Drawing.Bitmap)(headerBitmap);
                try
                {
                    headerImage.Save(tempPath);
                }
                catch(Exception e)
                {
                    System.Windows.MessageBox.Show(e.ToString());
                }
            }
            doc.Shapes.AddPicture(tempPath,
                SaveWithDocument: true, Top: -56, Left: -85, Width: doc.PageSetup.PageWidth, Height: 98);
            #endregion

            //Set paragraphs
            #region
            var headerParagraph = doc.Paragraphs.Add();
            headerParagraph.Range.InsertParagraphAfter();
            var littleFormatRegion = doc.Paragraphs.Add();
            littleFormatRegion.Range.InsertParagraphAfter();
            var titleParagraph = doc.Content.Paragraphs.Add();
            titleParagraph.Range.InsertParagraphAfter();
            var afterTitleFirstFormat = doc.Content.Paragraphs.Add();
           var afterTitleSecondFormat = doc.Content.Paragraphs.Add();
            var patientParagraph = doc.Content.Paragraphs.Add();
            patientParagraph.Range.InsertParagraphAfter();
            var summaryFirstParagraph = doc.Paragraphs.Add();
            summaryFirstParagraph.Range.InsertParagraphAfter();
            var summarySecondParagraph = doc.Paragraphs.Add();
            summarySecondParagraph.Range.InsertParagraphAfter();
            var arraysSummaryParagraph = doc.Paragraphs.Add();
            arraysSummaryParagraph.Range.InsertParagraphAfter();
            var commentsParagraph = doc.Paragraphs.Add();
            commentsParagraph.Range.InsertParagraphAfter();
            var nonBalancedParagraphTitle = doc.Paragraphs.Add();
            var nonBalancedParagraph = doc.Paragraphs.Add();
            nonBalancedParagraph.Range.InsertParagraphAfter();
            #endregion

            //Format paragraphs
            #region
            headerParagraph.Range.Font.Size = 10;
            littleFormatRegion.Range.Font.Size = 12;
            afterTitleFirstFormat.Range.Font.Size = 12;
            afterTitleSecondFormat.Range.Font.Size = 12;

            titleParagraph.Range.Font.Bold = 1;
            titleParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            titleParagraph.Range.Text = "Результаты молекулярно-цитогенетического исследования методом сравнительной геномной гибридизации на микрочипах (молекулярное кариотипирование) с использованием SNP/олигонуклеотидной микроматрицы Affymetrix Cytoscan HD, содержащей 2 696 550 проб.";
            titleParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            patientParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
          //  patientParagraph.Range.Text = _AnswerParser.GetPatientInfo();
            patientParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;

            summaryFirstParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            summaryFirstParagraph.Range.Text = "Заключение";
            summaryFirstParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

 
            summarySecondParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            summarySecondParagraph.Range.Text = "Запись результатов молекулярного кариотипа(согласно ISCN 2013 ):";
            summarySecondParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
            var footnoteRange = summarySecondParagraph.Range;
            footnoteRange.End -= 2;
            doc.Footnotes.Add(footnoteRange, Text:" ISCN (2013):An International System for Human Cytogenetic Nomenclature, L.G. Shaffer, J. McGowan-Jordan, M. Schmid (eds); S. Karger, Basel 2013.");

           // arraysSummaryParagraph.Range.Text = _AnswerParser.GetSummary();
            doc.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);

            commentsParagraph.Range.Font.Bold = 1;
            commentsParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            commentsParagraph.Range.Text = "Несбалансированные хромосомные и геномные перестройки (более 1 млн пн):";

            nonBalancedParagraphTitle.Range.Font.Bold = 1;
            nonBalancedParagraphTitle.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            nonBalancedParagraphTitle.Range.Text = "Несбалансированные хромосомные и геномные перестройки (более 1 млн пн):";
            #endregion

            //Set and Format NonStatic Paragraphs
            #region
            //if (_AnswerParser.NonBalanceRearrangements.Count != 0)
            //{
            //    foreach (var rearrangement in _AnswerParser.NonBalanceRearrangements)
            //    {
            //        nonBalancedParagraph.Range.Text = rearrangement.ToString();
            //        nonBalancedParagraph.Range.InsertParagraphAfter();
            //    }
            //}
            //else
            //{
            //    nonBalancedParagraph.Range.Text = "Не Выявленно.";
            //    nonBalancedParagraph.Range.InsertParagraphAfter();
            //}
            #endregion
        }
    } 

}
