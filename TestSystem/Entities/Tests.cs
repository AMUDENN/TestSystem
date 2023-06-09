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
    
    public partial class Tests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tests()
        {
            this.Questions = new HashSet<Questions>();
            this.Results = new HashSet<Results>();
        }
    
        public int id { get; set; }
        public Nullable<int> category_id { get; set; }
        public int teacher_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> date_start { get; set; }
        public Nullable<System.DateTime> date_end { get; set; }
        public bool is_ordered { get; set; }
        public Nullable<System.TimeSpan> response_time { get; set; }
        public Nullable<int> percent_three { get; set; }
        public Nullable<int> percent_four { get; set; }
        public Nullable<int> percent_five { get; set; }
        public System.DateTime date_creation { get; set; }
    
        public virtual Categories Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questions> Questions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }
        public virtual Users Users { get; set; }
    }
}
