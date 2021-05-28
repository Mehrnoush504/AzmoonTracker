using AzmoonTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonTracker.Services.ExamRepository
{
    public interface IExamRepository
    {
        //Create Exam
        bool CreateExam(ExamViewModel examView, string creatorId);

        //Delete Exam
        bool DeleteExam(string examId);

        //Update Exam
        bool UpdateExam(ExamViewModel examView, string prevExamId);

        //Get Exam
        ExamViewModel GetExam(string examId);

        //Get All Exams
        ICollection<ExamViewModel> GetAllExams();

        Task<bool> SaveChangesAsync();
    }
}
