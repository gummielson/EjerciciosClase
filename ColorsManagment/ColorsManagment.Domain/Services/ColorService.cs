using System;
using ColorsManagment.Domain.CustomExceptions;
using ColorsManagment.Domain.Entities;
using ColorsManagment.Domain.RepositoriesContracts;
using ColorsManagment.Domain.ServicesContracts;
using ColorsManagment.Domain.Validations;

namespace ColorsManagment.Domain.Services
{
    public class ColorService : IColorServices
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository repository)
        {
            _colorRepository = repository;
        }

        public void Register(ColorEntity color)
        {
            color.ValidateObject();

            try
            {
                _colorRepository.Insert(color);
            }
            catch (Exception ex)
            {
                throw new CannotInsertDataException(ex.Message);
            }
        }
    }
}
