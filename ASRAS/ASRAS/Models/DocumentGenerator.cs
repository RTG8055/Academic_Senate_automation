using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;

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

        public static Word.Document insertBullet(Word.Application app,Word.Document document)
        {

            ListGallery gallery = app.ListGalleries[WdListGalleryType.wdOutlineNumberGallery];
            ListTemplate myPreferredListTemplate = gallery.ListTemplates[5];
            ListLevel level1 = myPreferredListTemplate.ListLevels[1];
            level1.NumberFormat = "%1.";
            ListLevel level2 = myPreferredListTemplate.ListLevels[2];
            level2.NumberFormat = "%1.%2.";

            level1.Font.Bold = 1;
            level1.Font.Color = WdColor.wdColorAutomatic;
            level1.Font.Size = 12;

            level2.Font.Bold = 0;
            level2.Font.Color = WdColor.wdColorAutomatic;
            level2.Font.Size = 11;


            Range range = document.Range(0);
            range.ListFormat.ApplyListTemplateWithLevel(myPreferredListTemplate);
            range.Text = "Manipal Institute of Technology";
            range.Font.Bold = 1;
            range.Font.Color = WdColor.wdColorAutomatic;
            range.Font.Size = 12;
            range.InsertParagraphAfter();

            Range subRange = document.Range(range.StoryLength - 1);
            subRange.ListFormat.ApplyListTemplateWithLevel(myPreferredListTemplate, true);
            subRange.ListFormat.ListIndent();
            subRange.Text = "Proposal 1";
            subRange.Font.Bold = 0;
            subRange.Font.Color = WdColor.wdColorAutomatic;
            subRange.Font.Size = 11;
            subRange.Paragraphs.Indent();
            subRange.InsertParagraphAfter();
            ListTemplate sublistTemplate = subRange.ListFormat.ListTemplate;

            Range subRange2 = document.Range(range.StoryLength - 1);
            subRange2.ListFormat.ApplyListTemplateWithLevel(myPreferredListTemplate, true);
            subRange2.ListFormat.ListIndent();
            subRange2.Text = "Proposal 2";
            subRange2.Font.Bold = 0;
            subRange2.Font.Color = WdColor.wdColorAutomatic;
            subRange2.Font.Size = 11;
            subRange2.Paragraphs.Indent();
            subRange2.InsertParagraphAfter();

            Range subRange3 = document.Range(range.StoryLength - 1);
            subRange3.ListFormat.ApplyListTemplateWithLevel(myPreferredListTemplate, true);
            subRange3.Text = "Proposal 3";
            subRange3.Font.Bold = 1;
            subRange3.Font.Color = WdColor.wdColorAutomatic;
            subRange3.Font.Size = 12;
            subRange3.InsertParagraphAfter();

            return document;
        }

        public static void saveDocument(Document document, string location)
        {
            document.SaveAs(location);
        }

        public static string readDocument()
        {
            Application word = new Application();
            Document doc = new Document();

            string fileName = "C:/debugging/eval.docx";
            doc = word.Documents.Open(fileName);

            String read = string.Empty;
            for (int i = 0; i < doc.Paragraphs.Count; i++)
            {
                string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
                if (temp != string.Empty)
                    read = read + " " + temp;
            }

            Debug.WriteLine(read);

            return read;

            doc.Close();
            word.Quit();
        }
    }
}