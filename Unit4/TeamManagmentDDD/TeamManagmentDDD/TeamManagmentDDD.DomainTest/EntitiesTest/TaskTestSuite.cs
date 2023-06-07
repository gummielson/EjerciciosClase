using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Xunit;
using static Infrastructure.Utils.Enums.Enums;

namespace TeamManagmentDDD.DomainTest.EntitiesTest
{
    public class TaskTestSuite
    {
        [Fact]
        public void ChangeStatus_ChangeStatusToNewStatus()
        {
            // Arrange
            TaskEntity task = new TaskEntity();
            Status newStatus = Status.Doing;

            // Act
            task.ChangeStatus(newStatus);

            // Assert
            Assert.Equal(task.TaskStatus, newStatus);
        }
    }
}
