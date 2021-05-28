using AzmoonTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AzmoonTracker.Infrastacture
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        //public DbSet<UserParticipateInExam> StudentExams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<UserParticipateInExam>()
            //    .HasKey(o => new { o.ExamFK, o.ParticipantFK });

            modelBuilder.Entity<QuestionType>()
                .HasKey(o => o.TypeId);

            modelBuilder.Entity<Question>()
                .HasKey(o => new { o.QuestionNum, o.ExamId });

            modelBuilder.Entity<Exam>()
                .HasKey(o => o.ExamId);

            modelBuilder.Entity<Choice>()
                .HasKey(o => new { o.ChoiceNum, o.QuestionId, o.ExamId});

            // modelBuilder.Entity<Question>()
                //.HasMany(o1 => o1.Choices)
                //.WithOne(o2 => o2.Question)
                //.HasForeignKey(o1 => new {o1.QuestionId, o1.ExamId});

            //modelBuilder.Entity<AppUser>()
            //    .HasKey(o => o.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
