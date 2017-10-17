using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Framework.BaseEntity;
using App.Model.RequestBody;
using App.Model.DBEntity;
using App.IService;
using App.IRepository;

namespace App.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository productRepository)
        {
            _userRepository = productRepository;
        }

        public Page<sys_User> GetUsersFor(UserRequest request)
        {
            return _userRepository.GetUsersFor(request);
        }

        public int AddUser(sys_User request)
        {
            return _userRepository.AddUser(request);
        }

        public int UpdateUser(sys_User request)
        {
            return _userRepository.UpdateUser(request);
        }
    }
}
