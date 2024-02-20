using Domain.Entities;
using Moq;
using Solvex_CleanCode_Project.Controllers.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Users.DTOs;
using VirtPlatform.Application.Users.Interfaces;

namespace VirtPlatform.Test.Users
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnUser_WhenUserExits()
        {
            var user = new User
            {
                Id = 1,
                Name = "Jaime",
                LastName = "Terrero",
                Email = "jaimeterero28@gmail.com",
                Password = "1234",
                Role = "Estudiante",
                Token = ""
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(user));
            var controller = new UserController(userService.Object);

            var getUserById = controller.GetUserById(1);

            Assert.IsNotNull(getUserById);
        }

        [TestMethod]
        public async Task Register_ShouldCreateUser_WhenSignUpIsValid()
        {
            // Arrange
            var signUp = new SignUp
            {
                Name = "Fulano",
                LastName = "de tal",
                Email = "fulanodetal@outlook.com",
                Role = "Profesor",
                Password = "testPassword"
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.Register(It.IsAny<SignUp>())).Returns(Task.FromResult(new User()));
            var controller = new UserController(userService.Object);

            // Act
            var registerUser = await controller.RegisterUser(signUp);

            // Assert
            Assert.IsNotNull(registerUser);
        }

        [TestMethod]
        public async Task UpdateAsync_ShouldUpdateUser_WhenUserIsValid()
        {
            var user = new User
            {
                Name = "Fulano",
                LastName = "de tal",
                Email = "fulanodetal@outlook.com",
                Role = "Profesor",
                Password = "testPassword"
            };

            var updatedUserDto = new UserDto
            {
                Name = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                Role = "Profesor",
                Password = "maripositalindae"
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(user));
            userService.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<UserDto>())).Callback((int id, UserDto u) =>
            {
                user.Name = u.Name;
                user.LastName = u.LastName;
                user.Email = u.Email;
                user.Role = u.Role;
                user.Password = u.Password;
            });

            var controller = new UserController(userService.Object);

            await controller.UpdateUser(user.Id, updatedUserDto);

            Assert.AreEqual(updatedUserDto.Name, user.Name);
            Assert.AreEqual(updatedUserDto.LastName, user.LastName);
            Assert.AreEqual(updatedUserDto.Email, user.Email);
            Assert.AreEqual(updatedUserDto.Role, user.Role);
            Assert.AreEqual(updatedUserDto.Password, user.Password);
        }

        [TestMethod]
        public async Task DeleteAsync_ShouldDeleteUser_WhenIdIsValid()
        {
            var user = new User
            {
                Id = 1,
                Name = "Jane",
                LastName = "Doe",
                Email = "janedoe@gmail.com",
                Role = "Estudiante",
                Password = "delomio123"
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(user));
            userService.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
            var controller = new UserController(userService.Object);

            await controller.DeleteUser(user.Id);

            userService.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
