using System.Collections.Generic;
using Domain.Entities;
using Domain.IRepositories;
using Domain.IServices;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public bool Create(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Student entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
