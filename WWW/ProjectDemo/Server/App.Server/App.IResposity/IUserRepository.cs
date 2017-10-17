using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Framework.BaseEntity;
using App.Model.RequestBody;
using App.Model.DBEntity;

namespace App.IRepository
{
    public interface IUserRepository
    {
        Page<sys_User> GetUsersFor(UserRequest request);

        int AddUser(sys_User request);

        int UpdateUser(sys_User request);
    }
}
