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
        public DbSet<UserParticipateInExam> UsersParticipateInExams { get; set; }
        public DbSet<Answer> Answers { get; set; }
        //public DbSet<UserParticipateInExam> StudentExams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Primary keys
            modelBuilder.Entity<UserParticipateInExam>()
                .HasKey(o => o.ExamParticipantId);

            modelBuilder.Entity<UserParticipateInExam>()
                .HasAlternateKey(o => new { o.ExamFK, o.ParticipantFK });

            modelBuilder.Entity<QuestionType>()
                .HasKey(o => o.TypeId);

            modelBuilder.Entity<Question>()
                .HasKey(o => new { o.QuestionNum, o.ExamId });

            modelBuilder.Entity<Exam>()
                .HasKey(o => o.ExamId);

            modelBuilder.Entity<Exam>()
                .HasIndex(o => o.ExamSearchId)
                .IsUnique();

            modelBuilder.Entity<Choice>()
                .HasKey(o => new { o.ChoiceNum, o.QuestionId, o.ExamId});

            //set key & alternateKey for answer
            modelBuilder.Entity<Answer>()
                .HasKey(o => new { o.ExamId, o.QuestionId, o.ExamParticipantId });

            //foreign key relationships
            modelBuilder.Entity<Answer>()
                .HasOne(i => i.ExamParticipant)
                .WithMany(c => c.Answers)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

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
