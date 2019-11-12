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

namespace BusinessServices.Services
{
    public class SponsorTypeService : ISponsorTypeService
    {
        private readonly UnitOfWork _unitOfWork;

        public SponsorTypeService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public IEnumerable<SponsorTypeEntity> GetAllSponsorTypes()
        {
            var SponsorType = _unitOfWork.SponsorTypeRepository.GetAll().ToList();
            if (SponsorType.Any())
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<SponsorType, SponsorTypeEntity>();
                });
                IMapper mapper = config.CreateMapper();

                var SponsorModel = mapper.Map<List<SponsorType>, List<SponsorTypeEntity>>(SponsorType);
                return SponsorModel;
            }
            return null;
        }
        public SponsorTypeEntity GetSponsorTypeByID(int SponsorTypeID)
        {
            var SponsorType = _unitOfWork.SponsorTypeRepository.GetByID(SponsorTypeID);
            if (SponsorType != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<SponsorType, SponsorTypeEntity>();
                });
                IMapper mapper = config.CreateMapper();
                var SponsorModel = mapper.Map<SponsorType, SponsorTypeEntity>(SponsorType);
                return SponsorModel; 
            }
            return null;
        }
    }
}
