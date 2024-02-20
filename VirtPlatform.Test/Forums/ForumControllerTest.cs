using Domain.Entities;
using Moq;
using Solvex_CleanCode_Project.Controllers.Forums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Forums.DTOs;
using VirtPlatform.Application.Forums.Interfaces;

namespace VirtPlatform.Test.Forums
{
    [TestClass]
    public class ForumControllerTest
    {
        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnForum_WhenForumExits()
        {
            // Arrange
            var forum = new Forum
            {
                Id = 1,
                Content = "Duda acerca del proyecto",
                DeliveredDate = DateTime.Now,
                UserId = 1,
                SubjectId = 1
            };

            var forumService = new Mock<IForumService>();
            forumService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(forum));
            var controller = new ForumController(forumService.Object);

            // Act
            var getForumById = controller.GetForumById(1);

            // Assert
            Assert.IsNotNull(getForumById);
        }

        [TestMethod]
        public async Task AddAsync_ShouldAddForum_WhenForumIsValid()
        {
            // Arrange
            var forum = new Forum
            {
                Content = "Necesito ayuda",
                DeliveredDate = DateTime.Now,
                UserId = 1,
                SubjectId = 1
            };

            var forumService = new Mock<IForumService>();
            forumService.Setup(x => x.Add(It.IsAny<ForumDto>())).Returns(Task.FromResult(forum));
            var controller = new ForumController(forumService.Object);

            ForumDto fr = new();
            fr.Content = forum.Content;
            fr.DeliveredDate = forum.DeliveredDate;
            fr.UserId = forum.UserId;
            fr.SubjectId = forum.SubjectId;

            // Act
            var addForum = await controller.CreateForum(fr);

            // Assert
            Assert.IsNotNull(addForum);
        }

        [TestMethod]
        public async Task UpdateAsync_ShouldUpdateForum_WhenForumIsValid()
        {
            // Arrange
            var forum = new Forum
            {
                Content = "Necesito ayuda",
                DeliveredDate = DateTime.Now,
                UserId = 1,
                SubjectId = 1
            };

            var updatedForumDto = new ForumDto
            {
                Content = "Toma tu ayuda",
                DeliveredDate = DateTime.Now,
                UserId = 1,
                SubjectId = 2
            };

            var forumService = new Mock<IForumService>();
            forumService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(forum));
            forumService.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ForumDto>())).Callback((int id, ForumDto f) =>
            {
                forum.Content = f.Content;
                forum.DeliveredDate = f.DeliveredDate;
                forum.UserId = f.UserId;
                forum.SubjectId = f.SubjectId;
            });

            var controller = new ForumController(forumService.Object);

            // Act
            await controller.UpdateForum(forum.Id, updatedForumDto);

            // Assert
            Assert.AreEqual(updatedForumDto.Content, forum.Content);
            Assert.AreEqual(updatedForumDto.DeliveredDate, forum.DeliveredDate);
            Assert.AreEqual(updatedForumDto.UserId, forum.UserId);
            Assert.AreEqual(updatedForumDto.SubjectId, forum.SubjectId);
        }

        [TestMethod]
        public async Task DeleteAsync_ShouldDeleteForum_WhenIdIsValid()
        {
            // Arrange
            var forum = new Forum
            {
                Id = 1,
                Content = "Cómo hago esta vaina?",
                DeliveredDate = DateTime.Now,
                UserId = 2,
                SubjectId = 2,
            };

            var forumService = new Mock<IForumService>();
            forumService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(forum));
            forumService.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
            var controller = new ForumController(forumService.Object);

            // Act
            await controller.DeleteForum(forum.Id);

            // Assert
            forumService.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
