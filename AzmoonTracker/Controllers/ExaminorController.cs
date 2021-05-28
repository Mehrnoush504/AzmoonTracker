using AzmoonTracker.Services.ExamRepository;
using AzmoonTracker.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzmoonTracker.Controllers
{
    [Route("api/Exam")]
    [ApiController]
    public class ExaminorController : ControllerBase
    {
        private readonly IExamRepository examRepository;

        public ExaminorController(IExamRepository _examRepository)
        {
            examRepository=_examRepository;
        }

        [HttpGet("/GetAll")]
        public IActionResult GetAllExams()
        {
            return Ok(examRepository.GetAllExams());
        }

        [HttpGet("/Get/{ExamId}")]
        public IActionResult GetExam(String ExamId)
        {
            ExamViewModel examView = examRepository.GetExam(ExamId);
            if (examView == null)
                return NotFound();
            else
                return Ok(examView);
        }

        [HttpPost("/Create/")]
        public async Task<IActionResult> CreateExam(ExamViewModel examView)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if(!examRepository.CreateExam(examView,"q"))
                {
                    return BadRequest();
                }
            }

            if (! await examRepository.SaveChangesAsync())
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                //or return notfound();?
            }

            return Ok();
        }

        [HttpPut("/Update/{prevExamId}")]
        public async Task<IActionResult> UpdateExamAsync(ExamViewModel examView, String prevExamId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if (!examRepository.UpdateExam(examView, prevExamId))
                {
                    return BadRequest();
                }
            }

            if (!await examRepository.SaveChangesAsync())
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                //or return notfound();?
            }
            return Ok();
        }

        [HttpDelete("/Delete/{ExamId}")]
        public async Task<IActionResult> DeleteExamAsync(String ExamId)
        {
            if(!examRepository.DeleteExam(ExamId))
            {
                return NotFound();
            }

            if (!await examRepository.SaveChangesAsync())
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                //or return notfound();?
            }
            return Ok();
        }
    }
}
