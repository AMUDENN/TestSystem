//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestSystem.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentsChoices
    {
        public int id { get; set; }
        public int result_id { get; set; }
        public int choice_answer_id { get; set; }
        public int number { get; set; }
    
        public virtual ChoiceAnswers ChoiceAnswers { get; set; }
        public virtual Results Results { get; set; }
    }
}
