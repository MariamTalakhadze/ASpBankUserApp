using AutoMapper;
using Business.Entity;
using ASpBankUserApp.Bussiness.IServiceInterface;
using ASpBankUserApp.Models;
using Models.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Service
{
    public class CityService : ICityService
    {
        private readonly UnitOfWork _unitOfWork;

        public CityService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public IEnumerable<CityEntity> GetAllCity()
        {
            var city = _unitOfWork.CityRepository.GetAll().ToList();
            if (city.Any())
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<City, CityEntity>();
                });
                IMapper mapper = config.CreateMapper();

                var cityModel = mapper.Map<List<City>, List<CityEntity>>(city);
                return cityModel;
            }
            return null;
        }

        public CityEntity GetCityByID(int CityId)
        {
            var city = _unitOfWork.CityRepository.GetByID(CityId);
            if (city != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<City, CityEntity>();
                });
                IMapper mapper = config.CreateMapper();

                var cityModel = mapper.Map<City, CityEntity>(city);
                return cityModel;
            }
            return null;
        }
    }
}
