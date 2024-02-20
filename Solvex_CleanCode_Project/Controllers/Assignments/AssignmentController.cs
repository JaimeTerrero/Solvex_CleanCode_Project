using Microsoft.AspNetCore.Mvc;
using VirtPlatform.Application.Assignments.DTOs;
using VirtPlatform.Application.Assignments.Interfaces;

namespace Solvex_CleanCode_Project.Controllers.Assignments
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet("GetAllAssignments")]
        public async Task<ActionResult> GetAllAssigments()
        {
            var assignment = await _assignmentService.GetAll();

            return Ok(assignment);
        }

        [HttpPost("CreateAssignment")]
        public async Task<ActionResult> CreateAssignment(AssignmentDto assignmentDto)
        {
            var assignment = await _assignmentService.Add(assignmentDto);

            return Ok(assignment);
        }

        [HttpGet("GetAssignmentById/{id:int}")]
        public async Task<ActionResult> GetAssignmentById(int id)
        {
            var assignment = await _assignmentService.GetById(id);

            return Ok(assignment);
        }

        [HttpPut("UpdateAssignment/{id:int}")]
        public async Task<ActionResult> UpdateAssignment(int id, AssignmentDto assignmentDto)
        {
            await _assignmentService.Update(id, assignmentDto);

            return NoContent();
        }

        [HttpDelete("DeleteAssignment/{id:int}")]
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            await _assignmentService.Delete(id);

            return NoContent();
        }
    }
}
