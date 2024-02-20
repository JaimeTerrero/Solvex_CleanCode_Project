using Domain.Entities;
using Moq;
using Solvex_CleanCode_Project.Controllers.Subjects;
using VirtPlatform.Application.Subjects.DTOs;
using VirtPlatform.Application.Subjects.Interfaces;

namespace VirtPlatform.Test
{
    [TestClass]
    public class SubjectControllerTest
    {
        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnSubject_WhenUserExits()
        {
            // Arrange
            var subject = new Subject
            {
                Id = 1,
                Name = "Test",
                UserId = 1,
            };

            var subjectService = new Mock<ISubjectService>();
            subjectService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(subject));
            var controller = new SubjectController(subjectService.Object);

            // Act
            var getSubjectById = controller.GetSubjectById(1);

            // Assert
            Assert.IsNotNull(getSubjectById);   
        }

        [TestMethod]
        public async Task AddAsync_ShouldAddSubject_WhenSubjectIsValid()
        {
            var subject = new Subject
            {
                Name = "Programación Orientada a Objetos",
                UserId = 1,
            };

            var subjectService = new Mock<ISubjectService>();
            subjectService.Setup(x => x.Add(It.IsAny<SubjectDto>())).Returns(Task.FromResult(subject));
            var controller = new SubjectController(subjectService.Object);

            SubjectDto sjt = new();
            sjt.Name = subject.Name;
            sjt.UserId = subject.UserId;

            var addSubject = await controller.CreateSubject(sjt);

            Assert.IsNotNull(addSubject);
        }

        [TestMethod]
        public async Task UpdateAsync_ShouldUpdateSubject_WhenSubjectIsValid()
        {
            // Arrange
            var subject = new Subject
            {
                Name = "Programación Orientada a Objetos",
                UserId = 1,
            };

            var updatedSubjectDto = new SubjectDto
            {
                Name = "Base de Datos Avanzada",
                UserId = 1,
            };

            var subjectService = new Mock<ISubjectService>();
            subjectService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(subject));
            subjectService.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<SubjectDto>())).Callback((int id, SubjectDto s) =>
            {
                subject.Name = s.Name;
                subject.UserId = s.UserId;
            });

            var controller = new SubjectController(subjectService.Object);

            // Act
            await controller.UpdateSubject(subject.Id, updatedSubjectDto);

            // Assert
            Assert.AreEqual(updatedSubjectDto.Name, subject.Name);
            Assert.AreEqual(updatedSubjectDto.UserId, subject.UserId);
        }

        [TestMethod]
        public async Task DeleteAsync_ShouldDeleteSubject_WhenIdIsValid()
        {
            // Arrange
            var subject = new Subject
            {
                Id = 1,
                Name = "Test",
                UserId = 1,
            };

            var subjectService = new Mock<ISubjectService>();
            subjectService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(subject));
            subjectService.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
            var controller = new SubjectController(subjectService.Object);

            // Act
            await controller.DeleteSuject(subject.Id);

            // Assert
            subjectService.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}