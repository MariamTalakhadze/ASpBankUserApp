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
    public class UserService : IUserService, IDisposable
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int CreateUser(UserEntity userEntity)
        {
            var User = new User
            {
                UserName = userEntity.UserName,
                UserLastName = userEntity.UserLastName,
                PersonalNumber = userEntity.PersonalNumber,
                MobileNumber = userEntity.MobileNumber,
                GenderID = userEntity.GenderID,
                Email = userEntity.Email,
                CountryID = userEntity.CountryID,
                CityID = userEntity.CityID

    };
            _unitOfWork.UserRepository.Insert(User);
            _unitOfWork.Save();
            return User.UserID;
        }
        public bool DeleteUser(int UserID)
        {
            var success = false;
            if (UserID > 0)
            {

                var user = _unitOfWork.UserRepository.GetByID(UserID);
                if (user != null)
                {
                    _unitOfWork.UserRepository.Delete(user);
                    _unitOfWork.Save();

                    success = true;
                }

            }
            return success;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public UserEntity GetUserByID(int UserID)
        {
            var item = _unitOfWork.UserRepository.GetByID(UserID);
            if (item != null)
            {

                var AuthorModel = new UserEntity
                {
                    Gender = new GenderEntity
                    {
                        GenderID = item.Gender.GenderID,
                        FM = item.Gender.FM
                    },
                    UserID = item.UserID,
                    UserName = item.UserName,
                    UserLastName = item.UserLastName,
                    GenderID = item.GenderID,

                    PersonalNumber = item.PersonalNumber,
                    CityID = item.CityID,
                    CountryID = item.CountryID,
                    Email = item.Email,
                    MobileNumber = item.MobileNumber,
                    Country = new CountryEntity
                    {
                        CountryID = item.Country.CountryID,
                        title = item.Country.title
                    },
                    City = new CityEntity
                    {
                        title = item.City.title,
                        CityID = item.City.CityID
                    }

                };


                return AuthorModel;
            }
            return null;
        }
        public bool UpdateUser(int UserID, UserEntity userEntity)
        {
            var success = false;
            if (userEntity != null)
            {

                var user = _unitOfWork.UserRepository.GetByID(UserID);
                if (user != null)
                {
                    user.UserName = userEntity.UserName;
                    user.UserLastName = userEntity.UserLastName;
                    user.CityID = userEntity.CityID;
                    user.CountryID = userEntity.CountryID;
                    user.Email = userEntity.Email;
                    user.GenderID = userEntity.GenderID;
                    user.PersonalNumber = userEntity.PersonalNumber;
                    user.MobileNumber = userEntity.MobileNumber;
                    _unitOfWork.UserRepository.Update(user);
                    _unitOfWork.Save();

                    success = true;
                }

            }
            return success;
        }

        IEnumerable<UserEntity> IUserService.GetAllAuthors()
        {
            var user = _unitOfWork.UserRepository.GetAll();
            if (user.Any())
            {
                //var config = new MapperConfiguration(cfg => {
                //    cfg.CreateMap<Author, AuthorEntity>();
                //});
                //IMapper mapper = config.CreateMapper();
                List<UserEntity> userEntities = new List<UserEntity>();
                foreach (User item in user)
                {
                    userEntities.Add(new UserEntity
                    {
                        Gender = new GenderEntity
                        {
                            GenderID = item.Gender.GenderID,
                            FM = item.Gender.FM
                        },
                        UserID = item.UserID,
                        UserName = item.UserName,
                        UserLastName = item.UserLastName,
                        GenderID = item.GenderID,

                        PersonalNumber = item.PersonalNumber,
                        CityID = item.CityID,
                        CountryID = item.CountryID,
                        Email = item.Email,
                        MobileNumber = item.MobileNumber,
                        Country = new CountryEntity
                        {
                            CountryID = item.Country.CountryID,
                            title = item.Country.title
                        },
                        City = new CityEntity
                        {
                            title = item.City.title,
                            CityID = item.City.CityID
                        }

                    });
                }




                return userEntities;
            }
            return null;
        }
    }
}
