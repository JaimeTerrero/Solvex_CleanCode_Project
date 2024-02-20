using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Users.DTOs.Assignments;
using VirtPlatform.Application.Users.DTOs.Subjects;
using VirtPlatform.Application.Users.Interfaces.Subjects;
using VirtPlatform.Domain.Interfaces.Repositories.Subjects;

namespace VirtPlatform.Application.Users.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<Subject> Add(SubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            await _subjectRepository.AddAsync(subject);
            return subject;
        }

        public async Task Delete(int id)
        {
            await _subjectRepository.DeleteAsync(id);
        }

        public async Task<List<Subject>> GetAll()
        {
            var subject = await _subjectRepository.GetAllAsync();

            return subject;
        }

        public async Task<Subject> GetById(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);

            Subject sbj = new();
            sbj.Id = subject.Id;
            sbj.Name = subject.Name;
            sbj.UserId = subject.UserId;

            return sbj;
        }

        public async Task Update(int id, SubjectDto subjectDto)
        {
            Subject subject = await _subjectRepository.GetByIdAsync(id);

            _mapper.Map(subjectDto, subject);

            await _subjectRepository.UpdateAsync(subject);
        }
    }
}
