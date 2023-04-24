using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using TestSystem.Models;
using TestSystem.Utilities;

namespace TestSystem.ViewModels
{
    public class TestEditViewModel : ObservableObject
    {
        private TestModel testModel;
        private UserModel userModel;
        private string title;
        private string description;
        private DateTime? date_start;
        private DateTime? date_end;
        private TimeSpan? response_time;
        private int? percent_three;
        private int? percent_four;
        private int? percent_five;
        private IEnumerable<QuestionModel> questions;
        private RelayCommand backCommand;
        private RelayCommand saveCommand;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public DateTime? DateStart
        {
            get => date_start;
            set => SetProperty(ref date_start, value);
        }
        public DateTime? DateEnd
        {
            get => date_end;
            set => SetProperty(ref date_end, value);
        }
        public TimeSpan? ResponseTime
        {
            get => response_time;
            set => SetProperty(ref response_time, value);
        }
        public int? PercentThree
        {
            get => percent_three;
            set => SetProperty(ref percent_three, value);
        }
        public int? PercentFour
        {
            get => percent_four;
            set => SetProperty(ref percent_four, value);
        }
        public int? PercentFive
        {
            get => percent_five;
            set => SetProperty(ref percent_five, value);
        }
        public IEnumerable<QuestionModel> Questions
        {
            get => questions;
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
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(
                    (obj) =>
                    {
                        DoSaveCommand();
                    }
                  ));
            }
        }
        private void DoBackCommand()
        {
            Back();
        }
        private void DoSaveCommand()
        {
            Exception error = testModel.ChangeTest(Title, Description, DateStart, DateEnd, PercentThree, PercentFour, PercentFive);
            if (error == null) Back();
        }
        private void Back()
        {
            var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new TestsViewModel(userModel) });
            WeakReferenceMessenger.Default.Send(navModel);
        }
        public TestEditViewModel(TestModel testModel, UserModel userModel)
        {
            this.testModel = testModel;
            this.userModel = userModel;
            title = testModel.Title;
            description = testModel.Description;
            date_start = testModel.DateStart;
            date_end = testModel.DateEnd;
            response_time = testModel.ResponseTime;
            percent_three = testModel.PercentThree;
            percent_four = testModel.PercentFour;
            percent_five = testModel.PercentFive;
            questions = testModel.Questions;
        }

    }
}
