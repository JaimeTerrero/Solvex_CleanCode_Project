using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Assignments.DTOs;
using VirtPlatform.Application.Assignments.Interfaces;
using VirtPlatform.Domain.Interfaces.Repositories.Assignments;

namespace VirtPlatform.Application.Assignments.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public async Task<Assignment> Add(AssignmentDto assignmentDto)
        {
            var assignment = _mapper.Map<Assignment>(assignmentDto);
            await _assignmentRepository.AddAsync(assignment);
            return assignment;
        }

        public async Task Delete(int id)
        {
            await _assignmentRepository.DeleteAsync(id);
        }

        public async Task<List<Assignment>> GetAll()
        {
            var assignmentList = await _assignmentRepository.GetAllAsync();

            return assignmentList;
        }

        public async Task<Assignment> GetById(int id)
        {
            var assingment = await _assignmentRepository.GetByIdAsync(id);

            Assignment assgm = new();
            assgm.Id = assingment.Id;
            assgm.Title = assingment.Title;
            assgm.DeliveryDeadLine = assingment.DeliveryDeadLine;
            assgm.UserId = assingment.UserId;
            assgm.SubjectId = assingment.SubjectId;

            return assgm;
        }

        public async Task Update(int id, AssignmentDto assignmentDto)
        {
            Assignment assignment = await _assignmentRepository.GetByIdAsync(id);

            _mapper.Map(assignmentDto, assignment);

            await _assignmentRepository.UpdateAsync(assignment);
        }
    }
}
