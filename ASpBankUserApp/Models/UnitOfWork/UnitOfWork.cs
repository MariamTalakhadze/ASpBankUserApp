using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASpBankUserApp.Models;
using Models.Repo;

namespace Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...
        private DBModel _context = null;
        private GenericRepo<User> _userRepository;
        private GenericRepo<Offer> _offerRepository;
        private GenericRepo<SponsorType> _sponsorTypeRepository;
        private GenericRepo<ASpBankUserApp.Models.Task> _taskRepository;
        private GenericRepo<Gender> _genderRepository;
        private GenericRepo<City> _cityRepository;
        private GenericRepo<Country> _countryRepository;
        #endregion
        public UnitOfWork() 
        {
            _context = new DBModel();
        }
        public GenericRepo<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepo<User>(_context);
                return _userRepository;
            }
        }
        public GenericRepo<Gender> GenderRepository
        {
            get
            {
                if (this._genderRepository == null)
                    this._genderRepository = new GenericRepo<Gender>(_context);
                return _genderRepository;
            }
            
        }

        public GenericRepo<City> CityRepository
        {
            get
            {
                if (this._cityRepository == null)
                    this._cityRepository = new GenericRepo<City>(_context);
                return _cityRepository;
            }

        }


        public GenericRepo<Country> CountryRepository
        {
            get
            {
                if (this._countryRepository == null)
                    this._countryRepository = new GenericRepo<Country>(_context);
                return _countryRepository;
            }

        }

        public GenericRepo<Offer> OfferRepository
        {
            get
            {
                if (this._offerRepository == null)
                    this._offerRepository = new GenericRepo<Offer>(_context);
                return _offerRepository;
            }
        }
        public GenericRepo<SponsorType> SponsorTypeRepository
        {
            get
            {
                if (this._sponsorTypeRepository == null)
                    this._sponsorTypeRepository = new GenericRepo<SponsorType>(_context);
                return _sponsorTypeRepository;
            }
        }
        public GenericRepo<ASpBankUserApp.Models.Task> TaskRepository
        {
            get
            {
                if (this._taskRepository == null)
                    this._taskRepository = new GenericRepo<ASpBankUserApp.Models.Task>(_context);
                return _taskRepository;
            }
        }

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                throw e;
            }
        }
        #endregion
        #region Implementing IDiosposable...
        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion
        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
