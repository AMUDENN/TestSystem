using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using TestSystem.Models;
using TestSystem.Utilities;

namespace TestSystem.ViewModels
{
    public class TestsViewModel : ObservableObject
    {
        public UserModel userModel;
        public TestOperationsModel operationsModel;
        private IEnumerable<TestModel> tests;
        private RelayCommand editCommand;
        private RelayCommand copyCommand;
        private RelayCommand deleteCommand;
        private RelayCommand addCommand;
        public UserModel UserModel
        {
            private get => userModel;
            set => SetProperty(ref userModel, value);
        }
        public IEnumerable<TestModel> Tests
        {
            get => tests;
            set => SetProperty(ref tests, value);
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
            MessageBox.Show("ы");
        }
        private void DoDeleteCommand(object data)
        {
            MessageBox.Show(((TestModel)data).Title);
        }
        private void DoAddCommand()
        {
            TestModel testModel = operationsModel.AddTest();
            if (testModel is null) return;
            var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new TestEditViewModel(testModel, userModel) });
            WeakReferenceMessenger.Default.Send(navModel);
        }
        public TestsViewModel(UserModel userModel)
        {
            UserModel = userModel;
            operationsModel = new TestOperationsModel(UserModel);
            Tests = operationsModel.GetTestModels();
        }
    }
}
