using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;

namespace ASRAS.Models
{
    public static class DocumentGenerator
    {
        public static Word.Document insert(Word.Document document, string heading, string content)
        {
            Word.Paragraph headingPara;
            headingPara = document.Content.Paragraphs.Add();
            headingPara.Range.Text = heading.ToUpper();
            headingPara.Range.Font.Bold = 1;
            headingPara.Range.Font.Size = 14;
            headingPara.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            headingPara.Range.InsertParagraphAfter();

            Word.Paragraph contentPara;
            contentPara = document.Content.Paragraphs.Add();
            contentPara.Range.Text = content;
            contentPara.Range.Font.Bold = 0;
            contentPara.Range.Font.Size = 11;
            contentPara.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            contentPara.Range.InsertParagraphAfter();

            return document;
        }

        public static void saveDocument(Word.Document document, string location)
        {
            document.SaveAs2(location);
        }
    }
}