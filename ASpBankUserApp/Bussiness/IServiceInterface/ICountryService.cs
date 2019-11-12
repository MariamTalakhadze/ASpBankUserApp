using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entity;
using System.Threading.Tasks;

namespace ASpBankUserApp.Bussiness.IServiceInterface
{
    public interface ICountryService
    {
        CountryEntity GetCountryByID(int CountryID);
        IEnumerable<CountryEntity> GetAllCountry();
    }
}
