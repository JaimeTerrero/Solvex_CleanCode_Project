using Domain.Entities;
using Moq;
using Solvex_CleanCode_Project.Controllers.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Assignments.DTOs;
using VirtPlatform.Application.Assignments.Interfaces;

namespace VirtPlatform.Test.Assignments
{
    [TestClass]
    public class AssignmentControllerTest
    {
        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnAssignment_WhenAssignmentExits()
        {
            // Arrange
            var assignment = new Assignment
            {
                Id = 1,
                Title = "Crear cuenta de Gitlab",
                DeliveryDeadLine = DateTime.Now,
                UserId = 2,
                SubjectId = 3
            };

            var assignmentService = new Mock<IAssignmentService>();
            assignmentService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(assignment));
            var controller = new AssignmentController(assignmentService.Object);

            // Act
            var getAssignmentById = controller.GetAssignmentById(1);
            
            // Assert
            Assert.IsNotNull(getAssignmentById);
        }

        [TestMethod]
        public async Task AddAsync_ShouldAddAssignment_WhenAssignmentIsValid()
        {
            // Arrange
            var assignment = new Assignment
            {
                Title = "Crear cuenta de LeetCode",
                DeliveryDeadLine = DateTime.Now,
                UserId = 2,
                SubjectId = 3
            };

            var assignmentService = new Mock<IAssignmentService>();
            assignmentService.Setup(x => x.Add(It.IsAny<AssignmentDto>())).Returns(Task.FromResult(assignment));
            var controller = new AssignmentController(assignmentService.Object);

            AssignmentDto asgm = new();
            asgm.Title = assignment.Title;
            asgm.DeliveryDeadLine = assignment.DeliveryDeadLine;
            asgm.UserId = assignment.UserId;
            asgm.SubjectId = assignment.SubjectId;

            // Act
            var addAssignment = await controller.CreateAssignment(asgm);

            // Assert
            Assert.IsNotNull(addAssignment);
        }

        [TestMethod]
        public async Task UpdateAsync_ShouldUpdateAssignment_WhenAssignmentIsValid()
        {
            // Arrange
            var assignment = new Assignment
            {
                Title = "Crear cuenta de Gitlab",
                DeliveryDeadLine = DateTime.Now,
                UserId = 2,
                SubjectId = 3
            };

            var updatedAssignmentDto = new AssignmentDto
            {
                Title = "Crear cuenta de Github",
                DeliveryDeadLine = DateTime.Now,
                UserId = 1,
                SubjectId = 3
            };

            var assignmentService = new Mock<IAssignmentService>();
            assignmentService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(assignment));
            assignmentService.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<AssignmentDto>())).Callback((int id, AssignmentDto a) =>
            {
                assignment.Title = a.Title;
                assignment.DeliveryDeadLine = a.DeliveryDeadLine;
                assignment.UserId = a.UserId;
                assignment.SubjectId = a.SubjectId;
            });

            var controller = new AssignmentController(assignmentService.Object);

            // Act
            await controller.UpdateAssignment(assignment.Id, updatedAssignmentDto);

            // Assert
            Assert.AreEqual(updatedAssignmentDto.Title, assignment.Title);
            Assert.AreEqual(updatedAssignmentDto.DeliveryDeadLine, assignment.DeliveryDeadLine);
            Assert.AreEqual(updatedAssignmentDto.UserId, assignment.UserId);
            Assert.AreEqual(updatedAssignmentDto.SubjectId, assignment.SubjectId);
        }

        [TestMethod]
        public async Task DeleteAsync_ShouldDeleteAssignment_WhenIdIsValid()
        {
            var assignment = new Assignment
            {
                Id = 1,
                Title = "Crear cuenta de Gmail",
                DeliveryDeadLine = DateTime.Now,
                UserId = 1,
                SubjectId = 3
            };

            var assignmentService = new Mock<IAssignmentService>();
            assignmentService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(assignment));
            assignmentService.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
            var controller = new AssignmentController(assignmentService.Object);

            await controller.DeleteAssignment(assignment.Id);

            assignmentService.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
