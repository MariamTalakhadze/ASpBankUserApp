using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;

namespace ASpBankUserApp.Bussiness.IServiceInterface
{
    public interface ISponsorTypeService
    {
        SponsorTypeEntity GetSponsorTypeByID(int SponsorTypeID);
        IEnumerable<SponsorTypeEntity> GetAllSponsorTypes();
    }
}
