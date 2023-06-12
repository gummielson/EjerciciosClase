using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.AutoMapper;
using Infrastructure.DataModel;

namespace Infrastructure.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly Mapper _mapper;
        private readonly EducationEntities _dbConnection;

        public ClassroomRepository()
        {
            _dbConnection = new EducationEntities();
            _mapper = AutoMapperConfig.Initialize();
        }

        public bool Delete(Classroom entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Classroom> GetAll()
        {
            using(_dbConnection) 
            {
                List<Classroom> response = _mapper.Map<List<Classroom>>(_dbConnection.Classrooms);
               
                //foreach(var classroom in _dbConnection.Classrooms) 
                //{
                //    response.Add(_mapper.Map<Classroom>(classroom));
                //}

                return response;
            }
        }

        public Classroom GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Classroom entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Classroom entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
