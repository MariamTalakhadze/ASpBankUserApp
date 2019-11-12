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
    public class GenderService : IGenderService
    {

        private readonly UnitOfWork _unitOfWork;

        public GenderService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<GenderEntity> GetAkkGender()
        {
            var gender = _unitOfWork.GenderRepository.GetAll().ToList();
            if (gender.Any())
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Gender, GenderEntity>();
                });
                IMapper mapper = config.CreateMapper();

                var GenderModel = mapper.Map<List<Gender>, List<GenderEntity>>(gender);
                return GenderModel;
            }
            return null;
        }

        public GenderEntity GetGenderByID(int GenderId)
        {

            var gender = _unitOfWork.GenderRepository.GetByID(GenderId);
            if (gender != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Gender, GenderEntity>();
                });
                IMapper mapper = config.CreateMapper();

                var genderModel = mapper.Map<Gender, GenderEntity>(gender);

                return genderModel;
            }
            return null;
        }
    }
}
