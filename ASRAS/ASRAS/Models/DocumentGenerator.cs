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
        public static Word.Document insertText(string text, Word.Document document)
        {
            Word.Paragraph paragraph;
            paragraph = document.Content.Paragraphs.Add();
            paragraph.Range.Text = text;
            paragraph.Range.Font.Bold = 1;
            paragraph.Range.InsertParagraphAfter();
            return document;
        }

        public static void saveDocument(string location, Word.Document document)
        {
            string fullPath = location;
            document.SaveAs(fullPath);
        }
    }
}