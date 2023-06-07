using System;
using Domain.Entities;
using Xunit;
using static Infrastructure.Utils.Enums.Enums;

namespace TeamManagmentDDD.DomainTest.EntitiesTest
{
    public class TeamTestSuite
    {
        [Fact]
        public void AssignManager_ValidSeniorWorker_SetManager()
        {
            //Arrange
            Team team = new Team();
            ITWorker iTWorker = new ITWorker()
            {
                ITLevel = Level.Senior
            };

            //Act
            team.AssignManager(iTWorker);

            //Assert
            Assert.Equal(team.Manager, iTWorker);
        }

        [Fact]
        public void AssignManager_NoSeniorWorker_ThrowException()
        {
            // Arrange
            Team team = new Team();
            ITWorker iTWorker = new ITWorker()
            {
                ITLevel = Level.Junior
            };

            // Act and Assert
            Assert.Throws<Exception>(() => team.AssignManager(iTWorker));
        }

        [Fact]
        public void AddTechnician_NewITWorkerAddedToList()
        {
            // Arrange
            ITWorker iTWorker = new ITWorker();
            Team team = new Team();

            // Act
            team.AddTechnician(iTWorker);

            // Assert
            Assert.Contains<ITWorker>(iTWorker, team.Technicians);
        }

        [Fact]
        public void HasAManager_ManagerIsNull_ThrowsException()
        {
            // Arrange
            Team team = new Team()
            {
                Manager = new ITWorker()
            };

            // Act and Assert
            Assert.Throws<Exception>(() => team.HasAManager());
        }

        [Fact]
        public void HasAManager_ThrowsNoException()
        {
            // Arrange
            Team team = new Team();

            // Act
            var ex = Record.Exception(() => team.HasAManager());

            // Assert
            Assert.Null(ex);
        }
    }
}
