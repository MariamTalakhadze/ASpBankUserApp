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
    public class OfferService : IOfferService
    {
        private readonly UnitOfWork _unitOfWork;

        public OfferService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public IEnumerable<OfferEntity> GetAllOffer()
        {
            var offer = _unitOfWork.OfferRepository.GetAll().ToList();
            if (offer.Any())
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Offer, OfferEntity>();
                });
                IMapper mapper = config.CreateMapper();

                var offerModel = mapper.Map<List<Offer>, List<OfferEntity>>(offer);
                return offerModel;
            }
            return null;
        }

        public OfferEntity GetOfferByID(int OfferID)
        {
            var offer = _unitOfWork.OfferRepository.GetByID(OfferID);
            if (offer != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Offer, OfferEntity>();
                });
                IMapper mapper = config.CreateMapper();

                var OfferModel = mapper.Map<Offer, OfferEntity>(offer);
                return OfferModel;
            }
            return null;
        }
    }
}