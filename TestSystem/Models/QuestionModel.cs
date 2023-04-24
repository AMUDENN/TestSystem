using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSystem.Entities;

namespace TestSystem.Models
{
    public class QuestionModel
    {
        private Questions question;
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
        public string QuestionType
        {
            get => question.QuestionTypes.title;
        }
        public string ResponseTimeString
        {
            get
            {
                if (question.response_time is null) return "Нет ограничений";
                return ((TimeSpan)question.response_time).ToString();
            }
        }
        public int Scores
        {
            get => question.scores;
        } 
        public QuestionModel(Questions question)
        {
            this.question = question;
        }
    }
}
