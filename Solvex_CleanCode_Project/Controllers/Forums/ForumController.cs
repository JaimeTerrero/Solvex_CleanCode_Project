using Microsoft.AspNetCore.Mvc;
using VirtPlatform.Application.Forums.DTOs;
using VirtPlatform.Application.Forums.Interfaces;

namespace Solvex_CleanCode_Project.Controllers.Forums
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet("GetAllForums")]
        public async Task<ActionResult> GetAllForums()
        {
            var forum = await _forumService.GetAll();

            return Ok(forum);
        }

        [HttpPost("CreateForum")]
        public async Task<ActionResult> CreateForum(ForumDto forumDto)
        {
            var forum = await _forumService.Add(forumDto);

            return Ok(forum);
        }

        [HttpGet("GetForumById/{id:int}")]
        public async Task<ActionResult> GetForumById(int id)
        {
            var forum = await _forumService.GetById(id);

            return Ok(forum);
        }

        [HttpPut("UpdateForum/{id:int}")]
        public async Task<ActionResult> UpdateForum(int id, ForumDto forumDto)
        {
            await _forumService.Update(id, forumDto);

            return NoContent();
        }

        [HttpDelete("DeleteForum/{id:int}")]
        public async Task<ActionResult> DeleteForum(int id)
        {
            await _forumService.Delete(id);

            return NoContent();
        }
    }
}
