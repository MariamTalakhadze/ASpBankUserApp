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
    public class CountryService : ICountryService
    {

        private readonly UnitOfWork _unitOfWork;

        public CountryService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public IEnumerable<CountryEntity> GetAllCountry()
        {
            var country = _unitOfWork.CountryRepository.GetAll().ToList();
            if (country.Any())
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Country, CountryEntity>();
                });
                IMapper mapper = config.CreateMapper();

                var Countrymodel = mapper.Map<List<Country>, List<CountryEntity>>(country);
                return Countrymodel;
            }
            return null;
        }

        public CountryEntity GetCountryByID(int CityId)
        {
            var country = _unitOfWork.CountryRepository.GetByID(CityId);
            if (country != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Country, CountryEntity>();
                });
                IMapper mapper = config.CreateMapper();

                var Countrymodel = mapper.Map<Country, CountryEntity>(country);
                return Countrymodel;
            }
            return null;
        }
    }
}
