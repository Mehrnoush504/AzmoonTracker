using AzmoonTracker.Infrastacture;
using AzmoonTracker.Models;
using AzmoonTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonTracker.Services.ExamRepository
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext ctx;

        public ExamRepository(AppDbContext _ctx)
        {
            ctx = _ctx;
        }

        public ICollection<ExamViewModel> GetAllExams()
        {
            ICollection<ExamViewModel> examViews = new List<ExamViewModel>();
            foreach (Exam exam in ctx.Exams)
            {
                examViews.Add(new ExamViewModel
                {
                    ExamId = exam.ExamId,
                    ExamSearchId = exam.ExamSearchId,
                    ExamName = exam.ExamName,
                    ClassName = exam.ClassName,
                    StartTime = exam.StartTime,
                    EndTime= exam.EndTime,
                    QuestionNum = exam.QuestionNum,
                    IsFinished = exam.IsFinished,
                    IsPublic = exam.IsPublic
                });
            }
            return examViews;
        }

        public ExamViewModel GetExam(string examId)
        {
            Exam exam = ctx.Exams.Find(examId);

            if (exam == null)
                return null;

            ICollection<QuestionViewModel> questionViews = new List<QuestionViewModel>();
            foreach (Question Quest in exam.Questions)
            {
                ICollection<ChoiceViewModel> choiceViews = new List<ChoiceViewModel>();
                foreach (Choice choice in Quest.Choices)
                {
                    choiceViews.Add(new ChoiceViewModel
                    {
                        ChoiceDescription = choice.ChoiceDescription,
                        ChoiceNum = choice.ChoiceNum,
                        IsCorrect = choice.IsCorrect
                    });
                }
                questionViews.Add(new QuestionViewModel
                {
                    QuestionDescription = Quest.QuestionDescription,
                    QuestionNum = Quest.QuestionNum,
                    QuestionTypeId = Quest.TypeId,
                    Choices = choiceViews
                });
            }

            ExamViewModel examView = new ExamViewModel
            {
                ExamId = exam.ExamId,
                ExamSearchId = exam.ExamSearchId,
                ExamName = exam.ExamName,
                ClassName = exam.ClassName,
                QuestionNum = exam.QuestionNum,
                StartTime = exam.StartTime,
                EndTime = exam.EndTime,
                IsFinished = exam.IsFinished,
                IsPublic = exam.IsPublic,
                Questions = questionViews
            };

            return examView;
        }

        public bool CreateExam(ExamViewModel examView, string creatorId)
        {
            ICollection<Question> questions = new List<Question>();
            foreach (QuestionViewModel Quest in examView.Questions)
            {
                ICollection<Choice> choices = new List<Choice>();
                foreach (ChoiceViewModel ch in Quest.Choices)
                {
                    choices.Add(
                    new Choice
                    {
                        ExamId = examView.ExamId,
                        QuestionId = Quest.QuestionNum,
                        ChoiceDescription = ch.ChoiceDescription,
                        ChoiceNum = ch.ChoiceNum,
                        IsCorrect = ch.IsCorrect,
                    });
                }

                questions.Add(
                new Question
                {
                    //Exam = exam,
                    ExamId = examView.ExamId,
                    QuestionDescription = Quest.QuestionDescription,
                    QuestionNum = Quest.QuestionNum,
                    TypeId = Quest.QuestionTypeId,
                    Choices = choices
                });
            }

            Exam exam = new Exam()
            {
                CreatorId = creatorId,
                //Creator = GetHashCode from token?
                ClassName = examView.ClassName,
                ExamId = examView.ExamId, //is this needed?
                ExamSearchId = examView.ExamSearchId,
                ExamName = examView.ExamName,
                StartTime = examView.StartTime,
                EndTime = examView.EndTime,
                IsPublic = examView.IsPublic,
                IsFinished = examView.IsFinished,
                QuestionNum = examView.QuestionNum,
                Questions = questions,
            };

            ctx.Exams.Add(exam);
            //do we also add the questions and choices?
            //Answer is no. it is added automatically via the one line above

            return true;//check
        }

        public bool UpdateExam(ExamViewModel examView, string ExamId)
        {

            this.DeleteExam(ExamId);
            ctx.SaveChanges();
            this.CreateExam(examView,"q");
            //the reason I wrote it like this is that
            //some rows from questions & choices could be
            //added or deleted, so the commented lines won't work

            return true;
        }

        public bool DeleteExam(string examId)
        {
            ctx.Exams.Remove(ctx.Exams.Find(examId));
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            else return false;
        }

    }
}
