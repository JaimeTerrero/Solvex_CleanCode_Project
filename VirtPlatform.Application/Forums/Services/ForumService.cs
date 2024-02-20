using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Forums.DTOs;
using VirtPlatform.Application.Forums.Interfaces;
using VirtPlatform.Domain.Interfaces.Repositories.Forums;

namespace VirtPlatform.Application.Forums.Services
{
    public class ForumService : IForumService
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ForumService(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository;
            _mapper = mapper;
        }

        public async Task<Forum> Add(ForumDto forumDto)
        {
            var forum = _mapper.Map<Forum>(forumDto);
            await _forumRepository.AddAsync(forum);
            return forum;
        }

        public async Task Delete(int id)
        {
            await _forumRepository.DeleteAsync(id);
        }

        public async Task<List<Forum>> GetAll()
        {
            var forum = await _forumRepository.GetAllAsync();

            return forum;
        }

        public async Task<Forum> GetById(int id)
        {
            var forum = await _forumRepository.GetByIdAsync(id);

            Forum fr = new();
            fr.Id = forum.Id;
            fr.Content = forum.Content;
            fr.DeliveredDate = forum.DeliveredDate;
            fr.UserId = forum.UserId;
            fr.SubjectId = forum.SubjectId;

            return fr;
        }

        public async Task Update(int id, ForumDto forumDto)
        {
            Forum forum = await _forumRepository.GetByIdAsync(id);

            _mapper.Map(forumDto, forum);

            await _forumRepository.UpdateAsync(forum);
        }
    }
}
