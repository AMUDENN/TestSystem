using System;
using TestSystem.Entities;

namespace TestSystem.Models
{
    public class QuestionModel
    {
        private Questions question;
        public QuestionTypes QuestionType
        {
            get => question.QuestionTypes;
        }
        public string Title
        {
            get => question.title;
        }
        public string Description
        {
            get => question.description;
        }
        public int Number
        {
            get => question.number;
        }
        public TimeSpan? ResponseTime
        {
            get => question.response_time;
        }
        public int Scores
        {
            get => question.scores;
        }
        public Questions Question
        {
            get => question;
        }
        public QuestionModel(Questions question)
        {
            this.question = question;
        }
    }
}
