using System.Collections.Generic;
using Domain.Entities;
using Domain.IRepositories;
using Domain.IServices;

namespace Application.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public bool Create(Classroom classroom)
        {
            return _classroomRepository.Insert(classroom);
        }

        public bool Delete(Classroom classroom)
        {
           return _classroomRepository.Delete(classroom);
        }

        public List<Classroom> GetAll()
        {
            return _classroomRepository.GetAll();
        }

        public Classroom GetById(int id)
        {
            return _classroomRepository.GetById(id);
        }

        public bool Update(Classroom classroom)
        {
            return _classroomRepository.Update(classroom);
        }
    }
}
