using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model.DBEntity;
using App.Model.RequestBody;
using App.Framework.BaseEntity;
using App.IRepository;
using System.Data.SqlClient;
using App.Framework.DB;
using System.Data;

namespace App.Repository
{
    public class UserRepository: IUserRepository
    {
        public Page<sys_User> GetUsersFor(UserRequest request)
        {
            Dictionary<string, SortOrder> orderKey = new Dictionary<string, SortOrder>();
            //if (!string.IsNullOrEmpty(request.OrderField))
            //    orderKey.Add(request.OrderField, request.SortOrder);
            orderKey.Add("ID", SortOrder.Ascending);
            List<sys_User> users = new List<sys_User>();
            string strSql = @"select * from sys_User where 1=1 ";
            using (IDbConnection sqlConn = SQLDBHelper.CreateConnection())
            {
                return sqlConn.QueryPaging<sys_User>(strSql, request,orderKey);
            }
        }

        public int AddUser(sys_User request)
        {
            using (IDbConnection sqlConn = SQLDBHelper.CreateConnection())
            {
                for(int i = 0; i < 200; i++)
                {
                    request = new sys_User()
                    {
                        Name = "liwx" + i,
                        Account = "Account" + i,
                        Password = "1111111" + i.ToString(),
                        Gender = i % 2,
                        Status = 1,
                        IsLimitIP = true,
                        MaxIPCount = 1,
                        Email = "358948567" + i.ToString() + "@qq.com",
                        Mobile = (15821121139 + i).ToString()
                    };
                    sqlConn.Insert(request);
                }

                return 1;
            }
        }

        public int UpdateUser(sys_User request)
        {
            using (IDbConnection sqlConn = SQLDBHelper.CreateConnection())
            {
                return sqlConn.Update(request);
            }
        }

    }
}
