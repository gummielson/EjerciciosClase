using AutoMapper;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Infrastructure.Test
{
    public class ClassroomRepositoryTestSuite
    {
        private Mock<EducationEntities> _dbConnectionMock;
        private Mock<Mapper> _mapperMock;
        private ClassroomRepository _classroomRepository;

        public ClassroomRepositoryTestSuite()
        {
            _dbConnectionMock = new Mock<EducationEntities>();
            _mapperMock = new Mock<Mapper>();
            _classroomRepository = new ClassroomRepository();
        }

        [Fact]
        public void GetAll_Should_Return_All_Classrooms()
        {

        }
    }
}
