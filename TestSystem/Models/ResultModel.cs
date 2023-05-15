using System;
using System.Linq;
using TestSystem.Entities;

namespace TestSystem.Models
{
    public class ResultModel
    {
        private Results result;
        private TestModel testModel;
        private int? mark;
        private int? score;
        private double? percent;
        public string TestTitle
        {
            get => result.Tests.title;
        }
        public string StudentFullName
        {
            get
            {
                var user = result.Users;
                return $"{user.surname} {user.name} {user.patronymic}";
            }
        }
        public DateTime DateStart
        {
            get => result.date_start;
        }
        public DateTime DateEnd
        {
            get => result.date_start;
        }
        public string IPAdress
        {
            get => result.ip_adress;
        }
        public int Mark
        {
            get
            {
                if (mark is null) SetScoreAndMark();
                return (int)mark;
            }
        }
        public int Score
        {
            get
            {
                if (score is null) SetScoreAndMark();
                return (int)score;
            }
        }
        public double Percent
        {
            get
            {
                if (percent is null) SetScoreAndMark();
                return (double)percent;
            }
        }
        public ResultModel(Results result)
        {
            this.result = result;
            this.testModel = new TestModel(result.Tests);
        }
        public ResultModel(Results result, TestModel testModel)
        {
            this.result = result;
            this.testModel = testModel;
        }
        private void SetScoreAndMark()
        {
            int tempScore = 0;

            var choices = result.StudentsChoices.GroupBy(x => x.ChoiceAnswers.Questions);
            foreach (var item in choices)
            {
                var question = item.Key;
                if (question.question_type_id == 1 && item.First().ChoiceAnswers.is_correct)
                {
                    tempScore += question.scores;
                }
                else if (item.Select(x => x.ChoiceAnswers).OrderBy(x => x.id)
                        .SequenceEqual(question.ChoiceAnswers.Where(x => x.is_correct).OrderBy(x => x.id)))
                {
                    tempScore += question.scores;
                }
            }

            var texts = result.StudentsTexts;
            foreach (var item in texts)
            {
                if (item.text_answer == item.TextAnswers.correct_answer)
                {
                    tempScore += item.TextAnswers.Questions.scores;
                }
            }

            var matches = result.StudentsMatches.GroupBy(x => x.Answers.Hints.Questions);
            foreach (var item in matches)
            {
                var question = item.Key;
                if (item.Where(x => x.Answers.is_correct).Count() == question.Hints.Count)
                {
                    tempScore += question.scores;
                }
            }

            var sequences = result.StudentsSequences.GroupBy(x => x.FirstSequences.Questions);
            foreach (var item in sequences)
            {
                var question = item.Key;
                if (item.Where(x => x.FirstSequences.correct_answer_id == x.second_id).Count() == question.FirstSequences.Count)
                {
                    tempScore += question.scores;
                }
            }

            score = tempScore;

            percent = tempScore / (double)testModel.MaxScore * 100;

            mark = testModel.PercentFive > percent ? (testModel.PercentFour > percent ? (testModel.PercentThree > percent ? 2 : 3) : 4) : 5;
        }
    }
}
