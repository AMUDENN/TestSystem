﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestSystemEntities : DbContext
    {
        public TestSystemEntities()
            : base("name=TestSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ChoiceAnswers> ChoiceAnswers { get; set; }
        public virtual DbSet<FirstSequences> FirstSequences { get; set; }
        public virtual DbSet<Hints> Hints { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<QuestionTypes> QuestionTypes { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<SecondSequences> SecondSequences { get; set; }
        public virtual DbSet<StudentsChoices> StudentsChoices { get; set; }
        public virtual DbSet<StudentsMatches> StudentsMatches { get; set; }
        public virtual DbSet<StudentsSequences> StudentsSequences { get; set; }
        public virtual DbSet<StudentsTexts> StudentsTexts { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<TextAnswers> TextAnswers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
