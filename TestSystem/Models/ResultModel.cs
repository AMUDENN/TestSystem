using System;
using TestSystem.Entities;

namespace TestSystem.Models
{
    public class ResultModel
    {
        private Results result;
        public string TestTitle
        {
            get => result.Tests.title;
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
        public ResultModel(Results result)
        {
            this.result = result;
        }
    }
}
