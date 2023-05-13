using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestSystem.Entities;
using TestSystem.Models;
using TestSystem.Utilities;

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
        private bool isXslx = false;
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
        public bool IsXslx
        {
            get => isXslx;
            set => SetProperty(ref isXslx, value);
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

        }
        private void DoDownloadTestResults()
        {

        }
        private void DoBackCommand()
        {
            Back();
        }
        private void GetPlotModel(IEnumerable<ResultModel> results)
        {
            minDate = DateTimeAxis.ToDouble(DateTime.Now.AddDays(-14));
            maxDate = DateTimeAxis.ToDouble(DateTime.Now);

            if (!results.Any()) return;

            var groupedResults = results.GroupBy(x => x.DateStart.Date).OrderBy(x => x.Key).Select(x => new { Date = x.Key, Count = x.Count() });

            maxResultsCount = groupedResults.Max(x => x.Count) + 1;

            PlotModel ResultModel = new PlotModel();

            foreach (var item in groupedResults)
            {
                dataPoints.Add(new DataPoint(DateTimeAxis.ToDouble(item.Date), item.Count));
            }
        }
        private void Back()
        {
            var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = testViewModel });
            WeakReferenceMessenger.Default.Send(navModel);
        }
        private async void AddResultsAsync()
        {
            var results = testModel.Results.OrderBy(x => x.DateEnd);

            var resultsList = new List<ResultModel>();

            int i = 0;
            foreach (var item in results)
            {
                i++;
                resultsList.Add(item);
                DisplayResults = resultsList.ToArray();
                if (i < 5) await Task.Delay(100);
            }
        }
        public TestInfoViewModel(TestModel testModel, TestsViewModel testViewModel)
        {
            this.testModel = testModel;
            this.testViewModel = testViewModel;
            GetPlotModel(testModel.Results);
        }
    }
}
