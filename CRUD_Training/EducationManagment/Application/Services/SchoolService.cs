using System.Collections.Generic;
using Domain.Entities;
using Domain.IRepositories;
using Domain.IServices;

namespace Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository) 
        {
            _schoolRepository = schoolRepository;
        }
        
        public bool Create(School entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(School entity)
        {
            throw new System.NotImplementedException();
        }

        public List<School> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public School GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(School entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
