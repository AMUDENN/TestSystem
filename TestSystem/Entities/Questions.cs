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
    
    public partial class Questions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questions()
        {
            this.ChoiceAnswers = new HashSet<ChoiceAnswers>();
            this.FirstSequences = new HashSet<FirstSequences>();
            this.Hints = new HashSet<Hints>();
            this.TextAnswers = new HashSet<TextAnswers>();
        }
    
        public int id { get; set; }
        public int test_id { get; set; }
        public Nullable<int> album_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int number { get; set; }
        public int question_type_id { get; set; }
        public Nullable<System.TimeSpan> response_time { get; set; }
        public int scores { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChoiceAnswers> ChoiceAnswers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirstSequences> FirstSequences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hints> Hints { get; set; }
        public virtual QuestionTypes QuestionTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TextAnswers> TextAnswers { get; set; }
    }
}
