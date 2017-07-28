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
        public static Word.Document insertAbstract(Word.Document document, string abstractContent)
        {
            Word.Paragraph heading;
            heading = document.Content.Paragraphs.Add();
            heading.Range.Text = "ABSTRACT";
            heading.Range.Font.Bold = 1;
            heading.Range.Font.Size = 14;
            heading.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            heading.Range.InsertParagraphAfter();

            Word.Paragraph content;
            content = document.Content.Paragraphs.Add();
            content.Range.Text = abstractContent;
            content.Range.Font.Bold = 0;
            content.Range.Font.Size = 11;
            content.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            content.Range.InsertParagraphAfter();

            return document;
        }

        public static Word.Document insertObjectives(Word.Document document, string objectivesContent)
        {
            Word.Paragraph heading;
            heading = document.Content.Paragraphs.Add();
            heading.Range.Text = "OBJECTIVES";
            heading.Range.Font.Bold = 1;
            heading.Range.Font.Size = 14;
            heading.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            heading.Range.InsertParagraphAfter();

            Word.Paragraph content;
            content = document.Content.Paragraphs.Add();
            content.Range.Text = objectivesContent;
            content.Range.Font.Bold = 0;
            content.Range.Font.Size = 11;
            content.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            content.Range.InsertParagraphAfter();

            return document;
        }

        public static Word.Document insertOutcomes(Word.Document document, string outcomesContent)
        {
            Word.Paragraph heading;
            heading = document.Content.Paragraphs.Add();
            heading.Range.Text = "OUTCOMES";
            heading.Range.Font.Bold = 1;
            heading.Range.Font.Size = 14;
            heading.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            heading.Range.InsertParagraphAfter();

            Word.Paragraph content;
            content = document.Content.Paragraphs.Add();
            content.Range.Text = outcomesContent;
            content.Range.Font.Bold = 0;
            content.Range.Font.Size = 11;
            content.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            content.Range.InsertParagraphAfter();

            return document;
        }

        public static Word.Document insertMain(Word.Document document, string mainContent)
        {
            Word.Paragraph heading;
            heading = document.Content.Paragraphs.Add();
            heading.Range.Text = "MAIN CONTENT";
            heading.Range.Font.Bold = 1;
            heading.Range.Font.Size = 14;
            heading.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            heading.Range.InsertParagraphAfter();

            Word.Paragraph content;
            content = document.Content.Paragraphs.Add();
            content.Range.Text = mainContent;
            content.Range.Font.Bold = 0;
            content.Range.Font.Size = 11;
            content.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            content.Range.InsertParagraphAfter();

            return document;
        }

        public static Word.Document insertReferences(Word.Document document, string referencesContent)
        {
            Word.Paragraph heading;
            heading = document.Content.Paragraphs.Add();
            heading.Range.Text = "REFERENCES";
            heading.Range.Font.Bold = 1;
            heading.Range.Font.Size = 14;
            heading.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            heading.Range.InsertParagraphAfter();

            Word.Paragraph content;
            content = document.Content.Paragraphs.Add();
            content.Range.Text = referencesContent;
            content.Range.Font.Bold = 0;
            content.Range.Font.Size = 11;
            content.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            content.Range.InsertParagraphAfter();

            return document;
        }

        public static Word.Document inserCustomTitle(Word.Document document, string title)
        {
            Word.Paragraph heading;
            heading = document.Content.Paragraphs.Add();
            heading.Range.Text = title.ToUpper();
            heading.Range.Font.Bold = 1;
            heading.Range.Font.Size = 14;
            heading.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            heading.Range.InsertParagraphAfter();

            return document;
        }

        public static Word.Document insertCustomeText(Word.Document document, string text)
        {
            Word.Paragraph content;
            content = document.Content.Paragraphs.Add();
            content.Range.Text = text;
            content.Range.Font.Bold = 0;
            content.Range.Font.Size = 11;
            content.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            content.Range.InsertParagraphAfter();

            return document;
        }

        public static void saveDocument(Word.Document document, string location)
        {
            document.SaveAs(location);
        }
    }
}