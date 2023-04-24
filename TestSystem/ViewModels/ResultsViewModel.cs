using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class ResultsViewModel : ObservableObject
    {
        public UserModel userModel;
        private IEnumerable<ResultModel> results;
        public UserModel UserModel
        {
            private get => userModel;
            set => SetProperty(ref userModel, value);
        }
        public IEnumerable<ResultModel> Results
        {
            get => results;
            set => SetProperty(ref results, value);
        }
        public ResultsViewModel(UserModel userModel)
        {
            UserModel = userModel;
            Results = this.UserModel.CurrentUser.Results.Select(x => new ResultModel(x)).ToList();
        }
    }
}
