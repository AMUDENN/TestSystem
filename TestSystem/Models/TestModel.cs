using System;
using System.Collections.Generic;
using System.Linq;
using TestSystem.Entities;
using TestSystem.Utilities;

namespace TestSystem.Models
{
    public class TestModel
    {
        private Tests test;
        private IEnumerable<QuestionModel> questions;
        private IEnumerable<ResultModel> results;
        public string Title
        {
            get => test.title;
        }
        public string Description
        {
            get => test.description;
        }
        public TimeSpan? ResponseTime
        {
            get => test.response_time;
        }
        public DateTime? DateStart
        {
            get => test.date_start;
        }
        public DateTime? DateEnd
        {
            get => test.date_end;
        }
        public int? PercentThree
        {
            get => test.percent_three;
        }
        public int? PercentFour
        {
            get => test.percent_four;
        }
        public int? PercentFive
        {
            get => test.percent_five;
        }
        public int ResultsCount
        {
            get => test.Results.Count;
        }
        public DateTime DateCreation
        {
            get => test.date_creation;
        }
        public bool IsOpen
        {
            get => DateTime.Now < DateEnd && DateTime.Now > DateStart;
        }
        public Tests Test
        {
            get => test;
        }
        public IEnumerable<QuestionModel> Questions
        {
            get
            {
                if (questions is null) questions = test.Questions.Select(x => new QuestionModel(x));
                return questions;
            }
        }
        public IEnumerable<ResultModel> Results
        {
            get
            {
                if (results is null) results = test.Results.Select(x => new ResultModel(x));
                return results;
            }
        }
        public TestModel(Tests test)
        {
            this.test = test;
        }
        public Exception ChangeTest(string title, string description, DateTime? dateStart, DateTime? dateEnd, int? percentThree, int? percentFour, int? percentFive)
        {
            try
            {
                test.title = title;
                test.description = description;
                test.date_start = dateStart;
                test.date_end = dateEnd;
                test.percent_three = percentThree;
                test.percent_four = percentFour;
                test.percent_five = percentFive;
                var context = Context.GetContext();
                context.SaveChanges();
            }
            catch
            {
                return new Exception("Ошибка во время сохранения теста");
            }
            return null;
        }
        public TestModel CopyTest()
        {
            TestModel testModel = null;
            try
            {
                return null;
            }
            catch
            {
                return null;
            }
            return testModel;
        }
        public Exception DeleteTest()
        {
            try
            {
                var context = Context.GetContext();
                context.Questions.RemoveRange(test.Questions);
                context.Tests.Remove(test);
                context.SaveChanges();
            }
            catch
            {
                return new Exception("Ошибка при удалении теста");
            }
            return null;
        }
    }
}
