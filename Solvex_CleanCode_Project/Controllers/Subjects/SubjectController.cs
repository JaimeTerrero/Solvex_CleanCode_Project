using Microsoft.AspNetCore.Mvc;
using VirtPlatform.Application.Users.DTOs.Subjects;
using VirtPlatform.Application.Users.Interfaces.Subjects;

namespace Solvex_CleanCode_Project.Controllers.Subjects
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("GetAllSubjects")]
        public async Task<ActionResult> GetAllSubjects()
        {
            var subject = await _subjectService.GetAll();

            return Ok(subject);
        }

        [HttpPost("CreateSubject")]
        public async Task<ActionResult> CreateSubject(SubjectDto subjectDto)
        {
            var subject = await _subjectService.Add(subjectDto);

            return Ok(subject);
        }

        [HttpGet("GetSubjectById/{id:int}")]
        public async Task<ActionResult> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetById(id);

            return Ok(subject);
        }

        [HttpPut("UpdateSubject/{id:int}")]
        public async Task<ActionResult> UpdateSubject(int id, SubjectDto subjectDto)
        {
            await _subjectService.Update(id, subjectDto);

            return NoContent();
        }

        [HttpDelete("DeleteSubject/{id:int}")]
        public async Task<ActionResult> DeleteSuject(int id)
        {
            await _subjectService.Delete(id);

            return NoContent();
        }
    }
}
