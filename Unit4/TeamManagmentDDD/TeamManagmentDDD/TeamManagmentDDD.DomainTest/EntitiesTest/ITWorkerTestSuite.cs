using System;
using Business.Validations;
using Domain.Entities;
using Xunit;
using static Infrastructure.Utils.Enums.Enums;

namespace TeamManagmentDDD.DomainTest.EntitiesTest
{
    public class ITWorkerTestSuite
    {
        private readonly ValidateDataAnnotations _validator = new ValidateDataAnnotations(); 

        [Fact]
        public void CanBeSenior_YearsOfExperienceLessThan5AndITLevelSenior_ThrowsException()
        {
            // Arrange
            var worker = new ITWorker
            {
                YearsOfExperience = 3,
                ITLevel = Level.Senior
            };

            // Act and Assert
            Assert.Throws<Exception>(() => worker.CanBeSenior());
        }

        [Fact]
        public void CanBeSenior_YearsOfExperienceEqualTo5AndITLevelSenior_NoExceptionThrown()
        {
            // Arrange
            var worker = new ITWorker
            {
                YearsOfExperience = 8,
                ITLevel = Level.Senior
            };

            // Act
            var ex = Record.Exception(() => worker.CanBeSenior());

            // Act and Assert
            Assert.Null(ex);
        }

        [Fact]
        public void CanBeManager_ITLevelNotSeniorAndWorkerRolManager_ThrowsException()
        {
            // Arrange
            var worker = new ITWorker
            {
                ITLevel = Level.Junior,
                WorkerRol = Rol.Manager
            };

            // Act and Assert
            Assert.Throws<Exception>(() => worker.CanBeManager());
        }

        [Fact]
        public void CanBeManager_ITLevelNotSeniorAndWorkerRolManager_ThrowsNoException()
        {
            // Arrange
            var worker = new ITWorker
            {
                ITLevel = Level.Senior,
                WorkerRol = Rol.Manager
            };

            // Act
            var ex = Record.Exception(() => worker.CanBeManager());


            // Assert
            Assert.Null(ex);
        }

        [Fact]
        public void ChangeRol_NewRolAssigned()
        {
            // Arrange
            ITWorker worker = new ITWorker();
            Rol newRol = Rol.Admin;

            // Act
            worker.ChangeRol(newRol);

            // Assert
            Assert.Equal(worker.WorkerRol, newRol);
        }

        [Fact]
        public void DataAnnotations_YearsOfExperienceLessThan0_ThrowsException()
        {
            // Arrange
            var worker = new ITWorker
            {
                YearsOfExperience = -5
            };

            // Act and Assert
            Assert.Throws<Exception>(() => _validator.ValidateObject(worker));
        }

    }
}
