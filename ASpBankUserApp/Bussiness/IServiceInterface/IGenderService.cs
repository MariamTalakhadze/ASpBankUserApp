using System;
using Business.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASpBankUserApp.Bussiness.IServiceInterface
{
    public interface IGenderService
    {
        GenderEntity GetGenderByID(int GenderID);
        IEnumerable<GenderEntity> GetAkkGender();
    }
}
