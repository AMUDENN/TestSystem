using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TestSystem.Models;
using TestSystem.Utilities;

namespace TestSystem.ViewModels
{
    public class TestsViewModel : ObservableObject
    {
        public UserModel userModel;
        public TestOperationsModel operationsModel;
        private Dictionary<string, Func<TestModel, bool>> testStatuses = new Dictionary<string, Func<TestModel, bool>>
        {
            { "Все статусы", x => true},
            { "Только открытые", x => x.IsOpen },
            { "Только закрытые", x => !x.IsOpen }
        };
        private string selectedTestStatus;
        private Dictionary<string, Func<TestModel, object>> testOrderType = new Dictionary<string, Func<TestModel, object>>
        {
            { "По дате создания", x => x.DateCreation },
            { "По названию", x => x.Title }
        };
        private string selectedTestOrderType;
        private Dictionary<string, bool> testOrder = new Dictionary<string, bool>
        {
            { "По возрастанию", true },
            { "По убыванию", false }
        };
        private string selectedTestOrder;
        private string filter;
        private IEnumerable<TestModel> tests;
        private IEnumerable<TestModel> displayedTests;
        private RelayCommand editCommand;
        private RelayCommand copyCommand;
        private RelayCommand deleteCommand;
        private RelayCommand addCommand;
        public UserModel UserModel
        {
            private get => userModel;
            set => SetProperty(ref userModel, value);
        }
        public IEnumerable<string> TestStatuses => testStatuses.Keys;
        public string SelectedTestStatus
        {
            get => selectedTestStatus;
            set
            {
                SetProperty(ref selectedTestStatus, value);
                DoOrder();
            }
        }
        public IEnumerable<string> TestOrderType => testOrderType.Keys;
        public string SelectedTestOrderType
        {
            get => selectedTestOrderType;
            set
            {
                SetProperty(ref selectedTestOrderType, value);
                DoOrder();
            }
        }
        public IEnumerable<string> TestOrder => testOrder.Keys;
        public string SelectedTestOrder
        {
            get => selectedTestOrder;
            set
            {
                SetProperty(ref selectedTestOrder, value);
                DoOrder();
            }
        }
        public string Filter
        {
            get => filter;
            set
            {
                SetProperty(ref filter, value.ToLower());
                DisplayedTests = DisplayedTests.Where(x => x.Title.ToLower().Contains(Filter));
            }
        }
        public IEnumerable<TestModel> Tests
        {
            get => tests;
            set => SetProperty(ref tests, value);
        }
        public IEnumerable<TestModel> DisplayedTests
        {
            get => displayedTests;
            set => SetProperty(ref displayedTests, value);
        }
        public ICommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(
                    (obj) =>
                    {
                        DoEditCommand(obj);
                    }
                  ));
            }
        }
        public ICommand CopyCommand
        {
            get
            {
                return copyCommand ??
                  (copyCommand = new RelayCommand(
                    (obj) =>
                    {
                        DoCopyCommand(obj);
                    }
                  ));
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(
                    (obj) =>
                    {
                        DoDeleteCommand(obj);
                    }
                  ));
            }
        }
        public ICommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(
                    (obj) =>
                    {
                        DoAddCommand();
                    }
                  ));
            }
        }
        private void DoEditCommand(object data)
        {
            var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new TestEditViewModel((TestModel)data, userModel) });
            WeakReferenceMessenger.Default.Send(navModel);
        }
        private void DoCopyCommand(object data)
        {
            TestModel sourceTest = data as TestModel;
            TestModel tm = sourceTest.CopyTest();
            if (tm != null)
            {
                Tests = Tests.Append(tm);
                UserMessages.Information("Тест скопирован");
            }
        }
        private void DoDeleteCommand(object data)
        {
            TestModel tm = data as TestModel;
            string title = tm.Title;
            if (tm.DeleteTest() is null)
            {
                Tests = Tests.Where(x => x != tm);
                UserMessages.Information($"Тест {title} удалён");
            }
        }
        private void DoAddCommand()
        {
            TestModel testModel = operationsModel.AddTest();
            if (testModel is null) return;
            var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new TestEditViewModel(testModel, userModel) });
            WeakReferenceMessenger.Default.Send(navModel);
        }
        private void DoOrder()
        {
            var tests = Tests.Where(testStatuses[SelectedTestStatus]);
            tests = testOrder[SelectedTestOrder] ? tests.OrderBy(testOrderType[SelectedTestOrderType]) : tests.OrderByDescending(testOrderType[SelectedTestOrderType]);
            DisplayedTests = tests;
        }
        public TestsViewModel(UserModel userModel)
        {
            UserModel = userModel;
            operationsModel = new TestOperationsModel(UserModel);
            Tests = operationsModel.GetTestModels();
            DisplayedTests = tests;
            selectedTestStatus = testStatuses.First().Key;
            selectedTestOrderType = testOrderType.First().Key;
            selectedTestOrder = testOrder.Last().Key;
        }
    }
}
