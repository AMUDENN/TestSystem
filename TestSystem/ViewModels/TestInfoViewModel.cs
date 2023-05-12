using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.Generic;
using System.Linq;
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
        private PlotModel plotViewModel;
        private RelayCommand backCommand;
        public PlotModel PlotViewModel
        {
            get => plotViewModel;
            set => SetProperty(ref plotViewModel, value);
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
        private void DoBackCommand()
        {
            Back();
        }
        private PlotModel GetPlotModel(IEnumerable<ResultModel> results)
        {
            var groupedResults = results.GroupBy(x => x.DateStart.Date).OrderBy(x => x.Key).Select(x => new {Date = x.Key, Count = x.Count()});

            PlotModel ResultModel = new PlotModel();

            LineSeries line = new LineSeries()
            {
                StrokeThickness = 1.5,
                CanTrackerInterpolatePoints = false
            };

            DateTimeAxis xAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "dd.MM"
            };

            foreach (var item in groupedResults)
            {
                line.Points.Add(new DataPoint(DateTimeAxis.ToDouble(item.Date), item.Count)) ;
            }
            ResultModel.Series.Add(line);

            ResultModel.Axes.Add(xAxis);

            return ResultModel;
        }
        private void Back()
        {
            var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = testViewModel });
            WeakReferenceMessenger.Default.Send(navModel);
        }
        public TestInfoViewModel(TestModel testModel, TestsViewModel testViewModel)
        {
            this.testModel = testModel;
            this.testViewModel = testViewModel;
            PlotViewModel = GetPlotModel(testModel.Results);
        }
    }
}
