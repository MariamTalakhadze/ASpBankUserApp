using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASpBankUserApp.Bussiness.IServiceInterface { 
    public interface IUserService
    {
        UserEntity GetUserByID(int UserID);
        IEnumerable<UserEntity> GetAllAuthors();
        int CreateUser(UserEntity userEntity);
        bool UpdateUser(int UserID, UserEntity userEntity);
        bool DeleteUser(int UserID);
    }
}
