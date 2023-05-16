using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TestSystem.Models;
using TestSystem.Utilities;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace TestSystem.ViewModels
{
    public class TestInfoViewModel : ObservableObject
    {
        private TestsViewModel testViewModel;
        private TestModel testModel;
        private double minDate;
        private double maxDate;
        private int maxResultsCount;
        private List<DataPoint> dataPoints = new List<DataPoint>();
        private IEnumerable<ResultModel> displayResults;
        private bool isXlsx = false;
        private bool isCsv = false;
        private RelayCommand downloadTestCommand;
        private RelayCommand downloadResultsCommand;
        private RelayCommand backCommand;
        private RelayCommand loadedCommand;
        public TestModel TestModel
        {
            get => testModel;
            set => SetProperty(ref testModel, value);
        }
        public double MinDate
        {
            get => minDate;
        }
        public double MaxDate
        {
            get => maxDate;
        }
        public int MaxResultsCount
        {
            get => maxResultsCount;
        }
        public List<DataPoint> DataPoints
        {
            get => dataPoints;
        }
        public IEnumerable<ResultModel> DisplayResults
        {
            get => displayResults;
            set => SetProperty(ref displayResults, value);
        }
        public bool IsXlsx
        {
            get => isXlsx;
            set => SetProperty(ref isXlsx, value);
        }
        public bool IsCsv
        {
            get => isCsv;
            set => SetProperty(ref isCsv, value);
        }
        public string IsOpenString
        {
            get => testModel.IsOpen ? "Открыт" : "Закрыт";
        }
        public ICommand DownloadTestCommand
        {
            get
            {
                return downloadTestCommand ??
                  (downloadTestCommand = new RelayCommand(
                    (obj) =>
                    {
                        DoDownloadTestCommand();
                    }
                  ));
            }
        }
        public ICommand DownloadResultsCommand
        {
            get
            {
                return downloadResultsCommand ??
                  (downloadResultsCommand = new RelayCommand(
                    (obj) =>
                    {
                        DoDownloadTestResults();
                    }
                  ));
            }
        }
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??
                  (backCommand = new RelayCommand(
                    (obj) =>
                    {
                        DoBackCommand();
                    }
                  ));
            }
        }
        public ICommand LoadedCommand
        {
            get
            {
                return loadedCommand ??
                  (loadedCommand = new RelayCommand(
                    (obj) =>
                    {
                        AddResultsAsync();
                    }
                  ));
            }
        }
        private void DoDownloadTestCommand()
        {
            Thread thread = new Thread(SaveQuestionsWordDocument);
            thread.Start();
        }
        private void DoDownloadTestResults()
        {
            if (!(IsCsv || IsXlsx)) return;
            Thread thread = new Thread(SaveResultExcelWorkbook);
            thread.Start();
        }
        private void DoBackCommand()
        {
            Back();
        }
        private void SetDataPoints(IEnumerable<ResultModel> results)
        {
            minDate = DateTimeAxis.ToDouble(DateTime.Now.AddDays(-14));
            maxDate = DateTimeAxis.ToDouble(DateTime.Now);

            if (!results.Any()) return;

            var groupedResults = results.GroupBy(x => x.DateStart.Date).OrderBy(x => x.Key).Select(x => new { Date = x.Key, Count = x.Count() });

            maxResultsCount = groupedResults.Max(x => x.Count) + 1;

            foreach (var item in groupedResults)
            {
                dataPoints.Add(new DataPoint(DateTimeAxis.ToDouble(item.Date), item.Count));
            }
        }
        private void SaveResultExcelWorkbook()
        {
            var application = new Excel.Application();

            application.SheetsInNewWorkbook = 1;
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            int startRowIndex = 1;
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            worksheet.Name = "Результаты";

            worksheet.Cells[1][startRowIndex] = "ФИО";
            worksheet.Cells[2][startRowIndex] = "Дата старта";
            worksheet.Cells[3][startRowIndex] = "Дата конца";
            worksheet.Cells[4][startRowIndex] = "Сумма баллов";
            worksheet.Cells[5][startRowIndex] = "Процент выполнения";
            worksheet.Cells[6][startRowIndex] = "Оценка";

            Excel.Range columlHeaderRange = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[6][1]];
            columlHeaderRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            columlHeaderRange.Font.Bold = true;
            startRowIndex++;

            var results = DisplayResults is null ? new List<ResultModel>() : DisplayResults;

            foreach (var result in results)
            {

                worksheet.Cells[1][startRowIndex] = result.StudentFullName;
                worksheet.Cells[2][startRowIndex] = result.DateStart;
                worksheet.Cells[3][startRowIndex] = result.DateEnd;
                worksheet.Cells[4][startRowIndex] = result.Score;
                worksheet.Cells[5][startRowIndex] = result.Percent;
                (worksheet.Cells[5][startRowIndex] as Excel.Range).NumberFormat = "0.00";
                worksheet.Cells[6][startRowIndex] = result.Mark;
                startRowIndex++;

            }

            Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[3][startRowIndex]];
            sumRange.Merge();
            sumRange.Value = "Средние значения:";
            sumRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            worksheet.Cells[4][startRowIndex].Formula = $"=AVERAGE(D{2}:D{startRowIndex - 1})";
            (worksheet.Cells[4][startRowIndex] as Excel.Range).NumberFormat = "0.00";
            sumRange.Font.Bold = worksheet.Cells[4][startRowIndex].Font.Bold = true;
            worksheet.Cells[5][startRowIndex].Formula = $"=AVERAGE(E{2}:E{startRowIndex - 1})";
            (worksheet.Cells[5][startRowIndex] as Excel.Range).NumberFormat = "0.00";
            sumRange.Font.Bold = worksheet.Cells[4][startRowIndex].Font.Bold = true;
            worksheet.Cells[6][startRowIndex].Formula = $"=AVERAGE(F{2}:F{startRowIndex - 1})";
            (worksheet.Cells[6][startRowIndex] as Excel.Range).NumberFormat = "0.00";
            sumRange.Font.Bold = worksheet.Cells[4][startRowIndex].Font.Bold = true;
            sumRange.Font.Bold = worksheet.Cells[5][startRowIndex].Font.Bold = true; 
            sumRange.Font.Bold = worksheet.Cells[6][startRowIndex].Font.Bold = true;

            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[6][startRowIndex - 1]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
                rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
                rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
                rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
            worksheet.Columns.AutoFit();

            application.Visible = true;

            if (IsCsv) workbook.SaveAs($@"{Environment.CurrentDirectory}\..\..\..\Results.csv", Excel.XlFileFormat.xlCSVWindows);
            else workbook.SaveAs($@"{Environment.CurrentDirectory}\..\..\..\Results.xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook);
        }
        private void SaveQuestionsWordDocument()
        {
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();

            document.Sections.First.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Text = DateTime.Now.ToString("d");
            Word.Range footerRange = document.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            footerRange.Text = "Страница ";
            footerRange.Fields.Add(footerRange, Word.WdFieldType.wdFieldPage);
            footerRange.Text += " из ";
            footerRange.InsertAfter(" из ");
            footerRange.Fields.Add(footerRange, Word.WdFieldType.wdFieldPage);
            footerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            footerRange.Font.Size = 10;
            footerRange.Font.Name = "Times New Roman";

            Word.Paragraph testParagraph = document.Paragraphs.Add();
            Word.Range titleRange = testParagraph.Range;
            titleRange.Text = testModel.Title;
            titleRange.Font.Bold = 1;
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.InsertParagraphAfter();

            int questionNumber = 1;

            foreach (var question in testModel.Questions)
            {
                document.Paragraphs.Add();

                Word.Paragraph questionTitleParagraph = document.Paragraphs.Add();
                Word.Range questionTitleRange = questionTitleParagraph.Range;
               
                questionTitleRange.Text = $"{questionNumber}. {question.Title}";
                questionTitleRange.InsertParagraphAfter(); 
                questionTitleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;


                Word.Paragraph questionDescriptionParagraph = document.Paragraphs.Add();
                Word.Range questionDescriptionRange = questionDescriptionParagraph.Range;
               
                questionDescriptionRange.Text = question.Description;
                questionDescriptionRange.InsertParagraphAfter(); 
                questionDescriptionRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

                questionNumber++;
            }

            application.Visible = true;
            document.SaveAs2($@"{Directory.GetCurrentDirectory()}\Test.docx");
            document.SaveAs2($@"{Directory.GetCurrentDirectory()}\Test.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }
        private void Back()
        {
            var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = testViewModel });
            WeakReferenceMessenger.Default.Send(navModel);
        }
        private async void AddResultsAsync()
        {
            if (!(DisplayResults is null)) return;
            var results = testModel.Results.OrderByDescending(x => x.DateEnd);

            var resultsList = new List<ResultModel>();

            int i = 0;
            foreach (var item in results)
            {
                i++;
                resultsList.Add(item);
                DisplayResults = resultsList.ToArray();
                if (i < 10) await Task.Delay(100);
            }
        }
        public TestInfoViewModel(TestModel testModel, TestsViewModel testViewModel)
        {
            this.testModel = testModel;
            this.testViewModel = testViewModel;
            SetDataPoints(testModel.Results);
        }
    }
}
